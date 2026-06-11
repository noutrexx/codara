using System;
using Codara.Domain;
using NUnit.Framework;

namespace Codara.Tests.EditMode
{
    public sealed class DomainModelTests
    {
        [Test]
        public void GuestSession_IsNotAuthenticated()
        {
            var session = UserSession.CreateGuest(DateTimeOffset.UtcNow);

            Assert.That(session.IsGuest, Is.True);
            Assert.That(session.IsAuthenticated, Is.False);
        }

        [Test]
        public void ApplicationState_UpdatesSessionAndConnectivity()
        {
            var state = new ApplicationState();
            var session = new UserSession("user-1", false, DateTimeOffset.UtcNow);

            state.SetSession(session);
            state.SetConnectivity(true);
            state.SetLifecycle(ApplicationLifecycleState.Ready);

            Assert.That(state.Session, Is.SameAs(session));
            Assert.That(state.IsOnline, Is.True);
            Assert.That(state.Lifecycle, Is.EqualTo(ApplicationLifecycleState.Ready));
        }
    }
}
