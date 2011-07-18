using System;
using System.Web;
using System.Web.Mvc;
using DiscountMe;
using DiscountMe.BL;
using DiscountMe.BL.ViewModels;
using DiscountMe.Controllers;
using DiscountMe.DAL;
using DiscountMe.DependencyResolution;
using DiscountMe.Infrastructure;
using DiscountMe.Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StructureMap;

namespace DiscountMeMVC4.TestMethods {
    /// <summary>
    ///This is a TestMethod class for AccountControllerTestMethod and is intended
    ///to contain all AccountControllerTestMethod Unit TestMethods
    ///</summary>
    [TestClass]
    public class AccountControllerTestMethod {
        private static Mock<HttpContextBase> Context { get; set; }
        private IUnitOfWork uow;

        #region TestMethod configurations

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void FixtureSetUp(TestContext context) {
            ControllerBuilder.Current.SetControllerFactory(typeof(SMControllerFactory));
            DependencyResolver.SetResolver(new SMDependencyResolver(IoC.Initialize()));
        }

        private static void CreateMockForRequestObject(string url) {
            //var server = new Mock<HttpServerUtilityBase>(MockBehavior.Strict);
            //server.Setup(s => s.MachineName).Returns("localhost");

            //var response = new Mock<HttpResponseBase>(MockBehavior.Strict);
            //response.Setup(r => r.Status).Returns("HTTP_STATUS_OK");

            var request = new Mock<HttpRequestBase>(MockBehavior.Strict);
            request.Setup(r => r.UserHostAddress).Returns("127.0.0.1");
            request.Setup(r => r.UrlReferrer).Returns(new Uri(url));

            //var session = new Mock<HttpSessionStateBase>();
            //session.Setup(s => s.SessionID).Returns(Guid.NewGuid().ToString());

            Context = new Mock<HttpContextBase>();
            Context.SetupGet(c => c.Request).Returns(request.Object);
            //Context.SetupGet(c => c.Response).Returns(response.Object);
            //Context.SetupGet(c => c.Server).Returns(server.Object);
            //Context.SetupGet(c => c.Session).Returns(session.Object);
        }

        [TestInitialize]
        public void Init() {
            uow = ObjectFactory.GetInstance<IUnitOfWork>();
        }

        [TestCleanup]
        public void Dispose() {
            uow = null;
        }

        #endregion

        /// <summary>
        ///A TestMethod for AccountController Constructor
        ///</summary>
        [TestMethod]
        public void AccountControllerConstructorTestMethod() {
            AccountController target = new AccountController(uow);

            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A TestMethod for Activate
        ///</summary>
        [TestMethod]
        public void ActivateTestMethod() {
            AccountController target = new AccountController(uow); // TODO: Initialize to an appropriate value
            string username = string.Empty; // TODO: Initialize to an appropriate value
            string key = string.Empty; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Activate(username, key);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A TestMethod for ChangePassword
        ///</summary>
        [TestMethod]
        public void ChangePasswordTestMethod() {
            AccountController target = new AccountController(uow); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.ChangePassword();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A TestMethod for ChangePassword
        ///</summary>
        [TestMethod]
        public void ChangePasswordTestMethod1() {
            AccountController target = new AccountController(uow); // TODO: Initialize to an appropriate value
            User model = null; // TODO: Initialize to an appropriate value
            string newPassword = string.Empty; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.ChangePassword(model, newPassword);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A TestMethod for ChangePasswordSuccess
        ///</summary>
        [TestMethod]
        public void ChangePasswordSuccessTestMethod() {
            AccountController target = new AccountController(uow); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.ChangePasswordSuccess();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A TestMethod for LogOff
        ///</summary>
        [TestMethod]
        public void LogOffTestMethod() {
            AccountController target = new AccountController(uow); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.LogOff();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A TestMethod for LogOn
        ///</summary>
        [TestMethod]
        public void LogOnTestMethod() {
            AccountController target = new AccountController(uow); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.LogOn();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A TestMethod for LogOn
        ///</summary>
        [TestMethod]
        public void LogOnTestMethod1() {
            AccountController target = new AccountController(uow); // TODO: Initialize to an appropriate value
            LogOnVM datosUsuario = null; // TODO: Initialize to an appropriate value
            string returnUrl = string.Empty; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.LogOn(datosUsuario, returnUrl);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A TestMethod for RegisterNewAdvertiser
        ///</summary>
        [TestMethod]
        public void RegisterNewAdvertiserTestMethod() {
            AccountController target = new AccountController(uow); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.RegisterNewAdvertiser();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A TestMethod for RegisterNewAdvertiser
        ///</summary>
        [TestMethod]
        public void RegisterNewAdvertiserTestMethod1() {
            AccountController target = new AccountController(uow); // TODO: Initialize to an appropriate value
            AdvertiserVM model = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.RegisterNewAdvertiser(model);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A TestMethod for RegisterNewUser
        ///</summary>
        [TestMethod]
        public void RegisterNewUserTestMethod() {
            AccountController target = new AccountController(uow); // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.RegisterNewUser();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A TestMethod for RegisterNewUser
        ///</summary>
        [TestMethod]
        public void RegisterNewUserTestMethod1() {
            AccountController target = new AccountController(uow); // TODO: Initialize to an appropriate value
            User usuario = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.RegisterNewUser(usuario);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A TestMethod for FormsService
        ///</summary>
        [TestMethod]
        public void FormsServiceTestMethod() {
            AccountController target = new AccountController(uow); // TODO: Initialize to an appropriate value
            IFormsAuthenticationService expected = null; // TODO: Initialize to an appropriate value
            IFormsAuthenticationService actual;
            target.FormsService = expected;
            actual = target.FormsService;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A TestMethod for MembershipService
        ///</summary>
        [TestMethod]
        public void MembershipServiceTestMethod() {
            AccountController target = new AccountController(uow); // TODO: Initialize to an appropriate value
            IMembershipService expected = null; // TODO: Initialize to an appropriate value
            IMembershipService actual;
            target.MembershipService = expected;
            actual = target.MembershipService;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A TestMethod for RolService
        ///</summary>
        [TestMethod]
        public void RolServiceTestMethod() {
            AccountController target = new AccountController(uow); // TODO: Initialize to an appropriate value
            IRolService expected = null; // TODO: Initialize to an appropriate value
            IRolService actual;
            target.RolService = expected;
            actual = target.RolService;
            Assert.AreEqual(expected, actual);
        }
    }
}