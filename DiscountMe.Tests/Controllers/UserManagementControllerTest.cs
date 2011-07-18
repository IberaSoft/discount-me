using System;
using System.Web;
using DiscountMe;
using DiscountMe.Controllers;
using DiscountMe.DAL;
using System.Web.Mvc;
using DiscountMe.BL;
using System.Collections.Generic;
using DiscountMe.DependencyResolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StructureMap;

namespace DiscountMeMVC4.Tests {
    /// <summary>
    ///This is a test class for UserManagementControllerTest and is intended
    ///to contain all UserManagementControllerTest Unit Tests
    ///</summary>
    [TestClass]
    public class UserManagementControllerTest {
        private Mock<HttpContextBase> Context { get; set; }
        private IUnitOfWork uow;

        #region Test configurations

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void FixtureSetUp(TestContext context) {
            ControllerBuilder.Current.SetControllerFactory(typeof(SMControllerFactory));
            DependencyResolver.SetResolver(new SMDependencyResolver(IoC.Initialize()));
        }

        private void CreateMockForRequestObject(string url) {
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
        ///A test for UserManagementController Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod]
        public void UserManagementControllerConstructorTest() {
            UserManagementController target = new UserManagementController(uow);

            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod]
        public void DeleteTest() {
            UserManagementController target = new UserManagementController(uow);
                // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Delete(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod]
        public void DeleteTest1() {
            UserManagementController target = new UserManagementController(uow);
                // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            FormCollection collection = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Delete(id, collection);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetLatestDiscounts
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod]
        public void GetLatestDiscountsTest() {
            int count = 0; // TODO: Initialize to an appropriate value
            IList<Discount> expected = null; // TODO: Initialize to an appropriate value
            IList<Discount> actual;
            actual = UserManagementController.GetLatestDiscounts(uow, count);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Index
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod]
        public void IndexTest() {
            UserManagementController target = new UserManagementController(uow);
                // TODO: Initialize to an appropriate value
            int page = 0; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Index(page);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateAdvertisers
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod]
        public void UpdateAdvertisersTest() {
            UserManagementController target = new UserManagementController(uow);
                // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.UpdateAdvertisers();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateAdvertisers
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod]
        public void UpdateAdvertisersTest1() {
            UserManagementController target = new UserManagementController(uow);
                // TODO: Initialize to an appropriate value
            FormCollection collection = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.UpdateAdvertisers(collection);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateCategories
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod]
        public void UpdateCategoriesTest() {
            UserManagementController target = new UserManagementController(uow);
                // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.UpdateCategories();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateCategories
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod]
        public void UpdateCategoriesTest1() {
            UserManagementController target = new UserManagementController(uow);
                // TODO: Initialize to an appropriate value
            User user = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.UpdateCategories(user);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}