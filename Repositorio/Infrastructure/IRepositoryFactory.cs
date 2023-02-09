using Microsoft.EntityFrameworkCore;

namespace Repositorio.Infrastructure
{
    /// <summary>
    /// Implement this in the repository layer and/or the business logic layer for read operations
    /// </summary>
    /// <typeparam name="T">The type of the Entity</typeparam>
    /// <typeparam name="TE">The type of the id of the Entity</typeparam>
    public partial interface IRepositoryFactory<T> where T : DbContext
    {
        // TODO: add factory methods here for each of your repositories
    }
}
