using System;
using System.Collections.Generic;
using Codara.Domain;

namespace Codara.Application
{
    public sealed class OfflineOperationQueue : IOfflineOperationQueue
    {
        private readonly List<OfflineOperation> pending = new List<OfflineOperation>();
        private readonly HashSet<string> operationIds = new HashSet<string>(StringComparer.Ordinal);

        public int Count => pending.Count;
        public IReadOnlyList<OfflineOperation> Pending => pending;

        public bool Enqueue(OfflineOperation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            if (!operationIds.Add(operation.Id))
            {
                return false;
            }

            pending.Add(operation);
            return true;
        }

        public bool Remove(string operationId)
        {
            if (!operationIds.Remove(operationId))
            {
                return false;
            }

            pending.RemoveAll(operation => operation.Id == operationId);
            return true;
        }

        public void Clear()
        {
            operationIds.Clear();
            pending.Clear();
        }
    }
}
