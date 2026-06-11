using System;
using System.Collections.Generic;
using System.Linq;
using Codara.Domain;

namespace Codara.Application
{
    public sealed class LearningPathService
    {
        public LessonStatus GetStatus(LessonDefinition lesson, CourseProgress progress, string activeLessonId = null)
        {
            if (lesson == null) throw new ArgumentNullException(nameof(lesson));
            if (progress == null) throw new ArgumentNullException(nameof(progress));
            if (progress.Lessons.TryGetValue(lesson.Id, out var own))
            {
                if (own.Completed) return LessonStatus.Completed;
                if (lesson.Id == activeLessonId) return LessonStatus.Active;
                if (own.Started) return LessonStatus.Started;
            }
            return lesson.Prerequisites.All(id => progress.Lessons.TryGetValue(id, out var item) && item.Completed)
                ? LessonStatus.Available
                : LessonStatus.Locked;
        }

        public CourseProgress Merge(CourseProgress local, CourseProgress remote)
        {
            var merged = new CourseProgress();
            var ids = local.Lessons.Keys.Concat(remote.Lessons.Keys).Distinct(StringComparer.Ordinal);
            foreach (var id in ids)
            {
                local.Lessons.TryGetValue(id, out var left);
                remote.Lessons.TryGetValue(id, out var right);
                var target = merged.GetOrCreate(id);
                if (left?.Started == true || right?.Started == true) target.MarkStarted();
                if (left?.Completed == true || right?.Completed == true)
                    target.Complete(Math.Max(left?.EarnedBytes ?? 0, right?.EarnedBytes ?? 0));
            }
            return merged;
        }
    }
}
