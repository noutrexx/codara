using System;

namespace Codara.Domain
{
    public enum ApplicationLifecycleState
    {
        Starting,
        Ready,
        Background,
        Faulted
    }

    [Serializable]
    public sealed class ApplicationState
    {
        public ApplicationState()
        {
            Lifecycle = ApplicationLifecycleState.Starting;
            Session = UserSession.CreateGuest(DateTimeOffset.UtcNow);
        }

        public ApplicationLifecycleState Lifecycle { get; private set; }
        public UserSession Session { get; private set; }
        public bool IsOnline { get; private set; }

        public void SetLifecycle(ApplicationLifecycleState lifecycle)
        {
            Lifecycle = lifecycle;
        }

        public void SetSession(UserSession session)
        {
            Session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public void SetConnectivity(bool isOnline)
        {
            IsOnline = isOnline;
        }
    }
}

