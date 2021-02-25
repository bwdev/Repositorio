using System.Threading.Tasks;
using Repositorio.Core.Behavior;

namespace Repositorio.Infrastructure
{
    /// <summary>
    /// Extend this class to add business logic
    /// </summary>
    /// <typeparam name="T">Describes an Entity</typeparam>
    public abstract class BusinessWriteService<T> : IWrite<T> where T : class
    {
        protected BusinessWriteService(IWrite<T> repository)
        {
            Repository = repository;
        }

        protected IWrite<T> Repository { get; }

        public virtual async Task Create(T entity)
        {
            await Repository.Create(entity);
        }

        public async virtual Task Remove(T entity)
        {
            await Repository.Remove(entity);
        }

        public virtual async Task Update(T entity)
        {
            await Repository.Update(entity);
        }
    }
}
