namespace Repositorio.Core
{
    public interface IClock
    {
        DateTime GetUtc();
    }

    public class DefaultClock : IClock
    {
        public virtual DateTime GetLocal() => DateTime.Now;
        public virtual DateTime GetUtc() => DateTime.UtcNow;
    }
}
