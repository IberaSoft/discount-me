using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DiscountMe.BL;
using DiscountMe.DAL;
using DiscountMe.DAL.Repositories;

namespace DiscountMe.Dal.Repositories {
    class UserPreferencesRepositorio : Repositorio<UserPreferences> {
        public UserPreferencesRepositorio(DiscountMeDbContext objectContext) : base(objectContext) {
        }

        public override UserPreferences Obtener(int id) {
            return ObjectSet.SingleOrDefault(p => p.Id == id);
        }

        public override IEnumerable<UserPreferences> Consulta(Expression<Func<UserPreferences, bool>> filter) {
            return ObjectSet.Where(filter).ToList();
        }

        public override IEnumerable<UserPreferences> Lista() {
            return ObjectSet.ToList();
        }
    }
}