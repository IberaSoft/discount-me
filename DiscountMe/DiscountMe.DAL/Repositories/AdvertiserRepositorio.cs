using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DiscountMe.BL;

namespace DiscountMe.DAL.Repositories {
    public class AdvertiserRepositorio : Repositorio<Advertiser > {
        public AdvertiserRepositorio(DiscountMeDbContext objectContext) : base(objectContext, objectContext.Advertisers) {
        }

        public override Advertiser Obtener(int id) {
            return ObjectSet.SingleOrDefault(ad => ad.Id == id);
        }

        public override IEnumerable<Advertiser> Consulta(Expression<Func<Advertiser, bool>> filter) {
            return ObjectSet.Where(filter).ToList();
        }

        public override IEnumerable<Advertiser> Lista() {
            return ObjectSet.ToList();
        }
    }
}