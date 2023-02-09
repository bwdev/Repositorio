using Microsoft.EntityFrameworkCore;
using Repositorio.Infrastructure;

namespace Repositorio.ApplicationServices
{

    /// <summary>
    /// Implement this in the repository layer and/or the business logic layer for read operations
    /// </summary>
    public partial class AppServiceFactory<T> : IAppServiceFactory<T> where T : DbContext
    {
        private readonly IRepositoryFactory<T> repositoryFactory;

        public AppServiceFactory(IRepositoryFactory<T> repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }
    }
}
