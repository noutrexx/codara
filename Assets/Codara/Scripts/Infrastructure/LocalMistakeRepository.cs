using System;
using System.Collections.Generic;
using System.Globalization;
using Codara.Application;
using Codara.Domain;
using UnityEngine;

namespace Codara.Infrastructure
{
    public sealed class LocalMistakeRepository : IMistakeRepository
    {
        private const string SaveKey = "mistake-records";
        private readonly ILocalSaveService saves;

        public LocalMistakeRepository(ILocalSaveService saves) => this.saves = saves ?? throw new ArgumentNullException(nameof(saves));

        public IReadOnlyList<MistakeRecord> Load()
        {
            var json = saves.Load(SaveKey);
            if (string.IsNullOrWhiteSpace(json)) return Array.Empty<MistakeRecord>();
            try
            {
                var data = JsonUtility.FromJson<CollectionData>(json);
                var result = new List<MistakeRecord>();
                if (data?.items == null) return result;
                foreach (var item in data.items)
                {
                    if (item == null || !Parse(item.attemptedAt, out var attemptedAt)) continue;
                    if (!Parse(item.nextReviewAt, out var nextReviewAt)) nextReviewAt = attemptedAt.AddDays(1);
                    var record = new MistakeRecord(item.id, item.userId, item.exerciseId, item.skillTag, (MistakeCategory)item.category,
                        new ExerciseAnswer(item.givenTokens), new ExerciseAnswer(item.correctTokens), attemptedAt, item.attemptNumber);
                    DateTimeOffset? correctedAt = Parse(item.correctedAt, out var parsedCorrectedAt) ? parsedCorrectedAt : null;
                    record.RestoreReviewState(item.correctedLater, correctedAt, nextReviewAt, item.successfulReviews);
                    result.Add(record);
                }
                return result;
            }
            catch (ArgumentException) { return Array.Empty<MistakeRecord>(); }
        }

        public void Save(IReadOnlyList<MistakeRecord> mistakes)
        {
            var data = new CollectionData();
            foreach (var record in mistakes)
            {
                data.items.Add(new RecordData
                {
                    id = record.Id,
                    userId = record.UserId,
                    exerciseId = record.ExerciseId,
                    skillTag = record.SkillTag,
                    category = (int)record.Category,
                    givenTokens = new List<string>(record.GivenAnswer.Tokens),
                    correctTokens = new List<string>(record.CorrectAnswer.Tokens),
                    attemptedAt = record.AttemptedAt.ToString("O"),
                    attemptNumber = record.AttemptNumber,
                    correctedLater = record.CorrectedLater,
                    correctedAt = record.CorrectedAt?.ToString("O") ?? string.Empty,
                    nextReviewAt = record.NextReviewAt.ToString("O"),
                    successfulReviews = record.SuccessfulReviews
                });
            }
            saves.Save(SaveKey, JsonUtility.ToJson(data));
        }

        private static bool Parse(string value, out DateTimeOffset result)
            => DateTimeOffset.TryParseExact(value, "O", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);

        [Serializable] private sealed class CollectionData { public List<RecordData> items = new(); }
        [Serializable] private sealed class RecordData
        {
            public string id;
            public string userId;
            public string exerciseId;
            public string skillTag;
            public int category;
            public List<string> givenTokens = new();
            public List<string> correctTokens = new();
            public string attemptedAt;
            public int attemptNumber;
            public bool correctedLater;
            public string correctedAt;
            public string nextReviewAt;
            public int successfulReviews;
        }
    }
}
