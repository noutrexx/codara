using System;
using Codara.Application;
using Codara.Domain;
using UnityEngine;

namespace Codara.Infrastructure
{
    public sealed class LocalOnboardingRepository : IOnboardingRepository
    {
        private const string SaveKey = "onboarding-state";
        private readonly ILocalSaveService saves;

        public LocalOnboardingRepository(ILocalSaveService saves) => this.saves = saves ?? throw new ArgumentNullException(nameof(saves));

        public OnboardingState Load()
        {
            var json = saves.Load(SaveKey);
            if (string.IsNullOrWhiteSpace(json)) return new OnboardingState();
            try
            {
                var data = JsonUtility.FromJson<OnboardingData>(json);
                if (data == null || data.version != OnboardingState.CurrentVersion) return new OnboardingState();
                var state = new OnboardingState();
                state.SetGoal((LearningGoal)data.goal);
                state.SetExperience((ProgrammingExperience)data.experience);
                state.SetDailyTarget(data.dailyTargetMinutes);
                state.SetNotificationTime(data.notificationMinutesAfterMidnight);
                state.SetPlacement((PlacementChoice)data.placement);
                for (var index = 0; index < data.step && !state.IsCompleted; index++) state.Advance();
                return state;
            }
            catch (ArgumentException) { return new OnboardingState(); }
        }

        public void Save(OnboardingState state)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));
            saves.Save(SaveKey, JsonUtility.ToJson(new OnboardingData
            {
                version = state.Version,
                step = (int)state.Step,
                goal = (int)state.Goal,
                experience = (int)state.Experience,
                dailyTargetMinutes = state.DailyTargetMinutes,
                notificationMinutesAfterMidnight = state.NotificationMinutesAfterMidnight,
                placement = (int)state.Placement
            }));
        }

        public void Clear() => saves.Delete(SaveKey);

        [Serializable]
        private sealed class OnboardingData
        {
            public int version;
            public int step;
            public int goal;
            public int experience;
            public int dailyTargetMinutes;
            public int notificationMinutesAfterMidnight;
            public int placement;
        }
    }
}
