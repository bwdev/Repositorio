using Microsoft.EntityFrameworkCore;

namespace Repositorio.ApplicationServices
{
    public partial interface IAppServiceFactory<T> where T : DbContext
    {
    }
}
