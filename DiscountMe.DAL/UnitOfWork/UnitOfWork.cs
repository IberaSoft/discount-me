using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using DiscountMe.BL;
using DiscountMe.DAL.Repositories;

namespace DiscountMe.DAL {
    public class UnitOfWork : IUnitOfWork {
        private readonly DiscountMeDbContext objectContext;

        public UnitOfWork() : this(new DiscountMeDbContext()) {
        }

        private UnitOfWork(DiscountMeDbContext context) {
            if (objectContext == null)
                objectContext = context;
        }

        #region IDisposable members

        public void Dispose() {
            if (objectContext != null) {
                objectContext.Dispose();
            }
        }

        #endregion

        #region IUnitOfWork
        
        public void SaveChanges() {
            try {
                objectContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx) {
                foreach (var validationError in dbEx.EntityValidationErrors.SelectMany(validationErrors => validationErrors.ValidationErrors)) {
                    Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                }
            }
        }

        #endregion

        #region Repositorios

        private IRepositorio<Address> adresses;
        public IRepositorio<Address> Adresses {
            get {
                adresses = adresses ?? new AddressRepositorio(objectContext);
                return adresses;
            }
        }

        private IRepositorio<Advertiser> advertisers;
        public IRepositorio<Advertiser> Advertisers {
            get {
                advertisers = advertisers ?? new AdvertiserRepositorio(objectContext);
                return advertisers;
            }
        }

        private IRepositorio<City> cities;
        public IRepositorio<City> Cities {
            get {
                cities = cities ?? new CityRepositorio(objectContext);
                return cities;
            }
        }

        private IRepositorio<Country> countries;
        public IRepositorio<Country> Countries {
            get {
                countries = countries ?? new CountryRepositorio(objectContext);
                return countries;
            }
        }

        private IRepositorio<DiscountCategory> discountCategories;
        public IRepositorio<DiscountCategory> DiscountCategories {
            get {
                discountCategories = discountCategories ?? new DiscountCategoryRepositorio(objectContext);
                return discountCategories;
            }
        }

        private IRepositorio<Discount> discounts;
        public IRepositorio<Discount> Discounts {
            get {
                discounts = discounts ?? new DiscountRepositorio(objectContext);
                return discounts;
            }
        }

        private IRepositorio<Province> provinces;
        public IRepositorio<Province> Provinces {
            get {
                provinces = provinces ?? new ProvinceRepositorio(objectContext);
                return provinces;
            }
        }

        private IRepositorio<Rol> roles;
        public IRepositorio<Rol> Roles {
            get {
                roles = roles ?? new RolRepositorio(objectContext);
                return roles;
            }
        }

        private IRepositorio<User> users;
        public IRepositorio<User> Users {
            get {
                users = users ?? new UserRepositorio(objectContext);
                return users;
            }
        }

        #endregion
    }
}