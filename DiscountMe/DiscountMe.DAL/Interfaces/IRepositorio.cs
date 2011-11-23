using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DiscountMe.DAL {
    public interface IRepositorio<T> : IDisposable where T : class {
        T Crear();
        void Agregar(T entity);
        void Eliminar(T entity);
        void Modificar(T entity);
        T Obtener(int id);
        IEnumerable<T> Consulta(Expression<Func<T, bool>> filter);
        IEnumerable<T> Lista();
    }
}