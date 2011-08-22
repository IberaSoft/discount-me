using System;
using System.Linq;
using System.Web.Mvc;
using DiscountMe.BL;
using DiscountMe.BL.ViewModels;
using DiscountMe.DAL;
using DiscountMe.Infrastructure;

namespace DiscountMe.Controllers {
    [Authorize]
    public class AdvertisersManagementController : Controller {
        private readonly IUnitOfWork uow;
        public int ProductsPerPage = 15;

        public AdvertisersManagementController(IUnitOfWork uoW) {
            uow = uoW;
        }

        //
        // GET: /AdvertisersManagement/
        public ActionResult Index(int page = 1) {
            var ci = ControllerContext.HttpContext.User.Identity as CustomIdentity;
            var modelo = new AdvertiserAdministracionViewModel {
                GetDiscounts = uow.Discounts
                    .Consulta(d => d.Advertiser.Id == ci.Id).Skip((page - 1) * ProductsPerPage).Take(ProductsPerPage).ToList(),
                PagingInfo = new PagingInfo {
                    CurrentPage = page,
                    ItemsPerPage = ProductsPerPage,
                    TotalItems = uow.Discounts.Consulta(d => d.Advertiser.Id == ci.Id).Count(),
                },
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
                var categoria = uow.DiscountCategories.Obtener(oferta.SelectedCategoryId);
                oferta.Discount.Advertiser = GetAnunciante();
                oferta.Discount.DiscountCategory = categoria;
                if (oferta.Discount.IsValid) {
                    uow.Discounts.Agregar(oferta.Discount);
                    uow.SaveChanges();
                    return RedirectToAction("Index", "AdvertisersManagement");
                }
                oferta.DiscountCategories = uow.DiscountCategories.Lista().OrderBy(p => p.Name).ToList();
                return View(oferta);
            }
            catch (Exception) {
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
                var categoria = uow.DiscountCategories.Obtener(model.SelectedCategoryId);
                model.Discount.Advertiser = GetAnunciante();
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
            catch (Exception) {
                model.DiscountCategories = uow.DiscountCategories.Lista().OrderBy(c => c.Name).ToList();
                return View(model);
            }
        }

        private Advertiser GetAnunciante() {
            var ci = (CustomIdentity)ControllerContext.HttpContext.User.Identity;
            var idUsuario = ci.Id;
            var usuario = uow.Advertisers.Obtener(idUsuario);
            return usuario;
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
            catch (Exception) {
                return View(oferta);
            }
        }
    }
}