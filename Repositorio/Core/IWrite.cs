using System.Threading.Tasks;

namespace Repositorio.Core
{
    public interface IWrite<T> where T : class
    {
        Task Create(T obj);
        Task Update(T obj);
        Task Remove(T entity);
    }
}
