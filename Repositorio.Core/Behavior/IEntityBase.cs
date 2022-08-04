using System;
namespace Repositorio.Core.Behavior
{
    public interface IEntityBase
    {
        DateTime CreatedDate { get; }
        DateTime UpdatedDate { get; }

        string CreatedBy { get; }
        string UpdatedBy { get; }
    }
}
