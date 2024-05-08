using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EntityRepository<TEntity, TContext> : InterfaceEntityRepository<TEntity>
        where TEntity : class, new() where TContext : IdentityDbContext, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using (TContext c = new TContext()) { 
            
                var AddedEntity = c.Entry(entity);
                AddedEntity.State = EntityState.Added;
                await c.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (TContext c = new TContext())
            {

                var DeletedEntity = c.Entry(entity);
                DeletedEntity.State = EntityState.Deleted;
                await c.SaveChangesAsync();
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            using (TContext c = new TContext())
            {
                IQueryable<TEntity> query = c.Set<TEntity>();

                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                }

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                return await query.ToListAsync();
            }
        }


        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, string includeProperties = "")
        {
            using (TContext c = new TContext())
            {
                IQueryable<TEntity> query = c.Set<TEntity>();

                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                }

                return await query.SingleOrDefaultAsync(filter);
            }
        }


        public async Task UpdateAsync(TEntity entity)
        {
            using (TContext c = new TContext())
            {
                var UpdatedEntity= c.Entry(entity);
                UpdatedEntity.State = EntityState.Modified;
                await c.SaveChangesAsync();
            }
        }
    }

}
