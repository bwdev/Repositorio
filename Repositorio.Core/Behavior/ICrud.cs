using System;

namespace Repositorio.Core.Behavior
{
    public interface ICrud<T, TE> : IRead<T, TE>, IWrite<T> where T : class { }
}
