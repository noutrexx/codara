using System;
using Codara.Domain;
using NUnit.Framework;

namespace Codara.Tests.EditMode
{
    public sealed class LessonSessionTests
    {
        [Test]
        public void Session_LocksInputOutsideAwaitingAnswer()
        {
            var session = new LessonSession("session", "lesson", 1);
            Assert.That(session.InputLocked, Is.True);
            session.Begin();
            Assert.That(session.InputLocked, Is.False);
            session.StartEvaluation();
            Assert.That(session.InputLocked, Is.True);
        }

        [Test]
        public void Session_CompletesAfterLastExplanation()
        {
            var session = new LessonSession("session", "lesson", 1);
            session.Begin();
            session.StartEvaluation();
            session.RecordEvaluation(new ExerciseEvaluation("a1", "e1", true, 5, 0));
            session.ShowExplanation();
            session.Continue();
            Assert.That(session.State, Is.EqualTo(LessonSessionState.Completed));
            Assert.That(session.EarnedBytes, Is.EqualTo(5));
        }

        [Test]
        public void Session_RejectsDuplicateExerciseCompletion()
        {
            var session = new LessonSession("session", "lesson", 2);
            session.Begin();
            session.StartEvaluation();
            session.RecordEvaluation(new ExerciseEvaluation("a1", "e1", true, 5, 0));
            session.ShowExplanation();
            session.Continue();
            session.StartEvaluation();
            Assert.Throws<InvalidOperationException>(() =>
                session.RecordEvaluation(new ExerciseEvaluation("a2", "e1", true, 5, 0)));
        }
    }
}
