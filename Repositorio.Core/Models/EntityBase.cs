using System;
using Repositorio.Core.Behavior;

namespace Repositorio.Core.Models
{
    /// <summary>
    /// Extend this class to provide more auto properties for entity framework models
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EntityBase<T> : IEntityBase<T>
    {
        public T Id { get; }

        public DateTime CreatedDate { get; }

        public DateTime UpdatedDate { get; }

        public string CreatedBy { get; }

        public string UpdatedBy { get; }
    }
}
