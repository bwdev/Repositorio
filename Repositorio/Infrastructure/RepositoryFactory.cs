using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Infrastructure
{

    /// <summary>
    /// Repository factory. Responsible for creating instances of repositories
    /// </summary>
    public partial class RepositoryFactory<T> : IRepositoryFactory<T> where T : DbContext
    {
        protected readonly T context;
        private readonly IHttpContextAccessor contextAccessor;

        public RepositoryFactory(T context, IHttpContextAccessor contextAccessor)
        {
            this.context = context;
            this.contextAccessor = contextAccessor;
        }

        // TODO: implement the IRepositoryFactory interface here

    }
}
