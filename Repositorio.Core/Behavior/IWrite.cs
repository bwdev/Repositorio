using System.Threading.Tasks;

namespace Repositorio.Core.Behavior
{
    public interface IWrite<T> where T : class
    {
        Task Create(T obj);
        Task Update(T obj);
        Task Remove(T entity);
    }
}
