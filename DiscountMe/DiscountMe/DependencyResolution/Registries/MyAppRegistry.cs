using System.Web.Mvc;
using System.Web.Security;
using DiscountMe.BL;
using DiscountMe.DAL;
using DiscountMe.DAL.Repositories;
using DiscountMe.Infrastructure;
using StructureMap.Configuration.DSL;

namespace DiscountMe.DependencyResolution.Registries {
    public class MyAppRegistry : Registry {
        public MyAppRegistry() {
            For<IUnitOfWork>().HybridHttpOrThreadLocalScoped().Use<UnitOfWork>();
            For<IRepositorio<Address>>().Use<AddressRepositorio>();
            For<IRepositorio<Advertiser>>().Use<AdvertiserRepositorio>();
            For<IRepositorio<City>>().Use<CityRepositorio>();
            For<IRepositorio<Country>>().Use<CountryRepositorio>();
            For<IRepositorio<DiscountCategory>>().Use<DiscountCategoryRepositorio>();
            For<IRepositorio<Discount>>().Use<DiscountRepositorio>();
            For<IRepositorio<Province>>().Use<ProvinceRepositorio>();
            For<IRepositorio<Rol>>().Use<RolRepositorio>();
            For<IRepositorio<User>>().Use<UserRepositorio>();
            //ForConcreteType<UnitOfWork>().Configure.Setter<IRepositorio<Address>>().Is<AddressRepositorio>();
            //ForConcreteType<UnitOfWork>().Configure.Setter<IRepositorio<Advertiser>>().Is(new AdvertiserRepositorio(new DiscountMeDbContext()));
            //ForConcreteType<UnitOfWork>().Configure.Setter<IRepositorio<City>>().Is(new CityRepositorio(new DiscountMeDbContext()));
            //ForConcreteType<UnitOfWork>().Configure.Setter<IRepositorio<Country>>().Is(new CountryRepositorio(new DiscountMeDbContext()));
            //ForConcreteType<UnitOfWork>().Configure.Setter<IRepositorio<DiscountCategory>>().Is(new DiscountCategoryRepositorio(new DiscountMeDbContext()));
            //ForConcreteType<UnitOfWork>().Configure.Setter<IRepositorio<Discount>>().Is(new DiscountRepositorio(new DiscountMeDbContext()));
            //ForConcreteType<UnitOfWork>().Configure.Setter<IRepositorio<GeoZone>>().Is(new GeoZoneRepositorio(new DiscountMeDbContext()));
            //ForConcreteType<UnitOfWork>().Configure.Setter<IRepositorio<Preference>>().Is(new PreferenceRepositorio(new DiscountMeDbContext()));
            //ForConcreteType<UnitOfWork>().Configure.Setter<IRepositorio<Province>>().Is(new ProvinceRepositorio(new DiscountMeDbContext()));
            //ForConcreteType<UnitOfWork>().Configure.Setter<IRepositorio<Rol>>().Is(new RolRepositorio(new DiscountMeDbContext()));
            //ForConcreteType<UnitOfWork>().Configure.Setter<IRepositorio<UserPreferences>>().Is(new UserPreferencesRepositorio(new DiscountMeDbContext()));
            //ForConcreteType<UnitOfWork>().Configure.Setter<IRepositorio<User>>().Is(new UserRepositorio(new DiscountMeDbContext()));
            For<IControllerActivator>().Use<SMControllerActivator>();
            For<IFormsAuthenticationService>().Use<FormsAuthenticationService>();
            For<IMembershipService>().Use<AccountMembershipService>();
            For<MembershipProvider>().Use<CustomMembershipProvider>();
        }
    }
}