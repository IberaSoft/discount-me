using System;
using System.Web;
using System.Web.Security;

namespace DiscountMe.Infrastructure {
    public class FormsAuthenticationService : IFormsAuthenticationService {
        public void SignIn(string userName, bool createPersistentCookie) {
            if (String.IsNullOrEmpty(userName))
                throw new ArgumentException("Value cannot be null or empty.", "userName");
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
            var userData = Membership.GetUser(userName, true).ProviderUserKey.ToString(); // Aqu� va el ID del usuario que pillar�amos de la BBDD
            var ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddMinutes(30), createPersistentCookie, userData);
            string encTicket = FormsAuthentication.Encrypt(ticket);
            var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            HttpContext.Current.Response.Cookies.Add(faCookie);
        }

        public void SignOut() {
            FormsAuthentication.SignOut();
        }
    }
}