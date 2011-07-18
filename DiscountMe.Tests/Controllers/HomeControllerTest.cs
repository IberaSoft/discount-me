using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DiscountMe;
using DiscountMe.BL;
using DiscountMe.Common;
using DiscountMe.Controllers;
using DiscountMe.DAL;
using DiscountMe.DependencyResolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StructureMap;

namespace DiscountMeMVC4.Tests {
    [TestClass]
    public class HomeControllerTest {
        private Mock<HttpContextBase> Context { get; set; }
        private IUnitOfWork uow;
        private const string UrlLegal = @"http://www.discountme.com";
        private const string UrlIlegal = @"http://localhost/Home";

        #region Test configurations

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

        [TestMethod]
        public void Index() {
            // Arrange
            HomeController controller = new HomeController(uow);
            //controller.ControllerContext = new ControllerContext(HttpContextMock.Object, new RouteData(), controller);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }


        [TestMethod]
        public void About() {
            // Arrange
            HomeController controller = new HomeController(uow);

            // Act
            ViewResult result = controller.Faqs() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Contact() {
            // Arrange
            HomeController controller = new HomeController(uow);

            // Act
            ViewResult result = controller.HowItWorks() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        /// <summary>
        ///A test for HomeController Constructor
        ///</summary>
        [TestMethod]
        public void HomeControllerConstructorTest() {
            // Arrange
            HomeController target = new HomeController(uow);
            
            // Assert
            Assert.IsNotNull(target);
            Assert.IsInstanceOfType(target, typeof(HomeController));
        }

        /// <summary>
        ///A test for Advertisers
        ///</summary>
        [TestMethod]
        public void AdvertisersTest() {
            // Arrange
            HomeController target = new HomeController(uow);

            // Act
            ActionResult actual = target.Advertisers();
            
            // Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
        }

        /// <summary>
        ///A test for DatosPosicion
        ///</summary>
        [TestMethod]
        public void DatosPosicionTest() {
            // Arrange
            HomeController target = new HomeController(uow);
            CreateMockForRequestObject(UrlLegal);
            target.ControllerContext = new ControllerContext(Context.Object, new RouteData(), target);

            // Act
            const string expected = "Avenida Miraflores de los Ángeles 3";

            GeoZone position = new GeoZone { Latitude = 36.729564, Longitude = -4.443079 };
            JsonResult actual = target.DatosPosicion(position);
            
            // Assert
            Assert.AreEqual(expected, actual.Data.ToString());
        }

        /// <summary>
        ///A test for Faqs
        ///</summary>
        [TestMethod]
        public void FaqsTest() {
            HomeController target = new HomeController(uow);
            ActionResult actual = target.Faqs();
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
        }

        /// <summary>
        ///A test for GetLatestDiscounts
        ///</summary>
        [TestMethod]
        public void GetLatestDiscountsTest() {
            HomeController target = new HomeController(uow);
            const int count = 1;
            PartialViewResult actual = target.GetLatestDiscounts(count);
            IEnumerable<Discount> discounts = actual.ViewData.Model as IEnumerable<Discount>;

            Assert.IsNotNull(discounts);
            Assert.AreEqual(count, discounts.Count());
        }

        /// <summary>
        ///A test for GetMapKey
        ///</summary>
        [TestMethod]
        public void GetMapKey_From_Legal_Url_Test() {
            // Arrange
            HomeController target = new HomeController(uow);
            CreateMockForRequestObject(UrlLegal);
            target.ControllerContext = new ControllerContext(Context.Object, new RouteData(), target);

            // Act
            const string expected = Constantes.BingMapsKey;
            JsonResult actual = target.GetMapKey();
            
            // Assert
            Assert.AreEqual(expected, actual.Data.ToString());
        }

        /// <summary>
        ///A test for GetMapKey
        ///</summary>
        [TestMethod]
        public void GetMapKey_From_Illegal_Url_Test() {
            // Arrange
            HomeController target = new HomeController(uow);
            CreateMockForRequestObject(UrlIlegal);
            target.ControllerContext = new ControllerContext(Context.Object, new RouteData(), target);

            // Act
            const string expected = "Invalid request";
            JsonResult actual = target.GetMapKey();

            // Assert
            Assert.AreEqual(expected, actual.Data.ToString());
        }
    }
}