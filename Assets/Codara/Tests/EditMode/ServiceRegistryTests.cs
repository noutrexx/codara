using System;
using Codara.Application;
using NUnit.Framework;

namespace Codara.Tests.EditMode
{
    public sealed class ServiceRegistryTests
    {
        [Test]
        public void Resolve_ReturnsRegisteredService()
        {
            var registry = new ServiceRegistry();
            var service = new object();
            registry.Register(service);

            Assert.That(registry.Resolve<object>(), Is.SameAs(service));
        }

        [Test]
        public void Resolve_ThrowsForMissingService()
        {
            var registry = new ServiceRegistry();

            Assert.Throws<InvalidOperationException>(() => registry.Resolve<object>());
        }
    }
}
