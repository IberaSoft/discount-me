using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.Mail;
using DiscountMe.BL;
using DiscountMe.Common;
using DiscountMe.DAL;

namespace DiscountMe.Infrastructure {
    public class MembershipServiceLayer {
        private readonly IUnitOfWork uow;

        public MembershipServiceLayer() : this(DependencyResolver.Current.GetService<IUnitOfWork>()) {
        }

        private MembershipServiceLayer(IUnitOfWork unitOfWork) {
            uow = unitOfWork;
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
                var user = new Advertiser();
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
            var usuario = uow.Users.Lista().Where(u => (u.UserName == userName)).ToList();
            if (usuario.Count != 0) {
                var dbuser = usuario.FirstOrDefault();
                if (dbuser != null) {
                    var username = dbuser.UserName;
                    var providerUserKey = dbuser.Id;
                    var email = dbuser.Email;
                    const string passwordQuestion = "";
                    var isApproved = dbuser.IsActivated;
                    var isLockedOut = dbuser.IsLockedOut;
                    var creationDate = dbuser.CreateDate;
                    var lastLoginDate = dbuser.LastLoginDate;
                    var lastActivityDate = DateTime.Now;
                    var lastPasswordChangedDate = DateTime.Now;
                    var lastLockedOutDate = dbuser.LastLockedOutDate;
                    var user = new CustomMembershipUser("CustomMembershipProvider", username, providerUserKey, email,
                                                        passwordQuestion, "", isApproved, isLockedOut, creationDate,
                                                        lastLoginDate, lastActivityDate, lastPasswordChangedDate,
                                                        lastLockedOutDate) {User = dbuser};
                    return user;
                }
            }
            var advertiser = uow.Advertisers.Lista().Where(u => (u.UserName == userName)).ToList();
            if (advertiser.Count != 0) {
                var dbuser = advertiser.FirstOrDefault();
                if (dbuser != null) {
                    var username = dbuser.UserName;
                    var providerUserKey = dbuser.Id;
                    var email = dbuser.Email;
                    const string passwordQuestion = "";
                    var isApproved = dbuser.IsActivated;
                    var isLockedOut = dbuser.IsLockedOut;
                    var creationDate = dbuser.CreateDate;
                    var lastLoginDate = dbuser.LastLoginDate;
                    var lastActivityDate = DateTime.Now;
                    var lastPasswordChangedDate = DateTime.Now;
                    var lastLockedOutDate = dbuser.LastLockedOutDate.HasValue ? dbuser.LastLockedOutDate.Value : Constantes.FechaPorDefecto;
                    var user = new CustomMembershipUser("CustomMembershipProvider", username, providerUserKey, email,
                                                        passwordQuestion, "", isApproved, isLockedOut, creationDate,
                                                        lastLoginDate, lastActivityDate, lastPasswordChangedDate,
                                                        lastLockedOutDate) {
                                                            Advertiser = dbuser
                                                        };
                    return user;
                }
            }
            return null;
        }

        public string GetUserNameByEmail(string email) {
            var usuario = uow.Users.Lista().Where(u => (u.Email == email)).ToList();
            if (usuario.Count != 0) {
                var dbuser = usuario.FirstOrDefault();
                if (dbuser != null)
                    return dbuser.UserName;
            }
            var advertiser = uow.Advertisers.Lista().Where(u => (u.Email == email)).ToList();
            if (advertiser.Count != 0) {
                var dbuser = advertiser.FirstOrDefault();
                if (dbuser != null)
                    return dbuser.UserName;
            }
            return string.Empty;
        }

        public bool ValidateUser(string username, string password) {
            var usuario = uow.Users.Lista().Where(u => (u.UserName == username)).ToList();
            if (usuario.Count != 0) {
                var dbuser = usuario.First();
                return dbuser.Password == Constantes.EncodePassword(password, dbuser.PasswordSalt);
            }
            var advertiser = uow.Advertisers.Lista().Where(u => (u.UserName == username)).ToList();
            if (advertiser.Count != 0) {
                var dbuser = advertiser.First();
                return dbuser.Password == Constantes.EncodePassword(password, dbuser.PasswordSalt);
            }
            return false;
        }

        public bool ActivateUser(string username, string key) {
            var usuario = uow.Users.Lista().Where(u => (u.UserName == username)).ToList();
            if (usuario.Count != 0) {
                var dbuser = usuario.FirstOrDefault();
                if (dbuser != null && dbuser.NewEmailKey == key) {
                    dbuser.IsActivated = true;
                    dbuser.LastModifiedDate = DateTime.Now;
                    dbuser.NewEmailKey = null;
                    uow.SaveChanges();
                    return true;
                }
                return false;
            }
            var advertiser = uow.Advertisers.Lista().Where(u => (u.UserName == username)).ToList();
            if (advertiser.Count != 0) {
                var dbuser = advertiser.FirstOrDefault();
                if (dbuser != null && dbuser.NewEmailKey == key) {
                    dbuser.IsActivated = true;
                    dbuser.LastModifiedDate = DateTime.Now;
                    dbuser.NewEmailKey = null;
                    uow.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }

        private static void SendActivationEmail(User user) {
            var activationLink = "http://localhost:49514/Account/Activate/" + user.UserName + "/" + user.NewEmailKey;
            var message = new MailMessage("luiztajr@gmail.com", user.Email)
                          {Subject = "Activate your account", Body = activationLink};

            var client = new SmtpClient("smtp.gmail.com", 587)
                         {Credentials = new System.Net.NetworkCredential("", ""), EnableSsl = true};
            client.Send(message);
        }

        private static string GenerateKey() {
            Guid emailKey = Guid.NewGuid();
            return emailKey.ToString();
        }
    }
}