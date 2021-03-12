using System.Linq;
using System.Threading.Tasks;
using Repositorio.Core.Behavior;

namespace Repositorio.ApplicationServices
{
    /// <summary>
    /// Extend this class to add business logic
    /// </summary>
    /// <typeparam name="T">Describes an Entity</typeparam>
    /// <typeparam name="TE">Describes the type of the Id field for the Entity</typeparam>
    public abstract class BusinessReadService<T, TE> : IRead<T, TE> where T : class
    {
        protected readonly IRead<T, TE> repository;

        protected BusinessReadService(IRead<T, TE> repository)
        {
            this.repository = repository;
        }

        public virtual async Task<T> Get(TE id)
        {
            return await repository.Get(id);
        }

        public virtual IQueryable<T> Get()
        {
            return repository.Get();
        }
    }
}
