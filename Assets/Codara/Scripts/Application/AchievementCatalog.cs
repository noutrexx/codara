using System.Collections.Generic;
using Codara.Domain;

namespace Codara.Application
{
    public static class AchievementCatalog
    {
        public static IReadOnlyList<ProgressDefinition> CreateDefault() => new[]
        {
            D("first-lesson", ProgressMetric.LessonsCompleted, 1), D("lesson-5", ProgressMetric.LessonsCompleted, 5),
            D("lesson-15", ProgressMetric.LessonsCompleted, 15), D("lesson-30", ProgressMetric.LessonsCompleted, 30),
            D("byte-100", ProgressMetric.BytesEarned, 100), D("byte-500", ProgressMetric.BytesEarned, 500),
            D("byte-1000", ProgressMetric.BytesEarned, 1000), D("streak-3", ProgressMetric.StreakDays, 3),
            D("streak-7", ProgressMetric.StreakDays, 7), D("streak-30", ProgressMetric.StreakDays, 30),
            D("correct-5", ProgressMetric.CorrectStreak, 5), D("correct-15", ProgressMetric.CorrectStreak, 15),
            D("review-1", ProgressMetric.ReviewsCompleted, 1), D("review-10", ProgressMetric.ReviewsCompleted, 10),
            D("minutes-60", ProgressMetric.MinutesLearned, 60), D("minutes-300", ProgressMetric.MinutesLearned, 300),
            D("project-1", ProgressMetric.ProjectsCompleted, 1), D("project-3", ProgressMetric.ProjectsCompleted, 3),
            D("exam-1", ProgressMetric.ExamsCompleted, 1), D("skill-5", ProgressMetric.SkillsMastered, 5)
        };

        private static ProgressDefinition D(string id, ProgressMetric metric, int target) => new(id, metric, target, 10);
    }
}
