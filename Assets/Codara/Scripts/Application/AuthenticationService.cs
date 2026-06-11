using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Codara.Domain;

namespace Codara.Application
{
    public sealed class AuthenticationService : IAuthenticationService
    {
        private readonly Dictionary<AuthenticationProvider, IAuthenticationProvider> providers = new();

        public AuthenticationService(IEnumerable<IAuthenticationProvider> providers)
        {
            foreach (var provider in providers) this.providers[provider.Provider] = provider;
        }

        public Task<UserSession> SignInAsync(AuthenticationRequest request, CancellationToken cancellationToken = default)
            => GetProvider(request.Provider).SignInAsync(request, cancellationToken);

        public Task<UserSession> ConvertGuestAsync(UserSession guest, AuthenticationRequest request, CancellationToken cancellationToken = default)
        {
            if (guest == null || !guest.IsGuest) throw new InvalidOperationException("Only a guest session can be converted.");
            if (request.Provider == AuthenticationProvider.Guest) throw new InvalidOperationException("A permanent provider is required.");
            return GetProvider(request.Provider).LinkGuestAsync(guest, request, cancellationToken);
        }

        private IAuthenticationProvider GetProvider(AuthenticationProvider provider)
        {
            if (!providers.TryGetValue(provider, out var implementation))
                throw new NotSupportedException($"Authentication provider is not configured: {provider}");
            return implementation;
        }
    }
}
