using System;
using Codara.Application;
using Codara.Domain;
using NUnit.Framework;

namespace Codara.Tests.EditMode
{
    public sealed class ExerciseEvaluationEngineTests
    {
        [TestCase(ExerciseType.OutputPrediction)]
        [TestCase(ExerciseType.FillMissingCode)]
        [TestCase(ExerciseType.OrderCodeLines)]
        [TestCase(ExerciseType.SelectFaultyLine)]
        [TestCase(ExerciseType.ShortAnswer)]
        [TestCase(ExerciseType.TrueFalse)]
        [TestCase(ExerciseType.ConceptMatching)]
        [TestCase(ExerciseType.BuildProgram)]
        public void Evaluate_SupportsEveryExerciseType(ExerciseType type)
        {
            var exercise = CreateExercise(type);
            var result = new ExerciseEvaluationEngine().Evaluate("attempt-1", exercise, ExerciseAnswer.From("answer"));
            Assert.That(result.IsCorrect, Is.True);
            Assert.That(result.EarnedBytes, Is.EqualTo(5));
        }

        [Test]
        public void Evaluate_AcceptsAlternativeAnswer()
        {
            var exercise = new ExerciseDefinition("e1", ExerciseType.ShortAnswer, "", "", ExerciseAnswer.From("true"),
                new[] { ExerciseAnswer.From("yes") });
            Assert.That(new ExerciseEvaluationEngine().Evaluate("a1", exercise, ExerciseAnswer.From(" YES ")).IsCorrect, Is.True);
        }

        [Test]
        public void Evaluate_RejectsDuplicateAttempt()
        {
            var engine = new ExerciseEvaluationEngine();
            var exercise = CreateExercise(ExerciseType.TrueFalse);
            engine.Evaluate("attempt-1", exercise, ExerciseAnswer.From("answer"));
            Assert.Throws<InvalidOperationException>(() => engine.Evaluate("attempt-1", exercise, ExerciseAnswer.From("answer")));
        }

        [Test]
        public void Evaluate_WrongAnswerAppliesPenaltyWithoutBytes()
        {
            var result = new ExerciseEvaluationEngine().Evaluate("a1", CreateExercise(ExerciseType.ShortAnswer), ExerciseAnswer.From("wrong"));
            Assert.That(result.IsCorrect, Is.False);
            Assert.That(result.EarnedBytes, Is.Zero);
            Assert.That(result.ComputePowerPenalty, Is.EqualTo(2));
        }

        private static ExerciseDefinition CreateExercise(ExerciseType type)
            => new ExerciseDefinition("exercise-" + type, type, "Question", "code", ExerciseAnswer.From("answer"),
                byteReward: 5, computePowerPenalty: 2);
    }
}
