using System;
using DiscountMe.BL;

namespace DiscountMe.DAL {
    public interface IUnitOfWork : IDisposable {
        IRepositorio<Address> Adresses { get; }

        IRepositorio<Advertiser> Advertisers { get; }

        IRepositorio<City> Cities { get; }

        IRepositorio<Country> Countries { get; }

        IRepositorio<DiscountCategory> DiscountCategories { get; }

        IRepositorio<Discount> Discounts { get; }

        IRepositorio<Province> Provinces { get; }

        IRepositorio<Rol> Roles { get; }

        IRepositorio<User> Users { get; }

        void SaveChanges();
    }
}