using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DiscountMe.BL;
using DiscountMe.BL.ViewModels;
using DiscountMe.DAL;

namespace DiscountMe.Controllers {
    [Authorize]
    public class AdvertisersManagementController : Controller {
        private readonly IUnitOfWork uow;

        public AdvertisersManagementController(IUnitOfWork uoW) {
            uow = uoW;
        }

        public static IList<Discount> GetLatestDiscounts(IUnitOfWork uoW, int count) {
            return uoW.Discounts.Lista().OrderBy(d => d.FromDate).Take(count).ToList();
        }

        //
        // GET: /AdvertisersManagement/
        public ActionResult Index() {
            var modelo = new AdvertiserAdministracionViewModel {
                                                                   GetLatestDiscounts = GetLatestDiscounts(uow, 5),
                                                                   Categories = uow.DiscountCategories.Lista().OrderBy(dc => dc.Name).ToList()
                                                               };
            return View(modelo);
        }

        //
        // GET: /AdvertisersManagement/Create
        public ActionResult Create() {
            var discount = new DiscountVM {
                Discount = uow.Discounts.Crear(),
                DiscountCategories = uow.DiscountCategories.Lista().OrderBy(p => p.Name).ToList()
            };
            return View(discount);
        }

        //
        // POST: /AdvertisersManagement/Create
        [HttpPost]
        public ActionResult Create(DiscountVM oferta) {
            try {
                var usuario = uow.Advertisers.Consulta(a => a.Name == User.Identity.Name).SingleOrDefault();
                var categoria = uow.DiscountCategories.Obtener(oferta.SelectedCategoryId);
                oferta.Discount.Advertiser = usuario;
                oferta.Discount.DiscountCategory = categoria;
                if (oferta.Discount.IsValid) {
                    uow.Discounts.Agregar(oferta.Discount);
                    uow.SaveChanges();
                    return RedirectToAction("Index", "AdvertisersManagement");
                }
                oferta.DiscountCategories = uow.DiscountCategories.Lista().OrderBy(p => p.Name).ToList();
                return View(oferta);
            }
            catch (Exception ex) {
                oferta.DiscountCategories = uow.DiscountCategories.Lista().OrderBy(p => p.Name).ToList();
                return View(oferta);
            }
        }

        //
        // GET: /AdvertisersManagement/Edit/1
        public ActionResult Edit(int id) {
            var oferta = uow.Discounts.Obtener(id);
            var model = new DiscountVM {
                                           Discount = oferta,
                                           DiscountCategories = uow.DiscountCategories.Lista().OrderBy(c => c.Name).ToList(),
                                           SelectedCategoryId = oferta.DiscountCategory.Id
                                       };
            return View(model);
        }

        //
        // POST: /AdvertisersManagement/Edit/1
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            var model = new DiscountVM {
                Discount = uow.Discounts.Obtener(id),
                DiscountCategories = uow.DiscountCategories.Lista().OrderBy(c => c.Name).ToList(),
                SelectedCategoryId = int.Parse(collection["SelectedCategoryId"])
            };
            try {
                var usuario = uow.Advertisers.Consulta(a => a.Name == User.Identity.Name).SingleOrDefault();
                var categoria = uow.DiscountCategories.Obtener(model.SelectedCategoryId);
                model.Discount.Advertiser = usuario;
                model.Discount.DiscountCategory = categoria;
                if (model.Discount.IsValid) {
                    UpdateModel(model.Discount, "Discount");
                    uow.Discounts.Modificar(model.Discount);
                    uow.SaveChanges();
                    return RedirectToAction("Index", "AdvertisersManagement");
                }
                model.DiscountCategories = uow.DiscountCategories.Lista().OrderBy(c => c.Name).ToList();
                return View(model);
            }
            catch (Exception ex) {
                model.DiscountCategories = uow.DiscountCategories.Lista().OrderBy(c => c.Name).ToList();
                return View(model);
            }
        }

        //
        // GET: /AdvertisersManagement/Delete/
        public ActionResult Delete(int id) {
            return View(uow.Discounts.Obtener(id));
        }

        //
        // POST: /AdvertisersManagement/Delete/
        [HttpPost]
        public ActionResult Delete(Discount oferta) {
            try {
                var discount = uow.Discounts.Obtener(oferta.Id);
                uow.Discounts.Eliminar(discount);
                uow.SaveChanges();
                return RedirectToAction("Index", "AdvertisersManagement");
            }
            catch (Exception ex) {
                return View(oferta);
            }
        }
    }
}