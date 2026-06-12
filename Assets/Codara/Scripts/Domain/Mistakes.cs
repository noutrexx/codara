using System;
using System.Collections.Generic;

namespace Codara.Domain
{
    public enum MistakeCategory
    {
        Syntax,
        VariableLogic,
        ConditionalLogic,
        LoopLogic,
        DataTypeConfusion,
        IndexError,
        FunctionUsage,
        OutputPrediction
    }

    [Serializable]
    public sealed class MistakeRecord
    {
        public MistakeRecord(string id, string userId, string exerciseId, string skillTag, MistakeCategory category,
            ExerciseAnswer givenAnswer, ExerciseAnswer correctAnswer, DateTimeOffset attemptedAt, int attemptNumber)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Mistake id is required.", nameof(id));
            Id = id;
            UserId = userId ?? string.Empty;
            ExerciseId = exerciseId ?? throw new ArgumentNullException(nameof(exerciseId));
            SkillTag = skillTag ?? string.Empty;
            Category = category;
            GivenAnswer = givenAnswer ?? throw new ArgumentNullException(nameof(givenAnswer));
            CorrectAnswer = correctAnswer ?? throw new ArgumentNullException(nameof(correctAnswer));
            AttemptedAt = attemptedAt;
            AttemptNumber = Math.Max(1, attemptNumber);
            NextReviewAt = attemptedAt.AddDays(1);
        }

        public string Id { get; }
        public string UserId { get; }
        public string ExerciseId { get; }
        public string SkillTag { get; }
        public MistakeCategory Category { get; }
        public ExerciseAnswer GivenAnswer { get; }
        public ExerciseAnswer CorrectAnswer { get; }
        public DateTimeOffset AttemptedAt { get; }
        public int AttemptNumber { get; }
        public bool CorrectedLater { get; private set; }
        public DateTimeOffset? CorrectedAt { get; private set; }
        public DateTimeOffset NextReviewAt { get; private set; }
        public int SuccessfulReviews { get; private set; }

        public void RecordReview(bool correct, DateTimeOffset reviewedAt)
        {
            if (correct)
            {
                CorrectedLater = true;
                CorrectedAt = reviewedAt;
                SuccessfulReviews++;
            }
            else
            {
                SuccessfulReviews = 0;
            }

            var intervalDays = correct ? Math.Min(30, 1 << Math.Min(5, SuccessfulReviews)) : 1;
            NextReviewAt = reviewedAt.AddDays(intervalDays);
        }

        public void RestoreReviewState(bool correctedLater, DateTimeOffset? correctedAt, DateTimeOffset nextReviewAt, int successfulReviews)
        {
            CorrectedLater = correctedLater;
            CorrectedAt = correctedAt;
            NextReviewAt = nextReviewAt;
            SuccessfulReviews = Math.Max(0, successfulReviews);
        }
    }

    public sealed class SkillAnalysis
    {
        public SkillAnalysis(string skillTag, int mistakeCount, int correctedCount, double confidence, MistakeCategory? commonCategory)
        {
            SkillTag = skillTag;
            MistakeCount = mistakeCount;
            CorrectedCount = correctedCount;
            Confidence = confidence;
            CommonCategory = commonCategory;
        }
        public string SkillTag { get; }
        public int MistakeCount { get; }
        public int CorrectedCount { get; }
        public double Confidence { get; }
        public MistakeCategory? CommonCategory { get; }
    }
}
