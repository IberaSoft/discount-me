using System.Web.Mvc;
using System.Web.Security;
using DiscountMe.BL;
using DiscountMe.BL.Validaciones;
using DiscountMe.BL.ViewModels;
using DiscountMe.DAL;
using DiscountMe.DAL.Repositories;
using DiscountMe.Infrastructure;
using DiscountMe.Infrastructure.Services;
using FluentValidation;
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
            For<IControllerActivator>().Use<SMControllerActivator>();
            For<IFormsAuthenticationService>().Use<FormsAuthenticationService>();
            For<IRolService>().Use<RolServiceLayer>();
            For<IMembershipService>().Use<AccountMembershipService>();
            For<MembershipProvider>().Use<CustomMembershipProvider>();
            For<RoleProvider>().Use<CustomMembershipRoleProvider>();
            For<ModelMetadataProvider>().Use(ModelMetadataProviders.Current);
            For<IFormsAuthenticationService>().Use<FormsAuthenticationService>();
            For<IValidator<Address>>().Singleton().Use<AddressValidator>();
            For<IValidator<Advertiser>>().Singleton().Use<AdvertiserValidator>();
            For<IValidator<AdvertiserVM>>().Singleton().Use<AdvertiserVMValidator>();
            For<IValidator<City>>().Singleton().Use<CityValidator>();
            For<IValidator<Country>>().Singleton().Use<CountryValidator>();
            For<IValidator<DiscountCategory>>().Singleton().Use<DiscountCategoryValidator>();
            For<IValidator<Discount>>().Singleton().Use<DiscountValidator>();
            For<IValidator<LogOnVM>>().Singleton().Use<LogOnVMValidator>();
            For<IValidator<Province>>().Singleton().Use<ProvinceValidator>();
            For<IValidator<Rol>>().Singleton().Use<RolValidator>();
            For<IValidator<UserPreferences>>().Singleton().Use<UserPreferencesValidator>();
            For<IValidator<User>>().Singleton().Use<UserValidator>();
            SetAllProperties(x => x.OfType<IRepositorio<Address>>());
            SetAllProperties(x => x.OfType<IRepositorio<Advertiser>>());
            SetAllProperties(x => x.OfType<IRepositorio<City>>());
            SetAllProperties(x => x.OfType<IRepositorio<Country>>());
            SetAllProperties(x => x.OfType<IRepositorio<DiscountCategory>>());
            SetAllProperties(x => x.OfType<IRepositorio<Discount>>());
            SetAllProperties(x => x.OfType<IRepositorio<Province>>());
            SetAllProperties(x => x.OfType<IRepositorio<Rol>>());
            SetAllProperties(x => x.OfType<IRepositorio<User>>());
        }
    }
}