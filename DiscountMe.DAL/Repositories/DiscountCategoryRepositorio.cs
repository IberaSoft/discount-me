using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DiscountMe.BL;

namespace DiscountMe.DAL.Repositories {
    public class DiscountCategoryRepositorio : Repositorio<DiscountCategory> {
        public DiscountCategoryRepositorio(DiscountMeDbContext objectContext) : base(objectContext) {
        }

        public override DiscountCategory Obtener(int id) {
            return ObjectSet.SingleOrDefault(dc => dc.Id == id);
        }

        public override IEnumerable<DiscountCategory> Consulta(Expression<Func<DiscountCategory, bool>> filter) {
            return ObjectSet.Where(filter).ToList();
        }

        public override IEnumerable<DiscountCategory> Lista() {
            return ObjectSet.ToList();
        }
    }
}