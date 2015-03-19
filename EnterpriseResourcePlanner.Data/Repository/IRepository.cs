using System.Collections.Generic;
using System.Linq;
using EnterpriseResourcePlanner.Domain;

namespace EnterpriseResourcePlanner.Data.Repository
{
    public interface IRepository<T> where T : class, IPersistable
    {
        IQueryable<T> GetAll();
        T Add(T entity);
        T Delete(T entity);
        IEnumerable<T> DeleteAll(IEnumerable<T> entities);
        T Update(T entity);
        bool Any();
    }
}
