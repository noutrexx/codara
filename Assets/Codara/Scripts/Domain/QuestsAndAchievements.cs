using System;
using System.Collections.Generic;

namespace Codara.Domain
{
    public enum ProgressMetric { LessonsCompleted, BytesEarned, CorrectStreak, ReviewsCompleted, MinutesLearned, ProjectsCompleted, ExamsCompleted, SkillsMastered, StreakDays }

    public sealed class ProgressDefinition
    {
        public ProgressDefinition(string id, ProgressMetric metric, int target, int byteReward)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Metric = metric;
            Target = Math.Max(1, target);
            ByteReward = Math.Max(0, byteReward);
        }
        public string Id { get; }
        public ProgressMetric Metric { get; }
        public int Target { get; }
        public int ByteReward { get; }
    }

    public sealed class ProgressTracker
    {
        private readonly Dictionary<ProgressMetric, int> values = new();
        private readonly HashSet<string> completedIds = new(StringComparer.Ordinal);
        public int Get(ProgressMetric metric) => values.TryGetValue(metric, out var value) ? value : 0;
        public void Add(ProgressMetric metric, int amount) => values[metric] = Get(metric) + Math.Max(0, amount);
        public bool Complete(ProgressDefinition definition)
        {
            if (Get(definition.Metric) < definition.Target) return false;
            return completedIds.Add(definition.Id);
        }
    }
}
