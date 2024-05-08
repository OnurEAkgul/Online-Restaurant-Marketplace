using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface InterfaceEntityRepository<T>
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter=null, string includeProperties = "");
        Task<T> GetAsync(Expression<Func<T, bool>> filter, string includeProperties = "");
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
