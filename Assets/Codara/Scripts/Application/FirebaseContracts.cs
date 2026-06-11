using System;
using System.Threading;
using System.Threading.Tasks;

namespace Codara.Application
{
    public interface IFirebaseAuthenticationService
    {
        string CurrentUserId { get; }
        bool IsAuthenticated { get; }
        Task SignInAnonymouslyAsync(CancellationToken cancellationToken = default);
        Task SignOutAsync(CancellationToken cancellationToken = default);
    }

    public interface IFirestoreService
    {
        Task<string> GetDocumentAsync(string path, CancellationToken cancellationToken = default);
        Task SetDocumentAsync(string path, string json, CancellationToken cancellationToken = default);
    }

    public interface ICloudFunctionsService
    {
        Task<string> CallAsync(string functionName, string json, CancellationToken cancellationToken = default);
    }

    public interface IAnalyticsService
    {
        void LogEvent(string eventName, params (string Name, string Value)[] parameters);
    }

    public interface ICrashReportingService
    {
        void RecordException(Exception exception);
    }

    public interface IRemoteConfigService
    {
        Task FetchAsync(CancellationToken cancellationToken = default);
        string GetString(string key, string fallback = "");
        bool GetBool(string key, bool fallback = false);
        long GetLong(string key, long fallback = 0);
    }

    public interface ICloudMessagingService
    {
        string Token { get; }
        event Action<string> TokenChanged;
    }
}

