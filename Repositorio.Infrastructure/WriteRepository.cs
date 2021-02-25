using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositorio.Core;
using Repositorio.Core.Behavior;

namespace Repositorio.Infrastructure
{
    public abstract class WriteRepository<T, TE, TContext> : IWrite<T> where TContext : DbContext where T : class
    {
        public WriteRepository(TContext context)
        {
            Context = context;
        }

        public TContext Context { get; }

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
