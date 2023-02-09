using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Repositorio.Tests
{
    internal static class TestHelper
    {
        public static DbContextOptions<FakeContext> SetupInMemoryDb()
        {
            return new DbContextOptionsBuilder<FakeContext>()
                .UseInMemoryDatabase(databaseName: $"{Guid.NewGuid()}_Database")
                .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
        }
    }

}
