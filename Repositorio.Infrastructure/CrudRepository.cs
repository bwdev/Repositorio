using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositorio.Core.Behavior;

namespace Repositorio.Infrastructure
{
    /// <summary>
    /// use this as a base implementation for CRUD behavior in an Entity Framework Entity
    /// </summary>
    /// <typeparam name="T">The type of the DbSet</typeparam>
    /// <typeparam name="TE">The type of the id for the Entity</typeparam>
    /// <typeparam name="TContext">The type of your DbContext class</typeparam>
    public abstract class CrudRepository<T, TE, TContext> : ICrud<T, TE> where TContext : DbContext where T : class
    {
        protected TContext Context { get; }

        public CrudRepository(TContext context)
        {
            Context = context;
        }

        public virtual IQueryable<T> Get()
        {
            return Context.Set<T>();
        }

        public async virtual Task<T> Get(TE id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async virtual Task Create(T obj)
        {
            Context.Set<T>().Add(obj);
            await Context.SaveChangesAsync();
        }

        public async virtual Task Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async virtual Task Update(T obj)
        {
            Context.Set<T>().Update(obj);
            await Context.SaveChangesAsync();
        }
    }
}

