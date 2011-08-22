using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using DiscountMe.BL;
using DiscountMe.BL.ViewModels;
using DiscountMe.DAL;
using DiscountMe.Infrastructure;
using DiscountMe.Infrastructure.Services;

namespace DiscountMe.Controllers {
    public class AccountController : Controller {
        private readonly IUnitOfWork uow;
        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }
        public IRolService RolService { get; set; }

        public AccountController(IUnitOfWork unitOfWork) {
            uow = unitOfWork;
            FormsService = DependencyResolver.Current.GetService<IFormsAuthenticationService>();
            MembershipService = DependencyResolver.Current.GetService<IMembershipService>();
            RolService = DependencyResolver.Current.GetService<IRolService>();
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************
        [AllowAnonymous]
        public ActionResult LogOn() {
            return View();
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogOn(LogOnVM datosUsuario, string returnUrl) {
            if (ModelState.IsValid) {
                if (MembershipService.ValidateUser(datosUsuario.UserName, datosUsuario.Password)) {
                    FormsService.SignIn(datosUsuario.UserName, datosUsuario.RememberMe);
                    if (Url.IsLocalUrl(returnUrl)) {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "El nombre de usuario o la contraseña son incorrectos.");
            }
            // If we got this far, something failed, redisplay form
            return View(datosUsuario);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************
        public ActionResult LogOff() {
            FormsService.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/RegisterNewUser
        // **************************************
        [AllowAnonymous]
        public ActionResult RegisterNewUser() {
            return View(uow.Users.Crear());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RegisterNewUser(User usuario) {
            if (ModelState.IsValid) {
                // Attempt to register the user
                var user = new CustomMembershipUser("CustomMembershipProvider",
                                                    usuario.UserName,
                                                    usuario.Id,
                                                    usuario.Email,
                                                    "",
                                                    "",
                                                    true,
                                                    false,
                                                    usuario.CreateDate,
                                                    DateTime.Now,
                                                    DateTime.Now,
                                                    DateTime.Now,
                                                    DateTime.Now) { User = usuario };
                var createStatus = MembershipService.CreateUser(user);
                if (createStatus == MembershipCreateStatus.Success) {
                    RolService.AddUsersToRoles(new[] {user.User.UserName}, new[] {"BasicUser"});
                    FormsService.SignIn(user.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "UserManagement");
                }
                ModelState.AddModelError("", ErrorCodes.ErrorCodeToString(createStatus));
            }
            // If we got this far, something failed, redisplay form
            return View(usuario);
        }

        // **************************************
        // URL: /Account/RegisterNewAdvertiser
        // **************************************
        [AllowAnonymous]
        public ActionResult RegisterNewAdvertiser() {
            var model = new AdvertiserVM {
                            Advertiser = uow.Advertisers.Crear(),
                        };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RegisterNewAdvertiser(AdvertiserVM model) {
            if (model.Advertiser != null && model.Latitude != null && model.Longitude != null) {
                model.Advertiser.Latitude = double.Parse(model.Latitude, CultureInfo.InvariantCulture);
                model.Advertiser.Longitude = double.Parse(model.Longitude, CultureInfo.InvariantCulture);
            }
            if (model.IsValid) {
                // Attempt to register the user
                var city = uow.Cities.Lista().SingleOrDefault(c => c.Name == model.City);
                var address = uow.Adresses.Crear();
                address.PostalCode = model.PostalCode;
                address.Street = model.Street;
                address.City = city;
                model.Advertiser.Address = address;
                var user = new CustomMembershipUser("CustomMembershipProvider",
                                                    model.Advertiser.UserName,
                                                    model.Advertiser.Id,
                                                    model.Advertiser.Email,
                                                    "",
                                                    "",
                                                    true,
                                                    false,
                                                    model.Advertiser.CreateDate,
                                                    DateTime.Now,
                                                    DateTime.Now,
                                                    DateTime.Now,
                                                    DateTime.Now) { Advertiser = model.Advertiser };
                var createStatus = MembershipService.CreateUser(user);
                if (createStatus == MembershipCreateStatus.Success) {
                    RolService.AddUsersToRoles(new[] { user.User.UserName }, new[] { "Advertiser" });
                    FormsService.SignIn(user.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "AdvertisersManagement");
                }
                ModelState.AddModelError("", ErrorCodes.ErrorCodeToString(createStatus));
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("City", "Introduzca su posición en el mapa");
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************
        [Authorize]
        public ActionResult ChangePassword() {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(User model, string newPassword) {
            if (ModelState.IsValid) {
                if (MembershipService.ChangePassword(User.Identity.Name, model.Password, newPassword)) {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
            }
            // If we got this far, something failed, redisplay form
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess
        public ActionResult ChangePasswordSuccess() {
            return View();
        }

        // **************************************
        // URL: /Account/Activate/username/key
        // **************************************
        [NonAction]
        public ActionResult Activate(string username, string key) {
            var membershipLayer = new MembershipServiceLayer();
            if (membershipLayer.ActivateUser(username, key) == false)
                return RedirectToAction("Index", "Home");
            return RedirectToAction("LogOn");
        }
    }
}