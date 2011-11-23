using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DiscountMe.BL;

namespace DiscountMe.DAL.Repositories {
    public class AddressRepositorio : Repositorio<Address> {
        public AddressRepositorio(DiscountMeDbContext objectContext) : base(objectContext, objectContext.Address) {
        }

        public override Address Obtener(int id) {
            return ObjectSet.SingleOrDefault(a => a.Id == id);
        }

        public override IEnumerable<Address> Consulta(Expression<Func<Address, bool>> filter) {
            return ObjectSet.Where(filter).ToList();
        }

        public override IEnumerable<Address> Lista() {
            return ObjectSet.ToList();
        }
    }
}