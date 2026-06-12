using System;
using System.Collections.Generic;
using System.Linq;
using Codara.Domain;

namespace Codara.Application
{
    public sealed class MistakeRecorder
    {
        private readonly IMistakeRepository repository;

        public MistakeRecorder(IMistakeRepository repository) => this.repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public MistakeRecord Record(string id, string userId, ExerciseDefinition exercise, ExerciseAnswer givenAnswer,
            ExerciseEvaluation evaluation, DateTimeOffset attemptedAt)
        {
            if (evaluation == null) throw new ArgumentNullException(nameof(evaluation));
            if (evaluation.IsCorrect) throw new InvalidOperationException("Correct evaluations are not mistake records.");
            if (exercise == null) throw new ArgumentNullException(nameof(exercise));

            var records = repository.Load().ToList();
            if (records.Any(item => item.Id == id)) throw new InvalidOperationException("Mistake was already recorded.");
            var attemptNumber = records.Count(item => item.ExerciseId == exercise.Id) + 1;
            var skill = exercise.SkillTags.FirstOrDefault() ?? string.Empty;
            var category = ParseCategory(exercise.ErrorCategories.FirstOrDefault());
            var record = new MistakeRecord(id, userId, exercise.Id, skill, category, givenAnswer, exercise.CorrectAnswer, attemptedAt, attemptNumber);
            records.Add(record);
            repository.Save(records);
            return record;
        }

        private static MistakeCategory ParseCategory(string value)
            => Enum.TryParse(value, true, out MistakeCategory category) ? category : MistakeCategory.Syntax;
    }
}
