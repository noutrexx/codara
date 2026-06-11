using System;
using System.Collections.Generic;
using System.Globalization;
using Codara.Application;
using Codara.Domain;
using UnityEngine;

namespace Codara.Infrastructure
{
    public sealed class PersistentOfflineOperationQueue : IOfflineOperationQueue
    {
        private const string SaveKey = "offline-operations";

        private readonly ILocalSaveService saveService;
        private readonly OfflineOperationQueue queue = new OfflineOperationQueue();

        public PersistentOfflineOperationQueue(ILocalSaveService saveService)
        {
            this.saveService = saveService ?? throw new ArgumentNullException(nameof(saveService));
            Restore();
        }

        public int Count => queue.Count;
        public IReadOnlyList<OfflineOperation> Pending => queue.Pending;

        public bool Enqueue(OfflineOperation operation)
        {
            var added = queue.Enqueue(operation);
            if (added)
            {
                Persist();
            }

            return added;
        }

        public bool Remove(string operationId)
        {
            var removed = queue.Remove(operationId);
            if (removed)
            {
                Persist();
            }

            return removed;
        }

        public void Clear()
        {
            queue.Clear();
            saveService.Delete(SaveKey);
        }

        private void Restore()
        {
            var json = saveService.Load(SaveKey);
            if (string.IsNullOrWhiteSpace(json))
            {
                return;
            }

            OperationQueueData data;
            try
            {
                data = JsonUtility.FromJson<OperationQueueData>(json);
            }
            catch (ArgumentException)
            {
                return;
            }

            if (data?.operations == null)
            {
                return;
            }

            foreach (var item in data.operations)
            {
                if (item == null || string.IsNullOrWhiteSpace(item.id) ||
                    !DateTimeOffset.TryParseExact(
                        item.createdAt,
                        "O",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out var createdAt))
                {
                    continue;
                }

                queue.Enqueue(new OfflineOperation(item.id, item.operationType, item.payload, createdAt));
            }
        }

        private void Persist()
        {
            var data = new OperationQueueData();
            foreach (var operation in queue.Pending)
            {
                data.operations.Add(new OperationData
                {
                    id = operation.Id,
                    operationType = operation.OperationType,
                    payload = operation.Payload,
                    createdAt = operation.CreatedAt.ToString("O")
                });
            }

            saveService.Save(SaveKey, JsonUtility.ToJson(data));
        }

        [Serializable]
        private sealed class OperationQueueData
        {
            public List<OperationData> operations = new List<OperationData>();
        }

        [Serializable]
        private sealed class OperationData
        {
            public string id;
            public string operationType;
            public string payload;
            public string createdAt;
        }
    }
}
