using System;
using System.Collections.Generic;
using System.Linq;
using Codara.Domain;

namespace Codara.Application
{
    public sealed class MistakeLearningService
    {
        public IReadOnlyList<MistakeRecord> Prioritize(IEnumerable<MistakeRecord> mistakes, DateTimeOffset now)
            => mistakes.OrderByDescending(mistake => Score(mistake, now)).ThenBy(mistake => mistake.Id, StringComparer.Ordinal).ToList();

        public IReadOnlyList<ExerciseDefinition> BuildDailyReview(
            IEnumerable<MistakeRecord> mistakes,
            IEnumerable<ExerciseDefinition> exercises,
            IEnumerable<string> recentlyShownExerciseIds,
            DateTimeOffset now,
            int count = 5)
        {
            var recent = new HashSet<string>(recentlyShownExerciseIds ?? Array.Empty<string>(), StringComparer.Ordinal);
            var available = exercises.ToList();
            var selected = new List<ExerciseDefinition>();
            foreach (var mistake in Prioritize(mistakes, now))
            {
                var alternative = available.FirstOrDefault(exercise =>
                    !recent.Contains(exercise.Id) &&
                    !selected.Any(item => item.Id == exercise.Id) &&
                    exercise.SkillTags.Contains(mistake.SkillTag) &&
                    exercise.Id != mistake.ExerciseId);
                alternative ??= available.FirstOrDefault(exercise =>
                    !recent.Contains(exercise.Id) && !selected.Any(item => item.Id == exercise.Id) && exercise.Id == mistake.ExerciseId);
                if (alternative != null) selected.Add(alternative);
                if (selected.Count >= count) break;
            }
            return selected;
        }

        public IReadOnlyList<SkillAnalysis> Analyze(IEnumerable<MistakeRecord> mistakes)
            => mistakes.GroupBy(item => item.SkillTag, StringComparer.Ordinal)
                .Select(group =>
                {
                    var total = group.Count();
                    var corrected = group.Count(item => item.CorrectedLater);
                    var common = group.GroupBy(item => item.Category).OrderByDescending(item => item.Count()).First().Key;
                    return new SkillAnalysis(group.Key, total, corrected, total == 0 ? 1d : (double)corrected / total, common);
                })
                .OrderBy(item => item.Confidence)
                .ThenByDescending(item => item.MistakeCount)
                .ToList();

        public DailyReviewPlan CreateDailyPlan(IEnumerable<MistakeRecord> mistakes, IEnumerable<ExerciseDefinition> exercises,
            IEnumerable<string> recentlyShownExerciseIds, DateTimeOffset now, int count = 5)
        {
            var date = now.UtcDateTime.ToString("yyyy-MM-dd");
            return new DailyReviewPlan("review-" + date, date,
                BuildDailyReview(mistakes, exercises, recentlyShownExerciseIds, now, count).Select(item => item.Id));
        }

        private static double Score(MistakeRecord mistake, DateTimeOffset now)
        {
            var ageHours = Math.Max(0d, (now - mistake.AttemptedAt).TotalHours);
            var recency = Math.Max(0d, 72d - ageHours) / 24d;
            var overdue = Math.Max(0d, (now - mistake.NextReviewAt).TotalDays) * 2d;
            var repetition = mistake.AttemptNumber * 2d;
            var correctedReduction = mistake.CorrectedLater ? mistake.SuccessfulReviews * 3d : 0d;
            return recency + overdue + repetition - correctedReduction;
        }
    }

    public sealed class DailyReviewPlan
    {
        public DailyReviewPlan(string id, string date, IEnumerable<string> exerciseIds)
        {
            Id = id;
            Date = date;
            ExerciseIds = exerciseIds.ToList().AsReadOnly();
        }
        public string Id { get; }
        public string Date { get; }
        public IReadOnlyList<string> ExerciseIds { get; }
    }
}
