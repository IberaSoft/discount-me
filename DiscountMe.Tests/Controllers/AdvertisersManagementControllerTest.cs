using System;
using System.Web;
using DiscountMe;
using DiscountMe.Controllers;
using DiscountMe.DAL;
using System.Web.Mvc;
using DiscountMe.BL.ViewModels;
using DiscountMe.BL;
using DiscountMe.DependencyResolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StructureMap;

namespace DiscountMeMVC4.Tests {
    /// <summary>
    ///This is a test class for AdvertisersManagementControllerTest and is intended
    ///to contain all AdvertisersManagementControllerTest Unit Tests
    ///</summary>
    [TestClass]
    public class AdvertisersManagementControllerTest {
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
        ///A test for AdvertisersManagementController Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod]
        public void AdvertisersManagementControllerConstructorTest() {
            AdvertisersManagementController target = new AdvertisersManagementController(uow);

            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for Create
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod]
        public void CreateTest() {
            AdvertisersManagementController target = new AdvertisersManagementController(uow);
                // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Create();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Create
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod]
        public void CreateTest1() {
            AdvertisersManagementController target = new AdvertisersManagementController(uow);
                // TODO: Initialize to an appropriate value
            DiscountVM oferta = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Create(oferta);
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
        public void DeleteTest() {
            AdvertisersManagementController target = new AdvertisersManagementController(uow);
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
            AdvertisersManagementController target = new AdvertisersManagementController(uow);
                // TODO: Initialize to an appropriate value
            Discount oferta = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Delete(oferta);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Edit
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod]
        public void EditTest() {
            AdvertisersManagementController target = new AdvertisersManagementController(uow);
                // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Edit(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Edit
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod]
        public void EditTest1() {
            AdvertisersManagementController target = new AdvertisersManagementController(uow);
                // TODO: Initialize to an appropriate value
            int id = 0; // TODO: Initialize to an appropriate value
            FormCollection collection = null; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Edit(id, collection);
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
            AdvertisersManagementController target = new AdvertisersManagementController(uow);
                // TODO: Initialize to an appropriate value
            int page = 0; // TODO: Initialize to an appropriate value
            ActionResult expected = null; // TODO: Initialize to an appropriate value
            ActionResult actual;
            actual = target.Index(page);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}