using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.Mail;
using DiscountMe.BL;
using DiscountMe.Common;
using DiscountMe.DAL;

namespace DiscountMe.Infrastructure {
    public class MembershipServiceLayer {
        private readonly CustomMembershipProvider membershipProvider;
        private readonly IUnitOfWork uow;

        public MembershipServiceLayer() : this(DependencyResolver.Current.GetService<IUnitOfWork>()) {
        }

        private MembershipServiceLayer(IUnitOfWork unitOfWork) {
            uow = unitOfWork;
            membershipProvider = DependencyResolver.Current.GetService<CustomMembershipProvider>();
        }

        public MembershipUser CreateUser(CustomMembershipUser usuario) {
            if (usuario.User != null) {
                var user = usuario.User;
                user.Name = usuario.User.Name;
                user.Surname = usuario.User.Surname;
                user.UserName = usuario.User.UserName;
                user.Email = usuario.User.Email;
                user.PasswordSalt = Constantes.PasswordSalt;
                user.Password = Constantes.EncodePassword(usuario.User.Password, user.PasswordSalt);
                user.CreateDate = DateTime.Now;
                user.LastModifiedDate = DateTime.Now;
                user.IsActivated = false;
                user.IsLockedOut = false;
                user.LastLockedOutDate = DateTime.Now;
                user.LastLoginDate = DateTime.Now;
                user.NewPasswordRequestedDate = DateTime.Now;
                user.NewEmailKey = GenerateKey();
                uow.Users.Agregar(user);
                uow.SaveChanges();
                //SendActivationEmail(user);
                return GetUser(usuario.User.UserName);
            }
            if (usuario.Advertiser != null) {
                var user = usuario.Advertiser;
                user.Name = usuario.Advertiser.Name;
                user.Address = usuario.Advertiser.Address;
                user.Surname = usuario.Advertiser.Surname;
                user.UserName = usuario.Advertiser.UserName;
                user.CompanyName = usuario.Advertiser.CompanyName;
                user.Cif = usuario.Advertiser.Cif;
                user.PrimaryPhone = usuario.Advertiser.PrimaryPhone;
                user.Email = usuario.Advertiser.Email;
                user.PasswordSalt = Constantes.PasswordSalt;
                user.Password = Constantes.EncodePassword(usuario.Advertiser.Password, user.PasswordSalt);
                user.CreateDate = DateTime.Now;
                user.LastModifiedDate = DateTime.Now;
                user.IsActivated = false;
                user.IsLockedOut = false;
                user.LastLockedOutDate = DateTime.Now;
                user.LastLoginDate = DateTime.Now;
                user.NewPasswordRequestedDate = DateTime.Now;
                user.NewEmailKey = GenerateKey();
                uow.Adresses.Agregar(user.Address);
                uow.Advertisers.Agregar(user);
                uow.SaveChanges();
                //SendActivationEmail(user);
                return GetUser(usuario.Advertiser.UserName);
            }
            return null;
        }

        public MembershipUser GetUser(string userName) {
            var usuario = uow.Users.Consulta(u => (u.UserName == userName)).SingleOrDefault();
            if (usuario != null) {
                var username = usuario.UserName;
                var providerUserKey = usuario.Id;
                var email = usuario.Email;
                const string passwordQuestion = "";
                var isApproved = usuario.IsActivated;
                var isLockedOut = usuario.IsLockedOut;
                var creationDate = usuario.CreateDate;
                var lastLoginDate = usuario.LastLoginDate;
                var lastActivityDate = DateTime.Now;
                var lastPasswordChangedDate = DateTime.Now;
                var lastLockedOutDate = usuario.LastLockedOutDate;
                var user = new CustomMembershipUser("CustomMembershipProvider", username, providerUserKey, email,
                                                    passwordQuestion, "", isApproved, isLockedOut, creationDate,
                                                    lastLoginDate, lastActivityDate, lastPasswordChangedDate,
                                                    lastLockedOutDate) {User = usuario};
                return user;
            }
            var advertiser = uow.Advertisers.Consulta(u => (u.UserName == userName)).SingleOrDefault();
            if (advertiser != null) {
                var username = advertiser.UserName;
                var providerUserKey = advertiser.Id;
                var email = advertiser.Email;
                const string passwordQuestion = "";
                var isApproved = advertiser.IsActivated;
                var isLockedOut = advertiser.IsLockedOut;
                var creationDate = advertiser.CreateDate;
                var lastLoginDate = advertiser.LastLoginDate;
                var lastActivityDate = DateTime.Now;
                var lastPasswordChangedDate = DateTime.Now;
                var lastLockedOutDate = advertiser.LastLockedOutDate.HasValue
                                            ? advertiser.LastLockedOutDate.Value
                                            : Constantes.FechaPorDefecto;
                var user = new CustomMembershipUser("CustomMembershipProvider", username, providerUserKey, email,
                                                    passwordQuestion, "", isApproved, isLockedOut, creationDate,
                                                    lastLoginDate, lastActivityDate, lastPasswordChangedDate,
                                                    lastLockedOutDate) {
                                                                           Advertiser = advertiser
                                                                       };
                return user;
            }
            return null;
        }

