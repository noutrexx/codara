using System;
using System.Collections.Generic;

namespace Codara.Domain
{
    public enum Difficulty { Beginner, Easy, Medium, Hard }
    public enum LessonKind { Lesson, Review, SectionExam, MiniProject }
    public enum LessonStatus { Locked, Available, Active, Started, Completed, ReviewSuggested }

    [Serializable]
    public sealed class LessonDefinition
    {
        public LessonDefinition(string id, string title, IEnumerable<string> prerequisites, IEnumerable<string> exerciseIds,
            int estimatedMinutes, int byteReward, Difficulty difficulty, LessonKind kind)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Lesson id is required.", nameof(id));
            Id = id;
            Title = title ?? string.Empty;
            Prerequisites = new List<string>(prerequisites ?? Array.Empty<string>()).AsReadOnly();
            ExerciseIds = new List<string>(exerciseIds ?? Array.Empty<string>()).AsReadOnly();
            EstimatedMinutes = estimatedMinutes;
            ByteReward = byteReward;
            Difficulty = difficulty;
            Kind = kind;
        }
        public string Id { get; }
        public string Title { get; }
        public IReadOnlyList<string> Prerequisites { get; }
        public IReadOnlyList<string> ExerciseIds { get; }
        public int EstimatedMinutes { get; }
        public int ByteReward { get; }
        public Difficulty Difficulty { get; }
        public LessonKind Kind { get; }
    }

    [Serializable]
    public sealed class UnitDefinition
    {
        public UnitDefinition(string id, IEnumerable<LessonDefinition> lessons)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Lessons = new List<LessonDefinition>(lessons ?? Array.Empty<LessonDefinition>()).AsReadOnly();
        }
        public string Id { get; }
        public IReadOnlyList<LessonDefinition> Lessons { get; }
    }

    [Serializable]
    public sealed class SectionDefinition
    {
        public SectionDefinition(string id, IEnumerable<UnitDefinition> units)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Units = new List<UnitDefinition>(units ?? Array.Empty<UnitDefinition>()).AsReadOnly();
        }
        public string Id { get; }
        public IReadOnlyList<UnitDefinition> Units { get; }
    }

    [Serializable]
    public sealed class CourseDefinition
    {
        public CourseDefinition(string id, int version, IEnumerable<SectionDefinition> sections)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Version = version;
            Sections = new List<SectionDefinition>(sections ?? Array.Empty<SectionDefinition>()).AsReadOnly();
        }
        public string Id { get; }
        public int Version { get; }
        public IReadOnlyList<SectionDefinition> Sections { get; }
    }
}
