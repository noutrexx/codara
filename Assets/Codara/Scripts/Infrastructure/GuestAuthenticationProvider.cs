using System;
using System.Threading;
using System.Threading.Tasks;
using Codara.Application;
using Codara.Domain;

namespace Codara.Infrastructure
{
    public sealed class GuestAuthenticationProvider : IAuthenticationProvider
    {
        public AuthenticationProvider Provider => AuthenticationProvider.Guest;

        public Task<UserSession> SignInAsync(AuthenticationRequest request, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(UserSession.CreateGuest(DateTimeOffset.UtcNow));
        }

        public Task<UserSession> LinkGuestAsync(UserSession guest, AuthenticationRequest request, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Guest sessions cannot be linked to another guest session.");

        public Task SignOutAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
    }
}
