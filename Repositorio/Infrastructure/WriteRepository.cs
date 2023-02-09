using Microsoft.EntityFrameworkCore;
using Repositorio.Core;

namespace Repositorio.Infrastructure
{
    /// <summary>
    /// Default implementation for a repository that uses a EntityFramework DbContext for write operations
    /// </summary>
    /// <typeparam name="T">The type of the Entity</typeparam>
    /// <typeparam name="TE">The type of the id of the Entity</typeparam>
    /// <typeparam name="TContext">The type of the subclass of DbContext used to manage the database</typeparam>
    public abstract class WriteRepository<T, TE, TContext> : IDisposable, IWrite<T> where TContext : DbContext where T : class
    {
        private bool isDisposed;

        ~WriteRepository() => Dispose(false);

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


        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposed) return;
            if (isDisposing)
            {
                // TODO: dispose managed state objects here
                Context.Dispose();
            }

            isDisposed = true;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
