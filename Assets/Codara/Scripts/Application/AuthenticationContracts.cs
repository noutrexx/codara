using System.Threading;
using System.Threading.Tasks;
using Codara.Domain;

namespace Codara.Application
{
    public enum AuthenticationProvider { Guest, EmailPassword, Google, Apple }

    public sealed class AuthenticationRequest
    {
        public AuthenticationRequest(AuthenticationProvider provider, string email = "", string password = "")
        {
            Provider = provider;
            Email = email ?? string.Empty;
            Password = password ?? string.Empty;
        }
        public AuthenticationProvider Provider { get; }
        public string Email { get; }
        public string Password { get; }
    }

    public interface IAuthenticationProvider
    {
        AuthenticationProvider Provider { get; }
        Task<UserSession> SignInAsync(AuthenticationRequest request, CancellationToken cancellationToken = default);
        Task<UserSession> LinkGuestAsync(UserSession guest, AuthenticationRequest request, CancellationToken cancellationToken = default);
        Task SignOutAsync(CancellationToken cancellationToken = default);
    }

    public interface IAuthenticationService
    {
        Task<UserSession> SignInAsync(AuthenticationRequest request, CancellationToken cancellationToken = default);
        Task<UserSession> ConvertGuestAsync(UserSession guest, AuthenticationRequest request, CancellationToken cancellationToken = default);
    }

    public interface IOnboardingRepository
    {
        OnboardingState Load();
        void Save(OnboardingState state);
        void Clear();
    }
}