        public string GetUserNameByEmail(string email) {
            var usuario = uow.Users.Consulta(u => (u.Email == email)).SingleOrDefault();
            if (usuario != null)
                    return usuario.UserName;
            var advertiser = uow.Advertisers.Consulta(u => (u.Email == email)).SingleOrDefault();
            if (advertiser != null)
                return advertiser.UserName;
            return string.Empty;
        }

        public bool ValidateUser(string username, string password) {
            var usuario = uow.Users.Consulta(u => (u.UserName == username)).SingleOrDefault();
            if (usuario != null) {
                return usuario.Password == Constantes.EncodePassword(password, usuario.PasswordSalt);
            }
            var advertiser = uow.Advertisers.Consulta(u => (u.UserName == username)).SingleOrDefault();
            if (advertiser != null) {
                return advertiser.Password == Constantes.EncodePassword(password, advertiser.PasswordSalt);
            }
            return false;
        }

        public bool ActivateUser(string username, string key) {
            var usuario = uow.Users.Consulta(u => (u.UserName == username)).SingleOrDefault();
            if (usuario != null && usuario.NewEmailKey == key) {
                usuario.IsActivated = true;
                usuario.LastModifiedDate = DateTime.Now;
                usuario.NewEmailKey = null;
                uow.SaveChanges();
                return true;
            }
            var advertiser = uow.Advertisers.Consulta(u => (u.UserName == username)).SingleOrDefault();
            if (advertiser != null && advertiser.NewEmailKey == key) {
                advertiser.IsActivated = true;
                advertiser.LastModifiedDate = DateTime.Now;
                advertiser.NewEmailKey = null;
                uow.SaveChanges();
                return true;
            }
            return false;
        }

        public IList<MembershipUser> GetAllUsers(int pageNumber, int pageSize) {
            // get one page of users
            int totalUserCount;
            var usersCollection = membershipProvider.GetAllUsers(pageNumber - 1, pageSize, out totalUserCount);
            return usersCollection.Cast<MembershipUser>().ToList();
        }

        public IList<MembershipUser> FindByEmail(string search, int pageNumber, int pageSize) {
            int totalRecords;
            var usersCollection = membershipProvider.FindUsersByEmail(search, pageNumber - 1, pageSize, out totalRecords);
            return usersCollection.Cast<MembershipUser>().ToList();
        }

        public IList<MembershipUser> FindByUserName(string search, int pageNumber, int pageSize) {
            int totalRecords;
            var usersCollection = membershipProvider.FindUsersByName(search, pageNumber - 1, pageSize, out totalRecords);
            return usersCollection.Cast<MembershipUser>().ToList();
        }
        
        #region Activation by email
        
        private static void SendActivationEmail(User user) {
            var activationLink = "http://localhost:49514/Account/Activate/" + user.UserName + "/" + user.NewEmailKey;
            var message = new MailMessage("luiztajr@gmail.com", user.Email)
                          {Subject = "Activate your account", Body = activationLink};

            var client = new SmtpClient("smtp.gmail.com", 587)
                         {Credentials = new NetworkCredential("", ""), EnableSsl = true};
            client.Send(message);
        }

        private static string GenerateKey() {
            Guid emailKey = Guid.NewGuid();
            return emailKey.ToString();
        }

        #endregion
    }
}