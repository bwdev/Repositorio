using System;
namespace Repositorio.Core
{
    public interface IEntityAuditable
    {
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }

        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
}
