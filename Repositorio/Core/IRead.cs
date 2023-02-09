using System.Linq;
using System.Threading.Tasks;

namespace Repositorio.Core
{
    public interface IRead<T, TE> where T : class
    {
        IQueryable<T> Get();
        Task<T> Get(TE id);
    }
}
