using Repositorio.Core;

namespace Repositorio.Tests.Models
{
    internal class Widget : Auditable<int>
    {
        public string Name { get; set; }
    }
}