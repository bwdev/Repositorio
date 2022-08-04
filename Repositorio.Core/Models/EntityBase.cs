using System;
using Repositorio.Core.Behavior;

namespace Repositorio.Core.Models
{
    /// <summary>
    /// Extend this class to provide more auto properties for entity framework models
    /// </summary>
    public abstract class EntityBase : IEntityBase
    {
        public DateTime CreatedDate { get; }

        public DateTime UpdatedDate { get; }

        public string CreatedBy { get; }

        public string UpdatedBy { get; }
    }
}
