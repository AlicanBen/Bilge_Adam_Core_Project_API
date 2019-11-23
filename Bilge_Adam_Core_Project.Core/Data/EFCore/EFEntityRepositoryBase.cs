using Bilge_Adam_Core_Project.Core.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bilge_Adam_Core_Project.Core.Data.EFCore
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity:class,IEntity,new()
        where TContext:DbContext,new()
    {
        public bool Add(TEntity entity)
        {
            int isAdded=0;
            try {
                using (var context = new TContext())
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    isAdded = context.SaveChanges();
                }
            } catch(Exception e) { }
            
            return isAdded > 0 ? true:false;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            int isAdded;
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
               isAdded = await context.SaveChangesAsync();
            }
            return isAdded > 0 ? true : false;
        }

        public bool Delete(TEntity entity)
        {
            int isDeleted;
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                isDeleted = context.SaveChanges();
            }
            return isDeleted > 0 ? true : false;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            int isDeleted;
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Added;
                isDeleted = await context.SaveChangesAsync();
            }
            return isDeleted > 0 ? true : false;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using(var context = new TContext())
            {
                return filter==null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return await (filter == null
                    ?  context.Set<TEntity>().ToListAsync()
                    :  context.Set<TEntity>().Where(filter).ToListAsync());
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return  await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public bool SoftDelete(TEntity entity)
        {
            
            using (var context = new TContext())
            {
                var SoftDeleteEntity = context.Entry(entity);
                SoftDeleteEntity.State = EntityState.Modified;
                return context.SaveChanges() > 0 ? true : false;
            }
        }

        public async Task<bool> SoftDeleteAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var SoftDeleteEntity = context.Entry(entity);
                SoftDeleteEntity.State = EntityState.Modified;
                return   await context.SaveChangesAsync() > 0 ? true : false;
            }
        }

        public bool Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                return context.SaveChanges() > 0 ? true : false;
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                return await context.SaveChangesAsync() > 0 ? true : false;
            }
        }
    }
}
