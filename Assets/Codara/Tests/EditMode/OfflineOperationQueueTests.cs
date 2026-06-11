using System;
using Codara.Application;
using Codara.Domain;
using NUnit.Framework;

namespace Codara.Tests.EditMode
{
    public sealed class OfflineOperationQueueTests
    {
        [Test]
        public void Enqueue_RejectsDuplicateOperationId()
        {
            var queue = new OfflineOperationQueue();
            var operation = new OfflineOperation("operation-1", "lesson_completed", "{}", DateTimeOffset.UtcNow);

            Assert.That(queue.Enqueue(operation), Is.True);
            Assert.That(queue.Enqueue(operation), Is.False);
            Assert.That(queue.Count, Is.EqualTo(1));
        }

        [Test]
        public void Remove_RemovesKnownOperation()
        {
            var queue = new OfflineOperationQueue();
            queue.Enqueue(new OfflineOperation("operation-1", "lesson_completed", "{}", DateTimeOffset.UtcNow));

            Assert.That(queue.Remove("operation-1"), Is.True);
            Assert.That(queue.Count, Is.Zero);
        }
    }
}
