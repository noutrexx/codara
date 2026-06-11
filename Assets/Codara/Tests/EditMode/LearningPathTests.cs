using Codara.Application;
using Codara.Domain;
using NUnit.Framework;

namespace Codara.Tests.EditMode
{
    public sealed class LearningPathTests
    {
        private readonly LearningPathService service = new();

        [Test]
        public void Lesson_UnlocksAfterPrerequisiteCompletion()
        {
            var lesson = new LessonDefinition("lesson-2", "Second", new[] { "lesson-1" }, new[] { "exercise-1" }, 5, 10, Difficulty.Beginner, LessonKind.Lesson);
            var progress = new CourseProgress();
            Assert.That(service.GetStatus(lesson, progress), Is.EqualTo(LessonStatus.Locked));
            progress.GetOrCreate("lesson-1").Complete(10);
            Assert.That(service.GetStatus(lesson, progress), Is.EqualTo(LessonStatus.Available));
        }

        [Test]
        public void Merge_NeverLosesCompletionOrDuplicatesReward()
        {
            var local = new CourseProgress();
            local.GetOrCreate("lesson-1").Complete(10);
            var remote = new CourseProgress();
            remote.GetOrCreate("lesson-1").Complete(10);

            var merged = service.Merge(local, remote);

            Assert.That(merged.Lessons["lesson-1"].Completed, Is.True);
            Assert.That(merged.Lessons["lesson-1"].EarnedBytes, Is.EqualTo(10));
        }
    }
}
