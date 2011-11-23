using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DiscountMe.BL;

namespace DiscountMe.DAL.Repositories {
    public class UserRepositorio : Repositorio<User> {
        public UserRepositorio(DiscountMeDbContext objectContext) : base(objectContext) {
        }

        public override User Obtener(int id) {
            return ObjectSet.SingleOrDefault(u => u.Id == id);
        }

        public override IEnumerable<User> Consulta(Expression<Func<User, bool>> filter) {
            return ObjectSet.Where(filter).AsEnumerable();
        }

        public override IEnumerable<User> Lista() {
            return ObjectSet.AsEnumerable();
        }
    }
}