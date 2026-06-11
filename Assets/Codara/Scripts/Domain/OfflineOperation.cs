using System;

namespace Codara.Domain
{
    [Serializable]
    public sealed class OfflineOperation
    {
        public OfflineOperation(string id, string operationType, string payload, DateTimeOffset createdAt)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("An operation id is required.", nameof(id));
            }

            Id = id;
            OperationType = operationType ?? string.Empty;
            Payload = payload ?? string.Empty;
            CreatedAt = createdAt;
        }

        public string Id { get; }
        public string OperationType { get; }
        public string Payload { get; }
        public DateTimeOffset CreatedAt { get; }
    }
}

