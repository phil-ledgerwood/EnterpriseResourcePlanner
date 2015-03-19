using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EnterpriseResourcePlanner.Domain;

namespace EnterpriseResourcePlanner.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IPersistable
    {
        private readonly IDbContext _dbContext;
        private readonly IDbSet<T> _dbSet;

        public Repository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual T Add(T entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            var dbEntityEntry = _dbContext.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
            return _dbSet.Remove(entity);
        }

        public virtual IEnumerable<T> DeleteAll(IEnumerable<T> entities)
        {
            return entities.Select(Delete);
        }

        public virtual T Update(T entity)
        {
            var dbEntityEntry = _dbContext.Entry(entity);
            var updatedEntity = _dbSet.Attach(entity);
            dbEntityEntry.State = EntityState.Modified;
            return updatedEntity;
        }

        public virtual bool Any()
        {
            return _dbSet.Any();
        }
    }
}
