using Bilge_Adam_Core_Project.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bilge_Adam_Core_Project.Core.Data
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        bool Add(T entity);
        Task<bool> AddAsync(T entity);
        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);
        bool Delete(T entity);
        Task<bool> DeleteAsync(T entity); 
        bool SoftDelete(T entity);
        Task<bool> SoftDeleteAsync(T entity);
        T Get(Expression<Func<T, bool>> filter=null);
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter=null);
        Task< List<T>> GetAllAsync(Expression<Func<T, bool>> filter=null);
    }
}
