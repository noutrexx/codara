using System;
using System.Collections.Generic;

namespace Codara.Domain
{
    [Serializable]
    public sealed class LessonProgress
    {
        public LessonProgress(string lessonId, bool started = false, bool completed = false, int earnedBytes = 0)
        {
            LessonId = lessonId ?? throw new ArgumentNullException(nameof(lessonId));
            Started = started;
            Completed = completed;
            EarnedBytes = earnedBytes;
        }
        public string LessonId { get; }
        public bool Started { get; private set; }
        public bool Completed { get; private set; }
        public int EarnedBytes { get; private set; }
        public void MarkStarted() => Started = true;
        public void Complete(int bytes)
        {
            Started = true;
            Completed = true;
            EarnedBytes = Math.Max(EarnedBytes, bytes);
        }
    }

    public sealed class CourseProgress
    {
        private readonly Dictionary<string, LessonProgress> lessons = new(StringComparer.Ordinal);
        public IReadOnlyDictionary<string, LessonProgress> Lessons => lessons;
        public LessonProgress GetOrCreate(string lessonId)
        {
            if (!lessons.TryGetValue(lessonId, out var progress))
                lessons[lessonId] = progress = new LessonProgress(lessonId);
            return progress;
        }
    }
}
