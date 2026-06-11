using System;
using Codara.Application;
using Codara.Domain;
using UnityEngine;

namespace Codara.Presentation
{
    public sealed class OnboardingController : MonoBehaviour
    {
        private OnboardingService service;

        public OnboardingState State => service?.State;
        public event Action<OnboardingState> Changed;

        public void Initialize(OnboardingService onboardingService)
        {
            service = onboardingService ?? throw new ArgumentNullException(nameof(onboardingService));
            Changed?.Invoke(service.State);
        }

        public void SetDailyTarget(int minutes) => Update(state => state.SetDailyTarget(minutes));
        public void SetGoal(LearningGoal goal) => Update(state => state.SetGoal(goal));
        public void SetExperience(ProgrammingExperience experience) => Update(state => state.SetExperience(experience));
        public void SetNotificationTime(int minutesAfterMidnight) => Update(state => state.SetNotificationTime(minutesAfterMidnight));
        public void SetPlacement(PlacementChoice placement) => Update(state => state.SetPlacement(placement));

        public void Advance()
        {
            EnsureInitialized();
            service.Advance();
            Changed?.Invoke(service.State);
        }

        private void Update(Action<OnboardingState> change)
        {
            EnsureInitialized();
            service.Update(change);
            Changed?.Invoke(service.State);
        }

        private void EnsureInitialized()
        {
            if (service == null) throw new InvalidOperationException("OnboardingController is not initialized.");
        }
    }
}
