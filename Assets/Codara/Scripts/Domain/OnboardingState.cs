using System;

namespace Codara.Domain
{
    public enum OnboardingStep
    {
        Introduction,
        Goal,
        Experience,
        DailyTarget,
        NotificationTime,
        CourseSelection,
        PlacementChoice,
        FirstLesson,
        Completed
    }

    public enum LearningGoal { Explore, School, Career, SkillBuilding }
    public enum ProgrammingExperience { None, SomeBasics }
    public enum PlacementChoice { StartFromBeginning, TakePlacementTest }

    [Serializable]
    public sealed class OnboardingState
    {
        public const int CurrentVersion = 1;

        public int Version { get; private set; } = CurrentVersion;
        public OnboardingStep Step { get; private set; }
        public LearningGoal Goal { get; private set; }
        public ProgrammingExperience Experience { get; private set; }
        public int DailyTargetMinutes { get; private set; } = 5;
        public int NotificationMinutesAfterMidnight { get; private set; } = 18 * 60;
        public string CourseId { get; private set; } = "python-beginner";
        public PlacementChoice Placement { get; private set; }
        public bool IsCompleted => Step == OnboardingStep.Completed;

        public void SetGoal(LearningGoal value) => Goal = value;
        public void SetExperience(ProgrammingExperience value) => Experience = value;
        public void SetPlacement(PlacementChoice value) => Placement = value;

        public void SetDailyTarget(int minutes)
        {
            if (minutes != 5 && minutes != 10 && minutes != 15 && minutes != 20)
                throw new ArgumentOutOfRangeException(nameof(minutes), "Daily target must be 5, 10, 15 or 20 minutes.");
            DailyTargetMinutes = minutes;
        }

        public void SetNotificationTime(int minutesAfterMidnight)
        {
            if (minutesAfterMidnight < 0 || minutesAfterMidnight >= 24 * 60)
                throw new ArgumentOutOfRangeException(nameof(minutesAfterMidnight));
            NotificationMinutesAfterMidnight = minutesAfterMidnight;
        }

        public void Advance()
        {
            if (!IsCompleted) Step++;
        }
    }
}
