using System;
using System.Web.Security;

namespace DiscountMe.Infrastructure {
    public class AccountMembershipService : IMembershipService {
        private readonly CustomMembershipProvider provider;

        public AccountMembershipService() : this(null) {
        }

        public AccountMembershipService(CustomMembershipProvider provider) {
            this.provider = provider;
        }

        public int MinPasswordLength {
            get { return provider.MinRequiredPasswordLength; }
        }

        public bool ValidateUser(string userName, string password) {
            if (String.IsNullOrEmpty(userName))
                throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(password))
                throw new ArgumentException("Value cannot be null or empty.", "password");

            return provider.ValidateUser(userName, password);
        }

        public MembershipCreateStatus CreateUser(CustomMembershipUser usuario) {
            if (usuario.User == null && usuario.Advertiser == null)
                throw new ArgumentException("Value cannot be null or empty.", "usuario");

            MembershipCreateStatus status;
            provider.CreateUser(usuario, out status);
            return status;
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword) {
            if (String.IsNullOrEmpty(userName))
                throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(oldPassword))
                throw new ArgumentException("Value cannot be null or empty.", "oldPassword");
            if (String.IsNullOrEmpty(newPassword))
                throw new ArgumentException("Value cannot be null or empty.", "newPassword");

            // The underlying ChangePassword() will throw an exception rather
            // than return false in certain failure scenarios.
            try {
                MembershipUser currentUser = provider.GetUser(userName, true /* userIsOnline */);
                return currentUser.ChangePassword(oldPassword, newPassword);
            }
            catch (ArgumentException) {
                return false;
            }
            catch (MembershipPasswordException) {
                return false;
            }
        }
    }
}