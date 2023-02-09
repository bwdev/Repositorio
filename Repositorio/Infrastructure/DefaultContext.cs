using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repositorio.Core;

namespace Repositorio.Infrastructure
{
    /// <summary>
    /// This class provides a consistent way to update metadata properties automatically on the save
    /// </summary>
    /// <typeparam name="T">The type of the Id of the Entity</typeparam>
    public abstract class DefaultContext<T> : DbContext where T : DbContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly DateTime updateTime;

        public DefaultContext(DbContextOptions<T> options, IHttpContextAccessor httpContextAccessor, IClock clock)
            : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.updateTime = clock.GetUtc();
        }

        public DefaultContext(IHttpContextAccessor httpContextAccessor, IClock clock)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.updateTime = clock.GetUtc();
        }

        public override int SaveChanges()
        {
            UpdateEntityBaseMetadata(this.ChangeTracker);
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateEntityBaseMetadata(this.ChangeTracker);
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateEntityBaseMetadata(this.ChangeTracker);
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateEntityBaseMetadata(this.ChangeTracker);
            return base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Updates the entity metadata described in the IEntityBase interface for both added and modified changes
        /// </summary>
        /// <param name="changeTracker">The entity framework change tracker instance</param>
        protected virtual void UpdateEntityBaseMetadata(ChangeTracker changeTracker)
        {
            var added = changeTracker.Entries().Where(w => w.Entity is IEntityAuditable && w.State == EntityState.Added);
            var modified = changeTracker.Entries().Where(w => w.Entity is IEntityAuditable && w.State == EntityState.Modified);

            var user = httpContextAccessor.HttpContext?.User?.Identity?.Name;
            var time = updateTime;

            foreach (var entity in added) UpdateEntityForAdded(entity.Entity as IEntityAuditable, user, time);
            foreach (var entity in modified) UpdateEntityForModified(entity.Entity as IEntityAuditable, user, time);
        }

        /// <summary>
        /// Updates the entity metadata for the added entities
        /// </summary>
        /// <typeparam name="T">The type of the id of the Entity</typeparam>
        /// <param name="entity"></param>
        /// <param name="user"></param>
        /// <param name="currentTime"></param>
        protected virtual void UpdateEntityForAdded(IEntityAuditable? entity, string? user, DateTime currentTime)
        {
            if (entity == null) return;
            entity.CreatedDate = currentTime;
            entity.CreatedBy = user ?? string.Empty;
            UpdateEntityForModified(entity, user, currentTime);
        }

        protected virtual void UpdateEntityForModified(IEntityAuditable? entity, string? user, DateTime currentTime)
        {
            if (entity == null) return;
            entity.UpdatedBy = user ?? string.Empty;
            entity.UpdatedDate = currentTime;
        }
    }
}
