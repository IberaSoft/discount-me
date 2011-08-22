using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using DiscountMe.DependencyResolution;
using DiscountMe.Infrastructure;
using DiscountMe.Infrastructure.Services;
using FluentValidation.Mvc;

namespace DiscountMe {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            //filters.Add(new LogonAuthorize());
            //filters.Add(new RequireHttpsAttribute());
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.MapRoute("Paginacion", "AdvertisersManagement/Page{page}", // Matches /Page2, /Page123, but not /PageXYZ
                    new {
                        controller = "AdvertisersManagement",
                        action = "Index"
                    },
                    new { page = @"\d+" } // Constraints: page must be numerical
            );
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new [] { "DiscountMe.Controllers" }
            );
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e) {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                return;
            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            var identity = new CustomIdentity(authTicket.Name, authTicket.UserData);
            var rolSL = new RolServiceLayer();
            var roles = rolSL.GetRolesForUser(identity.Name);
            var newUser = new GenericPrincipal(identity, roles);
            Context.User = newUser;
        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            //ModelValidatorProviders.Providers.Add(vali);
            ControllerBuilder.Current.SetControllerFactory(typeof(SMControllerFactory));
            DependencyResolver.SetResolver(new SMDependencyResolver(IoC.Initialize()));
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            FluentValidationModelValidatorProvider.Configure(provider => { provider.ValidatorFactory = new SMValidatorFactory(); });
            PostAuthenticateRequest += Application_PostAuthenticateRequest;
        }
    }
}