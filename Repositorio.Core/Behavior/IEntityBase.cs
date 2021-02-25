using System;
namespace Repositorio.Core.Behavior
{
    public interface IEntityBase<T>
    {
        T Id { get; }

        DateTime CreatedDate { get; }
        DateTime UpdatedDate { get; }

        string CreatedBy { get; }
        string UpdatedBy { get; }
    }
}
