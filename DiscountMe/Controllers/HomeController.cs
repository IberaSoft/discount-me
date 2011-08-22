using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using DiscountMe.BL;
using DiscountMe.BL.ViewModels;
using DiscountMe.Common;
using DiscountMe.DAL;

namespace DiscountMe.Controllers {
    [AllowAnonymous]
    public class HomeController : Controller {
        private readonly IUnitOfWork uow;
        readonly XNamespace nameSpace = XNamespace.Get(@"http://schemas.microsoft.com/search/local/ws/rest/v1");

        public HomeController(IUnitOfWork uoW) {
            uow = uoW;
        }

        [AllowAnonymous]
        public ActionResult Index() {
            return View();
        }

        [AllowAnonymous]
        public ActionResult HowItWorks() {
            return View();
        }

        public ActionResult Advertisers() {
            return View();
        }

        public ActionResult Faqs() {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult GetLatestDiscounts(int count) {
            return PartialView(uow.Discounts.Lista().OrderBy(d => d.FromDate).Take(count).ToList());
        }

        [HttpPost]
        public JsonResult GetMapKey() {
            if (ValidRequest())
                return Json(Constantes.BingMapsKey);
            return Json("Invalid request");
        }

        private bool ValidRequest() {
            var canCall = true;
            if (Request.UrlReferrer == null) {
                canCall = false;
            }
            else {
                if (Request.UrlReferrer.ToString().Contains("Home")) {
                    return false;
                }
            }
            return canCall;
        }

        [HttpPost]
        public JsonResult DatosPosicion(GeoZone position) {
            if (ValidRequest()) {
                var request = WebRequest.Create(CreateBingMapsApiRequest(position));
                // Get the response.
                var response = (HttpWebResponse)request.GetResponse();
                var dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                var reader = new StreamReader(dataStream);
                // Read the content.
                var documento = XDocument.Parse(reader.ReadToEnd());
                var sets = documento.Descendants().Elements(nameSpace + "Address").FirstOrDefault();
                var direccion = GetAddress(sets);
                return Json(direccion);
            }
            return Json("Invalid request");
        }

        private string CreateBingMapsApiRequest(GeoZone position) {
            var sb = new StringBuilder(@"http://dev.virtualearth.net/REST/v1/Locations/");
            sb.Append(position.Latitude.ToString(CultureInfo.InvariantCulture) + ",");
            sb.Append(position.Longitude.ToString(CultureInfo.InvariantCulture) + "?c=es&o=xml&key=" + Constantes.BingMapsKey);
            return sb.ToString();
        }

        private DireccionBingMaps GetAddress(XElement sets) {
            return new DireccionBingMaps {
                                     AddressLine = InvertirNumeroCalle((string)sets.Element(nameSpace + "AddressLine")),
                                     AdminDistrict = (string)sets.Element(nameSpace + "AdminDistrict"),
                                     AdminDistrict2 = (string)sets.Element(nameSpace + "AdminDistrict2"),
                                     CountryRegion = (string)sets.Element(nameSpace + "CountryRegion"),
                                     FormattedAddress = (string)sets.Element(nameSpace + "FormattedAddress"),
                                     Locality = (string)sets.Element(nameSpace + "Locality"),
                                     PostalCode = (string)sets.Element(nameSpace + "PostalCode")
                                 };
        }

        private string InvertirNumeroCalle(string calle) {
            var pos = calle.IndexOf(' ');
            if (pos != -1) {
                int numero;
                if (int.TryParse(calle.Substring(0, pos), out numero)) {
                    var nombreCalle = calle.Substring(++pos);
                    return nombreCalle + " " + numero;
                }
                return calle;
            }
            return calle;
        }
    }
}