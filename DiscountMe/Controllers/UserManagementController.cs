using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DiscountMe.BL.ViewModels;
using DiscountMe.DAL;
using DiscountMe.BL;

namespace DiscountMe.Controllers {
    [Authorize]
    public class UserManagementController : Controller {
        private readonly IUnitOfWork uow;

        public UserManagementController(IUnitOfWork uoW) {
            uow = uoW;
        }

        public static IList<Discount> GetLatestDiscounts(IUnitOfWork uoW, int count) {
            return uoW.Discounts.Lista().OrderBy(d => d.FromDate).Take(count).ToList();
        }

        //
        // GET: /UserManagement/
        public ActionResult Index(int page = 1) {
            var modelo = new UsuarioAdministracionViewModel();
            return View(modelo);
        }

        //
        // GET: /UserManagement/UpdateCategories
        public ActionResult UpdateCategories() {
            var modelo = new UsuarioAdministracionViewModel();
            return View(modelo);
        }

        //
        // POST: /UserManagement/UpdateCategories
        [HttpPost]
        public ActionResult UpdateCategories(User user) {
            try {
                // TODO: Agregar la logica para guardar la seleccion de categorias del usuario en preferencias
                
                //foreach (var pref in user) {
                //    uow.Preferences.Agregar(pref);
                //}
                uow.SaveChanges();
                return RedirectToAction("Index", "UserManagement");
            }
            catch {
                return View();
            }
        }

        //
        // GET: /UserManagement/UpdateAdvertisers
        public ActionResult UpdateAdvertisers() {
            var modelo = new UsuarioAdministracionViewModel();
            modelo.Advertisers = uow.Advertisers.Lista().OrderBy(ad => ad.Name).ToList();
            return View(modelo);
        }

        //
        // POST: /UserManagement/UpdateAdvertisers
        [HttpPost]
        public ActionResult UpdateAdvertisers(FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        //
        // GET: /UserManagement/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        //
        // POST: /UserManagement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}