using System;
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
    public class HomeController : Controller {
        private IUnitOfWork uow;

        public HomeController(IUnitOfWork uoW) {
            uow = uoW;
        }

        public ActionResult Index() {
            return View();
        }

        public ActionResult HowItWorks() {
            return View();
        }

        public ActionResult Advertisers() {
            return View();
        }

        public ActionResult Faqs() {
            return View();
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
                var sb = new StringBuilder(@"http://dev.virtualearth.net/REST/v1/Locations/");
                sb.Append(position.Latitude.ToString(CultureInfo.InvariantCulture) + ",");
                sb.Append(position.Longitude.ToString(CultureInfo.InvariantCulture) + "?c=es&o=xml&key=" + Constantes.BingMapsKey);
                var request = WebRequest.Create(sb.ToString());
                // Get the response.
                var response = (HttpWebResponse)request.GetResponse();
                var dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                var reader = new StreamReader(dataStream);
                // This is the namespace of the xml we receive
                var nameSpace = XNamespace.Get("http://schemas.microsoft.com/search/local/ws/rest/v1");
                // Read the content.
                var documento = XDocument.Parse(reader.ReadToEnd());
                var sets = documento.Descendants().Elements(nameSpace + "Address").FirstOrDefault();
                var direccion = new Direccion {
                                                  AddressLine = InvertirNumeroCalle((string)sets.Element(nameSpace + "AddressLine")),
                                                  AdminDistrict = (string)sets.Element(nameSpace + "AdminDistrict"),
                                                  AdminDistrict2 = (string)sets.Element(nameSpace + "AdminDistrict2"),
                                                  CountryRegion = (string)sets.Element(nameSpace + "CountryRegion"),
                                                  FormattedAddress = (string)sets.Element(nameSpace + "FormattedAddress"),
                                                  Locality = (string)sets.Element(nameSpace + "Locality"),
                                                  PostalCode = (string)sets.Element(nameSpace + "PostalCode")
                                              };
                return Json(direccion);
            }
            return Json("Invalid request");
        }

        private static string InvertirNumeroCalle(string calle) {
            var pos = calle.IndexOf(' ');
            if (pos != -1) {
                var numero = calle.Substring(0, pos);
                var nombreCalle = calle.Substring(++pos);
                return nombreCalle + " " + numero;
            }
            return calle;
        }

        private class Direccion {
            public string AddressLine { get; set; }
            public string AdminDistrict { get; set; }
            public string AdminDistrict2 { get; set; }
            public string CountryRegion { get; set; }
            public string FormattedAddress { get; set; }
            public string Locality { get; set; }
            public string PostalCode { get; set; }
        }
    }
}