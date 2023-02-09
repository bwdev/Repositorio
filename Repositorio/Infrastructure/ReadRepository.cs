using Microsoft.EntityFrameworkCore;
using Repositorio.Core;

namespace Repositorio.Infrastructure
{
    /// <summary>
    /// Default implementation for a repository that uses a EntityFramework DbContext for read operations
    /// </summary>
    /// <typeparam name="T">The type of the Entity</typeparam>
    /// <typeparam name="TE">The type of the id of the Entity</typeparam>
    /// <typeparam name="TContext">The type of the subclass of DbContext used for database management</typeparam>
    public abstract class ReadRepository<T, TE, TContext> : IDisposable, IRead<T, TE> where T : class where TContext : DbContext
    {
        protected readonly TContext context;
        private bool isDisposed;

        ~ReadRepository() => Dispose(false);

        protected ReadRepository(TContext context)
        {
            this.context = context;
        }

        public virtual IQueryable<T> Get()
        {
            return context.Set<T>().AsNoTracking();
        }

        public virtual async Task<T> Get(TE id)
        {
            var item = await context.Set<T>().FindAsync(id);
            if (item == null) throw new Exception($"Item with id ${id} was not found.");
            context.Entry(item).State = EntityState.Detached;
            return item;
        }


        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposed) return;
            if (isDisposing)
            {
                // TODO: dispose managed state objects here
                context.Dispose();
            }

            isDisposed = true;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
