using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccessCorpFormulario.Infrastructure.Database.CodeFirst.Interfaces
{
    public interface IRepositorioBase<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);       
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count();
    }
}
