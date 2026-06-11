using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Codara.Application;
using Codara.Domain;
using NUnit.Framework;

namespace Codara.Tests.EditMode
{
    public sealed class AuthenticationServiceTests
    {
        [Test]
        public void ConvertGuest_PreservesProviderResult()
        {
            var provider = new FakeProvider(AuthenticationProvider.EmailPassword);
            var service = new AuthenticationService(new[] { provider });
            var guest = UserSession.CreateGuest(DateTimeOffset.UtcNow);

            var result = service.ConvertGuestAsync(
                guest,
                new AuthenticationRequest(AuthenticationProvider.EmailPassword, "user@example.com", "password"))
                .GetAwaiter().GetResult();

            Assert.That(result.UserId, Is.EqualTo("permanent-user"));
            Assert.That(provider.LinkedGuest, Is.SameAs(guest));
        }

        [Test]
        public void ConvertGuest_RejectsPermanentSession()
        {
            var service = new AuthenticationService(Array.Empty<IAuthenticationProvider>());
            var permanent = new UserSession("user", false, DateTimeOffset.UtcNow);
            Assert.Throws<InvalidOperationException>(() =>
                service.ConvertGuestAsync(permanent, new AuthenticationRequest(AuthenticationProvider.Google))
                    .GetAwaiter().GetResult());
        }

        private sealed class FakeProvider : IAuthenticationProvider
        {
            public FakeProvider(AuthenticationProvider provider) => Provider = provider;
            public AuthenticationProvider Provider { get; }
            public UserSession LinkedGuest { get; private set; }
            public Task<UserSession> SignInAsync(AuthenticationRequest request, CancellationToken cancellationToken = default)
                => Task.FromResult(new UserSession("permanent-user", false, DateTimeOffset.UtcNow));
            public Task<UserSession> LinkGuestAsync(UserSession guest, AuthenticationRequest request, CancellationToken cancellationToken = default)
            {
                LinkedGuest = guest;
                return SignInAsync(request, cancellationToken);
            }
            public Task SignOutAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
        }
    }
}
