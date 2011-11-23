using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DiscountMe.BL;

namespace DiscountMe.DAL.Repositories {
    public class CountryRepositorio : Repositorio<Country> {
        public CountryRepositorio(DiscountMeDbContext objectContext) : base(objectContext) {
        }

        public override Country Obtener(int id) {
            return ObjectSet.SingleOrDefault(c => c.Id == id);
        }

        public override IEnumerable<Country> Consulta(Expression<Func<Country, bool>> filter) {
            return ObjectSet.Where(filter).ToList();
        }

        public override IEnumerable<Country> Lista() {
            return ObjectSet.ToList();
        }
    }
}