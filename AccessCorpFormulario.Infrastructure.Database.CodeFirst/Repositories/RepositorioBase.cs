using AccessCorpFormulario.Infrastructure.Database.CodeFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccessCorpFormulario.Infrastructure.Database.CodeFirst.Repositories
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        private AccessCorpContext m_Context = null;

        DbSet<T> m_DbSet;

        public RepositorioBase(AccessCorpContext context)
        {
            m_Context = context;
            m_DbSet = m_Context.Set<T>();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return m_DbSet.Where(predicate);
            }
            return m_DbSet.AsEnumerable();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return await m_DbSet.Where(predicate).ToListAsync();
            }
            return await m_DbSet.ToListAsync();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return m_DbSet.FirstOrDefault(predicate);
        }
        
        public void Insert(T entity)
        {
            m_DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            m_DbSet.Attach(entity);
            ((IObjectContextAdapter)m_Context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            m_DbSet.Remove(entity);
        }

        public int Count()
        {
            return m_DbSet.Count();
        }
    }
}
