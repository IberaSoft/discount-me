using System;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;
using System.Collections.Specialized;
using DiscountMe.BL;
using DiscountMe.DAL;

namespace DiscountMe.Infrastructure {
    public class CustomMembershipProvider : MembershipProvider {
        private readonly IUnitOfWork uow;

        public override void Initialize(string name, NameValueCollection config) {
            if (config == null)
                throw new ArgumentNullException("config");
            if (name.Length == 0)
                name = "CustomMembershipProvider";
            if (String.IsNullOrEmpty(config["description"])) {
                config.Remove("description");
                config.Add("description", "Custom Membership Provider");
            }
            base.Initialize(name, config);
            applicationName = GetConfigValue(config["applicationName"], HostingEnvironment.ApplicationVirtualPath);
            maxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));
            passwordAttemptWindow = Convert.ToInt32(GetConfigValue(config["passwordAttemptWindow"], "10"));
            minRequiredNonalphanumericCharacters = Convert.ToInt32(GetConfigValue(config["minRequiredNonalphanumericCharacters"], "1"));
            minRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "6"));
            enablePasswordReset = Convert.ToBoolean(GetConfigValue(config["enablePasswordReset"], "true"));
            passwordStrengthRegularExpression = Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], ""));
        }

        public CustomMembershipProvider() : this(DependencyResolver.Current.GetService<IUnitOfWork>()) {
        }

        private CustomMembershipProvider(IUnitOfWork unitOfWork) {
            uow = unitOfWork;
        }

        public override string ApplicationName {
            get { return applicationName; }
            set { applicationName = value; }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword) {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password,
                                                             string newPasswordQuestion, string newPasswordAnswer) {
            return false;
        }

        public MembershipUser CreateUser(CustomMembershipUser usuario, out MembershipCreateStatus status) {
            if (usuario.User != null) {
                var args = new ValidatePasswordEventArgs(usuario.User.UserName, usuario.User.Password, true);
                OnValidatingPassword(args);
                if (args.Cancel) {
                    status = MembershipCreateStatus.InvalidPassword;
                    return null;
                }
                if (RequiresUniqueEmail && GetUserNameByEmail(usuario.User.Email) != "") {
                    status = MembershipCreateStatus.DuplicateEmail;
                    return null;
                }
                var u = GetUser(usuario.User.UserName, false);
                if (u == null) {
                    var user = new MembershipServiceLayer();
                    user.CreateUser(usuario);
                    status = MembershipCreateStatus.Success;
                    return GetUser(usuario.User.UserName, false);
                }
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }
            if (usuario.Advertiser != null) {
                var args = new ValidatePasswordEventArgs(usuario.Advertiser.UserName, usuario.Advertiser.Password, true);
                OnValidatingPassword(args);
                if (args.Cancel) {
                    status = MembershipCreateStatus.InvalidPassword;
                    return null;
                }
                if (RequiresUniqueEmail && GetUserNameByEmail(usuario.Advertiser.Email) != "") {
                    status = MembershipCreateStatus.DuplicateEmail;
                    return null;
                }
                var u = GetUser(usuario.Advertiser.UserName, false);
                if (u == null) {
                    var user = new MembershipServiceLayer();
                    user.CreateUser(usuario);
                    status = MembershipCreateStatus.Success;
                    return GetUser(usuario.Advertiser.UserName, false);
                }
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }
            status = MembershipCreateStatus.InvalidUserName;
            return null;
        }

        public override MembershipUser CreateUser(string username, string password, string email,
                                                  string passwordQuestion, string passwordAnswer, bool isApproved,
                                                  object providerUserKey, out MembershipCreateStatus status) {
            var args = new ValidatePasswordEventArgs(username, password, true);
            OnValidatingPassword(args);
            if (args.Cancel) {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }
            if (RequiresUniqueEmail && GetUserNameByEmail(email) != "") {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }
            var u = GetUser(username, false);
            if (u == null) {
                var user = new MembershipServiceLayer();
                user.CreateUser(new CustomMembershipUser("CustomMembershipProvider", username, providerUserKey, email,
                                                         passwordQuestion, "", isApproved, false, DateTime.Now,
                                                         DateTime.Now, DateTime.Now, DateTime.Now,
                                                         DateTime.Now){User = new User()});
                status = MembershipCreateStatus.Success;
                return GetUser(username, false);
            }
            status = MembershipCreateStatus.DuplicateUserName;
            return null;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData) {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset {
            get { return enablePasswordReset; }
        }

        public override bool EnablePasswordRetrieval {
            get { return enablePasswordRetrieval; }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize,
                                                                  out int totalRecords) {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize,
                                                                 out int totalRecords) {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords) {
            var users = DependencyResolver.Current.GetService<MembershipUserCollection>();
            var advertisers = uow.Advertisers.Lista().ToList();
            foreach (var advertiser in advertisers) {
                var membershipUser = new CustomMembershipUser("CustomMembershipProvider", advertiser.UserName,
                                                              advertiser.Id, advertiser.Email,
                                                              "", "", advertiser.IsActivated, advertiser.IsLockedOut,
                                                              DateTime.Now,
                                                              DateTime.Now, DateTime.Now, DateTime.Now,
                                                              DateTime.Now) {Advertiser = advertiser};
                users.Add(membershipUser);
            }
            var usuarios = uow.Users.Lista().ToList();
            foreach (var usuario in usuarios) {
                var membershipUser = new CustomMembershipUser("CustomMembershipProvider", usuario.UserName,
                                                              usuario.Id, usuario.Email,
                                                              "", "", usuario.IsActivated, usuario.IsLockedOut,
                                                              DateTime.Now,
                                                              DateTime.Now, DateTime.Now, DateTime.Now,
                                                              DateTime.Now) { User = usuario};
                users.Add(membershipUser);
            }
            totalRecords = advertisers.Count + usuarios.Count;
            return users;
        }

        public override int GetNumberOfUsersOnline() {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer) {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline) {
            var user = new MembershipServiceLayer();
            return user.GetUser(username);
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline) {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email) {
            var user = new MembershipServiceLayer();
            return user.GetUserNameByEmail(email);
        }

        public override int MaxInvalidPasswordAttempts {
            get { return maxInvalidPasswordAttempts; }
        }

        public override int MinRequiredNonAlphanumericCharacters {
            get { return minRequiredNonalphanumericCharacters; }
        }

        public override int MinRequiredPasswordLength {
            get { return minRequiredPasswordLength; }
        }

        public override int PasswordAttemptWindow {
            get { return passwordAttemptWindow; }
        }

        public override MembershipPasswordFormat PasswordFormat {
            get { return passwordFormat; }
        }

        public override string PasswordStrengthRegularExpression {
            get { return passwordStrengthRegularExpression; }
        }

        public override bool RequiresQuestionAndAnswer {
            get { return requiresQuestionAndAnswer; }
        }

        public override bool RequiresUniqueEmail {
            get { return requiresUniqueEmail; }
        }

        public override string ResetPassword(string username, string answer) {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName) {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user) {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password) {
            var user = new MembershipServiceLayer();
            return user.ValidateUser(username, password);
        }


        private string applicationName;
        private bool enablePasswordReset;
        private bool enablePasswordRetrieval = false;
        private bool requiresQuestionAndAnswer = false;
        private bool requiresUniqueEmail = true;
        private int maxInvalidPasswordAttempts;
        private int passwordAttemptWindow;
        private int minRequiredPasswordLength;
        private int minRequiredNonalphanumericCharacters;
        private string passwordStrengthRegularExpression;
        private MembershipPasswordFormat passwordFormat = MembershipPasswordFormat.Hashed;

        private string GetConfigValue(string configValue, string defaultValue) {
            return string.IsNullOrEmpty(configValue) ? defaultValue : configValue;
        }
    }
}