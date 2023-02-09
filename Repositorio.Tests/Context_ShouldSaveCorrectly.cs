using Microsoft.AspNetCore.Http;
using Moq;
using Repositorio.Core;
using Repositorio.Tests.Models;
using System.Security.Principal;

namespace Repositorio.Tests
{

    [TestClass]
    public class Context_ShouldSaveCorrectly
    {
        private Mock<IHttpContextAccessor> httpContextAccessor;
        private Mock<IClock> clock;
        private Mock<IIdentity> identity;

        [TestInitialize]
        public void Init()
        {
            httpContextAccessor = new Mock<IHttpContextAccessor>();
            clock = new Mock<IClock>();

            clock.Setup(s => s.GetUtc()).Returns(new DateTime(2023, 1, 1));

            identity = new Mock<IIdentity>();
            identity.Setup(i => i.Name).Returns("foobar");
        }

        [TestMethod]
        public void UpdateEntityMetadata_SaveChangesShouldSetAuditProperties()
        {
            httpContextAccessor.Setup(s => s.HttpContext.User.Identity).Returns(identity.Object);
            var ctx = new FakeContext(TestHelper.SetupInMemoryDb(), httpContextAccessor.Object, clock.Object);

            ctx.Add(new Widget { Name = "Foo" });
            ctx.SaveChanges();

            var widget = ctx.Widgets.FirstOrDefault(f => f.Name == "Foo");

            Assert.AreEqual("foobar", widget?.CreatedBy);
            Assert.AreEqual(new DateTime(2023, 1, 1).Ticks, widget?.CreatedDate.Ticks);
            Assert.AreEqual("foobar", widget?.UpdatedBy);
            Assert.AreEqual(new DateTime(2023, 1, 1).Ticks, widget?.UpdatedDate.Ticks);
        }

        [TestMethod]
        public void UpdateEntityMetadata_SaveChangesWithAcceptShouldSetAuditProperties()
        {
            httpContextAccessor.Setup(s => s.HttpContext.User.Identity).Returns(identity.Object);
            var ctx = new FakeContext(TestHelper.SetupInMemoryDb(), httpContextAccessor.Object, clock.Object);

            ctx.Add(new Widget { Name = "Bar" });
            ctx.SaveChanges(true);

            var widget = ctx.Widgets.FirstOrDefault(f => f.Name == "Bar");

            Assert.AreEqual("foobar", widget?.CreatedBy);
            Assert.AreEqual(new DateTime(2023, 1, 1).Ticks, widget?.CreatedDate.Ticks);
            Assert.AreEqual("foobar", widget?.UpdatedBy);
            Assert.AreEqual(new DateTime(2023, 1, 1).Ticks, widget?.UpdatedDate.Ticks);
        }

        [TestMethod]
        public async Task UpdateEntityMetadata_SaveChangesAsyncShouldSetAuditProperties()
        {
            httpContextAccessor.Setup(s => s.HttpContext.User.Identity).Returns(identity.Object);
            var ctx = new FakeContext(TestHelper.SetupInMemoryDb(), httpContextAccessor.Object, clock.Object);

            ctx.Add(new Widget { Name = "Foo1" });
            await ctx.SaveChangesAsync();

            var widget = ctx.Widgets.FirstOrDefault(f => f.Name == "Foo1");

            Assert.AreEqual("foobar", widget?.CreatedBy);
            Assert.AreEqual(new DateTime(2023, 1, 1).Ticks, widget?.CreatedDate.Ticks);
            Assert.AreEqual("foobar", widget?.UpdatedBy);
            Assert.AreEqual(new DateTime(2023, 1, 1).Ticks, widget?.UpdatedDate.Ticks);
        }

        [TestMethod]
        public async Task UpdateEntityMetadata_SaveChangesAsyncWithAcceptShouldSetAuditProperties()
        {
            httpContextAccessor.Setup(s => s.HttpContext.User.Identity).Returns(identity.Object);
            var ctx = new FakeContext(TestHelper.SetupInMemoryDb(), httpContextAccessor.Object, clock.Object);

            ctx.Add(new Widget { Name = "Bar1" });
            await ctx.SaveChangesAsync(true);

            var widget = ctx.Widgets.FirstOrDefault(f => f.Name == "Bar1");

            Assert.AreEqual("foobar", widget?.CreatedBy);
            Assert.AreEqual(new DateTime(2023, 1, 1).Ticks, widget?.CreatedDate.Ticks);
            Assert.AreEqual("foobar", widget?.UpdatedBy);
            Assert.AreEqual(new DateTime(2023, 1, 1).Ticks, widget?.UpdatedDate.Ticks);
        }


    }
}