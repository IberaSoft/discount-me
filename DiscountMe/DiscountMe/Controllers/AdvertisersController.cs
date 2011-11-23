using System.Web.Mvc;
using DiscountMe.DAL;

namespace DiscountMe.Controllers {
    public class AdvertisersController : Controller {
        private readonly IUnitOfWork uow;

        public AdvertisersController(IUnitOfWork uoW) {
            uow = uoW;
        }

        //
        // GET: /Advertisers/

        public ActionResult Index() {
            return View();
        }

    }
}