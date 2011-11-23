using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DiscountMe.BL;

namespace DiscountMe.DAL.Repositories {
    public class ProvinceRepositorio : Repositorio<Province> {
        public ProvinceRepositorio(DiscountMeDbContext objectContext) : base(objectContext) {
        }

        public override Province Obtener(int id) {
            return ObjectSet.SingleOrDefault(province => province.Id == id);
        }

        public override IEnumerable<Province> Consulta(Expression<Func<Province, bool>> filter) {
            return ObjectSet.Where(filter).ToList();
        }

        public override IEnumerable<Province> Lista() {
            return ObjectSet.ToList();
        }
    }
}