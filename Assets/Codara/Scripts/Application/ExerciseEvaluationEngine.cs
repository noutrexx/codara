using System;
using System.Collections.Generic;
using System.Linq;
using Codara.Domain;

namespace Codara.Application
{
    public sealed class ExerciseEvaluationEngine
    {
        private readonly HashSet<string> evaluatedAttemptIds = new(StringComparer.Ordinal);

        public ExerciseEvaluation Evaluate(string attemptId, ExerciseDefinition exercise, ExerciseAnswer answer)
        {
            if (string.IsNullOrWhiteSpace(attemptId)) throw new ArgumentException("Attempt id is required.", nameof(attemptId));
            if (exercise == null) throw new ArgumentNullException(nameof(exercise));
            if (answer == null) throw new ArgumentNullException(nameof(answer));
            if (!evaluatedAttemptIds.Add(attemptId)) throw new InvalidOperationException("This answer attempt was already evaluated.");

            var correct = Matches(exercise, answer, exercise.CorrectAnswer) ||
                          exercise.AlternativeAnswers.Any(alternative => Matches(exercise, answer, alternative));
            return new ExerciseEvaluation(
                attemptId,
                exercise.Id,
                correct,
                correct ? exercise.ByteReward : 0,
                correct ? 0 : exercise.ComputePowerPenalty);
        }

        private static bool Matches(ExerciseDefinition exercise, ExerciseAnswer actual, ExerciseAnswer expected)
        {
            if (actual.Tokens.Count != expected.Tokens.Count) return false;
            for (var index = 0; index < actual.Tokens.Count; index++)
            {
                if (!string.Equals(
                        Normalize(exercise.Type, actual.Tokens[index]),
                        Normalize(exercise.Type, expected.Tokens[index]),
                        StringComparison.Ordinal))
                    return false;
            }
            return true;
        }

        private static string Normalize(ExerciseType type, string value)
        {
            var normalized = (value ?? string.Empty).Trim().Replace("\r\n", "\n");
            return type == ExerciseType.ShortAnswer || type == ExerciseType.OutputPrediction || type == ExerciseType.TrueFalse
                ? normalized.ToUpperInvariant()
                : normalized;
        }
    }
}
