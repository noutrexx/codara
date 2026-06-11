using System;
using System.Collections.Generic;
using Codara.Application;
using Codara.Domain;
using Codara.Infrastructure;
using NUnit.Framework;

namespace Codara.Tests.EditMode
{
    public sealed class PersistentOfflineOperationQueueTests
    {
        [Test]
        public void Queue_RestoresPendingOperations()
        {
            var saves = new MemorySaveService();
            var first = new PersistentOfflineOperationQueue(saves);
            first.Enqueue(new OfflineOperation("operation-1", "lesson", "{}", DateTimeOffset.UtcNow));

            var restored = new PersistentOfflineOperationQueue(saves);

            Assert.That(restored.Count, Is.EqualTo(1));
            Assert.That(restored.Pending[0].Id, Is.EqualTo("operation-1"));
        }

        private sealed class MemorySaveService : ILocalSaveService
        {
            private readonly Dictionary<string, string> values = new Dictionary<string, string>();

            public bool Exists(string key) => values.ContainsKey(key);
            public string Load(string key) => values.TryGetValue(key, out var value) ? value : null;
            public void Save(string key, string content) => values[key] = content;
            public void Delete(string key) => values.Remove(key);
        }
    }
}
