using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DiscountMe.BL;

namespace DiscountMe.DAL.Repositories {
    public class CityRepositorio : Repositorio<City> {
        public CityRepositorio(DiscountMeDbContext objectContext) : base(objectContext, objectContext.Cities) {
        }

        public override City Obtener(int id) {
            return ObjectSet.SingleOrDefault(c => c.Id == id);
        }

        public override IEnumerable<City> Consulta(Expression<Func<City, bool>> filter) {
            return ObjectSet.Where(filter).ToList();
        }

        public override IEnumerable<City> Lista() {
            return ObjectSet.ToList();
        }
    }
}