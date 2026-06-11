using System;

namespace Codara.Domain
{
    [Serializable]
    public sealed class UserSession
    {
        public UserSession(string userId, bool isGuest, DateTimeOffset startedAt)
        {
            UserId = userId ?? string.Empty;
            IsGuest = isGuest;
            StartedAt = startedAt;
        }

        public string UserId { get; }
        public bool IsGuest { get; }
        public DateTimeOffset StartedAt { get; }
        public bool IsAuthenticated => !string.IsNullOrWhiteSpace(UserId) && !IsGuest;

        public static UserSession CreateGuest(DateTimeOffset startedAt)
        {
            return new UserSession(string.Empty, true, startedAt);
        }
    }
}

