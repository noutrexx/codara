using System;
using System.Collections.Generic;

namespace Codara.Domain
{
    public enum ExerciseType
    {
        OutputPrediction,
        FillMissingCode,
        OrderCodeLines,
        SelectFaultyLine,
        ShortAnswer,
        TrueFalse,
        ConceptMatching,
        BuildProgram
    }

    [Serializable]
    public sealed class ExerciseAnswer
    {
        public ExerciseAnswer(IEnumerable<string> tokens)
        {
            Tokens = new List<string>(tokens ?? Array.Empty<string>()).AsReadOnly();
        }

        public IReadOnlyList<string> Tokens { get; }
        public static ExerciseAnswer From(params string[] tokens) => new ExerciseAnswer(tokens);
    }

    [Serializable]
    public sealed class ExerciseDefinition
    {
        public ExerciseDefinition(
            string id,
            ExerciseType type,
            string question,
            string code,
            ExerciseAnswer correctAnswer,
            IEnumerable<ExerciseAnswer> alternativeAnswers = null,
            string explanation = "",
            string hint = "",
            Difficulty difficulty = Difficulty.Beginner,
            IEnumerable<string> skillTags = null,
            IEnumerable<string> errorCategories = null,
            int byteReward = 1,
            int computePowerPenalty = 1)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Exercise id is required.", nameof(id));
            Id = id;
            Type = type;
            Question = question ?? string.Empty;
            Code = code ?? string.Empty;
            CorrectAnswer = correctAnswer ?? throw new ArgumentNullException(nameof(correctAnswer));
            AlternativeAnswers = new List<ExerciseAnswer>(alternativeAnswers ?? Array.Empty<ExerciseAnswer>()).AsReadOnly();
            Explanation = explanation ?? string.Empty;
            Hint = hint ?? string.Empty;
            Difficulty = difficulty;
            SkillTags = new List<string>(skillTags ?? Array.Empty<string>()).AsReadOnly();
            ErrorCategories = new List<string>(errorCategories ?? Array.Empty<string>()).AsReadOnly();
            ByteReward = Math.Max(0, byteReward);
            ComputePowerPenalty = Math.Max(0, computePowerPenalty);
        }

        public string Id { get; }
        public ExerciseType Type { get; }
        public string Question { get; }
        public string Code { get; }
        public ExerciseAnswer CorrectAnswer { get; }
        public IReadOnlyList<ExerciseAnswer> AlternativeAnswers { get; }
        public string Explanation { get; }
        public string Hint { get; }
        public Difficulty Difficulty { get; }
        public IReadOnlyList<string> SkillTags { get; }
        public IReadOnlyList<string> ErrorCategories { get; }
        public int ByteReward { get; }
        public int ComputePowerPenalty { get; }
    }

    public sealed class ExerciseEvaluation
    {
        public ExerciseEvaluation(string attemptId, string exerciseId, bool isCorrect, int earnedBytes, int computePowerPenalty)
        {
            AttemptId = attemptId;
            ExerciseId = exerciseId;
            IsCorrect = isCorrect;
            EarnedBytes = earnedBytes;
            ComputePowerPenalty = computePowerPenalty;
        }

        public string AttemptId { get; }
        public string ExerciseId { get; }
        public bool IsCorrect { get; }
        public int EarnedBytes { get; }
        public int ComputePowerPenalty { get; }
    }
}
