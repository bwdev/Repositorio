namespace Repositorio.Core
{
    /// <summary>
    /// Provides a class that can be extended to give an entity some auditable properties
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Auditable<T> : IEntityAuditable
    {
        public T Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
    }
}
