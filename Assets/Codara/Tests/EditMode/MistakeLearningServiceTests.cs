using System;
using System.Linq;
using Codara.Application;
using Codara.Domain;
using NUnit.Framework;

namespace Codara.Tests.EditMode
{
    public sealed class MistakeLearningServiceTests
    {
        private readonly MistakeLearningService service = new();
        private readonly DateTimeOffset now = new DateTimeOffset(2026, 6, 12, 12, 0, 0, TimeSpan.Zero);

        [Test]
        public void Prioritize_PrefersRecentFrequentUncorrectedMistake()
        {
            var older = Create("old", "e1", "loops", now.AddDays(-5), 1);
            var recent = Create("recent", "e2", "loops", now.AddHours(-1), 4);
            Assert.That(service.Prioritize(new[] { older, recent }, now)[0], Is.SameAs(recent));
        }

        [Test]
        public void BuildDailyReview_SelectsSimilarExerciseBeforeSameQuestion()
        {
            var mistake = Create("m1", "original", "loops", now.AddHours(-1), 1);
            var original = Exercise("original", "loops");
            var similar = Exercise("similar", "loops");
            Assert.That(service.BuildDailyReview(new[] { mistake }, new[] { original, similar }, Array.Empty<string>(), now).Single().Id,
                Is.EqualTo("similar"));
        }

        [Test]
        public void BuildDailyReview_AvoidsRecentlyShownExercise()
        {
            var mistake = Create("m1", "original", "loops", now.AddHours(-1), 1);
            var result = service.BuildDailyReview(new[] { mistake }, new[] { Exercise("original", "loops"), Exercise("similar", "loops") },
                new[] { "similar" }, now);
            Assert.That(result.Single().Id, Is.EqualTo("original"));
        }

        [Test]
        public void Analyze_OrdersWeakestSkillFirst()
        {
            var weak = Create("m1", "e1", "loops", now, 1);
            var strong = Create("m2", "e2", "variables", now, 1);
            strong.RecordReview(true, now);
            Assert.That(service.Analyze(new[] { strong, weak })[0].SkillTag, Is.EqualTo("loops"));
        }

        [Test]
        public void CreateDailyPlan_IsStableForSameDay()
        {
            var mistake = Create("m1", "original", "loops", now.AddHours(-1), 1);
            var exercises = new[] { Exercise("original", "loops"), Exercise("similar", "loops") };
            var first = service.CreateDailyPlan(new[] { mistake }, exercises, Array.Empty<string>(), now);
            var second = service.CreateDailyPlan(new[] { mistake }, exercises, Array.Empty<string>(), now.AddHours(3));
            Assert.That(second.Id, Is.EqualTo(first.Id));
            Assert.That(second.ExerciseIds, Is.EqualTo(first.ExerciseIds));
        }

        private static MistakeRecord Create(string id, string exercise, string skill, DateTimeOffset at, int attempt)
            => new MistakeRecord(id, "user", exercise, skill, MistakeCategory.LoopLogic, ExerciseAnswer.From("wrong"),
                ExerciseAnswer.From("right"), at, attempt);

        private static ExerciseDefinition Exercise(string id, string skill)
            => new ExerciseDefinition(id, ExerciseType.ShortAnswer, "", "", ExerciseAnswer.From("right"), skillTags: new[] { skill });
    }
}
