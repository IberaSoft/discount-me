﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DiscountMe.BL;

namespace DiscountMe.DAL.Repositories {
    public class DiscountRepositorio : Repositorio<Discount> {
        public DiscountRepositorio(DiscountMeDbContext objectContext) : base(objectContext) {
        }

        public override Discount Obtener(int id) {
            return ObjectSet.SingleOrDefault(d => d.Id == id);
        }

        public override IEnumerable<Discount> Consulta(Expression<Func<Discount, bool>> filter) {
            return ObjectSet.Where(filter).ToList();
        }

        public override IEnumerable<Discount> Lista() {
            return ObjectSet.ToList();
        }
    }
}