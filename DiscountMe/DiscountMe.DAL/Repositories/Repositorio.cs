using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DiscountMe.DAL.Repositories {
    public abstract class Repositorio<T> : IRepositorio<T> where T : class, new() {
        protected readonly IDbSet<T> ObjectSet;
        protected readonly DiscountMeDbContext Context;

        protected Repositorio(DiscountMeDbContext objectContext, IDbSet<T> objectSet) {
            ObjectSet = objectSet;
            Context = objectContext;
        }

        public T Crear() {
            return new T();
        }

        public void Agregar(T entity) {
            ObjectSet.Add(entity);
        }

        public void Eliminar(T entity) {
            ObjectSet.Remove(entity);
        }

        public void Modificar(T entity) {
            ObjectSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public abstract T Obtener(int id);

        public abstract IEnumerable<T> Consulta(Expression<Func<T, bool>> filter);

        public abstract IEnumerable<T> Lista();

        #region IDisposable region
        
        public void Dispose() {
            if (Context != null)
                Context.Dispose();
        }
        
        #endregion
    }
}