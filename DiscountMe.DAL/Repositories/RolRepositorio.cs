using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DiscountMe.BL;

namespace DiscountMe.DAL.Repositories {
    public class RolRepositorio : Repositorio<Rol> {
        public RolRepositorio(DiscountMeDbContext objectContext) : base(objectContext) {
        }

        public override Rol Obtener(int id) {
            return ObjectSet.SingleOrDefault(r => r.Id == id);
        }

        public override IEnumerable<Rol> Consulta(Expression<Func<Rol, bool>> filter) {
            return ObjectSet.Where(filter).ToList();
        }

        public override IEnumerable<Rol> Lista() {
            return ObjectSet.ToList();
        }
    }
}