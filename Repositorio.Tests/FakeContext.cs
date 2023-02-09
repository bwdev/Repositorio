using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Repositorio.Core;
using Repositorio.Infrastructure;
using Repositorio.Tests.Models;

namespace Repositorio.Tests
{
    internal class FakeContext : DefaultContext<FakeContext>
    {
        public FakeContext(DbContextOptions<FakeContext> options, IHttpContextAccessor httpContextAccessor, IClock clock) : base(options, httpContextAccessor, clock) { }

        public DbSet<Widget> Widgets { get; set; }
    }
}