using System.Collections.Generic;
using Codara.Application;
using Codara.Domain;
using Codara.Infrastructure;
using NUnit.Framework;

namespace Codara.Tests.EditMode
{
    public sealed class LessonPlayerServiceTests
    {
        [Test]
        public void StartOrResume_RestoresLastVerifiedState()
        {
            var saves = new MemorySaveService();
            var repository = new LocalLessonSessionRepository(saves);
            var player = new LessonPlayerService(new ExerciseEvaluationEngine(), repository);
            var session = player.StartOrResume("session", "lesson", 2);
            var exercise = new ExerciseDefinition("e1", ExerciseType.TrueFalse, "", "", ExerciseAnswer.From("true"));
            player.Submit(session, "a1", exercise, ExerciseAnswer.From("true"));
            player.ShowExplanation(session);
            player.Continue(session);

            var restored = player.StartOrResume("ignored", "lesson", 2);

            Assert.That(restored.CurrentIndex, Is.EqualTo(1));
            Assert.That(restored.EarnedBytes, Is.EqualTo(1));
            Assert.That(restored.State, Is.EqualTo(LessonSessionState.AwaitingAnswer));
        }

        [Test]
        public void Submit_FailureUnlocksInput()
        {
            var player = new LessonPlayerService(new ExerciseEvaluationEngine(), new LocalLessonSessionRepository(new MemorySaveService()));
            var session = player.StartOrResume("session", "lesson", 2);
            var exercise = new ExerciseDefinition("e1", ExerciseType.TrueFalse, "", "", ExerciseAnswer.From("true"));
            player.Submit(session, "a1", exercise, ExerciseAnswer.From("true"));
            player.ShowExplanation(session);
            player.Continue(session);

            var second = new ExerciseDefinition("e2", ExerciseType.TrueFalse, "", "", ExerciseAnswer.From("true"));
            Assert.Throws<System.InvalidOperationException>(() => player.Submit(session, "a1", second, ExerciseAnswer.From("true")));
            Assert.That(session.State, Is.EqualTo(LessonSessionState.AwaitingAnswer));
            Assert.That(session.InputLocked, Is.False);
        }

        private sealed class MemorySaveService : ILocalSaveService
        {
            private readonly Dictionary<string, string> data = new();
            public bool Exists(string key) => data.ContainsKey(key);
            public string Load(string key) => data.TryGetValue(key, out var value) ? value : null;
            public void Save(string key, string content) => data[key] = content;
            public void Delete(string key) => data.Remove(key);
        }
    }
}
