using System.Web.Mvc;
using System.Web.Routing;
using DiscountMe.Infrastructure;
using DiscountMe.Infrastructure.Services;

namespace DiscountMe.Areas.Admin.Controllers {
    [Authorize]
    public class AdminController : Controller {
        private RolServiceLayer rolService;
        private MembershipServiceLayer userService;
        private const int PageSize = 10;

        protected override void Initialize(RequestContext requestContext) {
            base.Initialize(requestContext);
            userService = DependencyResolver.Current.GetService<MembershipServiceLayer>();
            rolService = DependencyResolver.Current.GetService<RolServiceLayer>();
        }

        //
        // GET: /Admin/Admin/
        public ActionResult Index() {
            int? page = null;
            var users = userService.GetAllUsers(page ?? 1, PageSize);
            return View(users);
        }

        //
        // GET: /Admin/Admin/Details/5
        //public ActionResult Details(int id) {
        //    return View();
        //}

        ////
        //// GET: /Admin/Admin/Create
        //public ActionResult Create() {
        //    return View();
        //}

        ////
        //// POST: /Admin/Admin/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection) {
        //    try {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch {
        //        return View();
        //    }
        //}

        ////
        //// GET: /Admin/Admin/Edit/5
        //public ActionResult Edit(int id) {
        //    return View();
        //}

        ////
        //// POST: /Admin/Admin/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection) {
        //    try {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch {
        //        return View();
        //    }
        //}

        ////
        //// GET: /Admin/Admin/Delete/5
        //public ActionResult Delete(int id) {
        //    return View();
        //}

        ////
        //// POST: /Admin/Admin/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection) {
        //    try {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch {
        //        return View();
        //    }
        //}
    }
}