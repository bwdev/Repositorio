using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositorio.Core.Behavior;

namespace Repositorio.Infrastructure
{
    public abstract class ReadRepository<T, TE, TContext> : IRead<T, TE> where TContext : DbContext where T : class
    {
        protected readonly TContext context;

        protected ReadRepository(TContext context)
        {
            this.context = context;
        }

        public virtual IQueryable<T> Get()
        {
            return context.Set<T>();
        }

        public async virtual Task<T> Get(TE id)
        {
            return await context.Set<T>().FindAsync(id);
        }
    }
}
