using System;
using System.Collections.Generic;
using Codara.Application;
using Codara.Domain;
using Codara.Infrastructure;
using NUnit.Framework;

namespace Codara.Tests.EditMode
{
    public sealed class MistakeRepositoryTests
    {
        [Test]
        public void Repository_RestoresOfflineMistake()
        {
            var saves = new MemorySaveService();
            var repository = new LocalMistakeRepository(saves);
            repository.Save(new[] { new MistakeRecord("m1", "u1", "e1", "loops", MistakeCategory.LoopLogic,
                ExerciseAnswer.From("wrong"), ExerciseAnswer.From("right"), DateTimeOffset.UtcNow, 1) });

            var restored = new LocalMistakeRepository(saves).Load();

            Assert.That(restored.Count, Is.EqualTo(1));
            Assert.That(restored[0].SkillTag, Is.EqualTo("loops"));
            Assert.That(restored[0].GivenAnswer.Tokens[0], Is.EqualTo("wrong"));
        }

        [Test]
        public void Recorder_RejectsDuplicateMistakeId()
        {
            var repository = new LocalMistakeRepository(new MemorySaveService());
            var recorder = new MistakeRecorder(repository);
            var exercise = new ExerciseDefinition("e1", ExerciseType.ShortAnswer, "", "", ExerciseAnswer.From("right"),
                skillTags: new[] { "loops" }, errorCategories: new[] { "LoopLogic" });
            var evaluation = new ExerciseEvaluation("a1", "e1", false, 0, 1);
            recorder.Record("m1", "u1", exercise, ExerciseAnswer.From("wrong"), evaluation, DateTimeOffset.UtcNow);
            Assert.Throws<InvalidOperationException>(() =>
                recorder.Record("m1", "u1", exercise, ExerciseAnswer.From("wrong"), evaluation, DateTimeOffset.UtcNow));
        }

        [Test]
        public void Repository_PreservesReviewSchedule()
        {
            var saves = new MemorySaveService();
            var repository = new LocalMistakeRepository(saves);
            var record = new MistakeRecord("m1", "u1", "e1", "loops", MistakeCategory.LoopLogic,
                ExerciseAnswer.From("wrong"), ExerciseAnswer.From("right"), DateTimeOffset.UtcNow, 1);
            record.RecordReview(true, DateTimeOffset.UtcNow.AddDays(1));
            repository.Save(new[] { record });

            var restored = repository.Load()[0];
            Assert.That(restored.CorrectedLater, Is.True);
            Assert.That(restored.SuccessfulReviews, Is.EqualTo(1));
            Assert.That(restored.NextReviewAt, Is.EqualTo(record.NextReviewAt));
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
