using System.Collections;
using Codara.Application;
using Codara.Domain;
using Codara.Presentation;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Codara.Tests.PlayMode
{
    public sealed class OnboardingControllerPlayModeTests
    {
        [UnityTest]
        public IEnumerator Controller_AdvancesAndPersistsState()
        {
            var repository = new MemoryRepository();
            var gameObject = new GameObject("OnboardingController", typeof(OnboardingController));
            var controller = gameObject.GetComponent<OnboardingController>();
            controller.Initialize(new OnboardingService(repository));

            controller.SetDailyTarget(10);
            controller.Advance();
            yield return null;

            Assert.That(controller.State.Step, Is.EqualTo(OnboardingStep.Goal));
            Assert.That(repository.Saved.DailyTargetMinutes, Is.EqualTo(10));
            Object.Destroy(gameObject);
        }

        private sealed class MemoryRepository : IOnboardingRepository
        {
            public OnboardingState Saved { get; private set; } = new OnboardingState();
            public OnboardingState Load() => Saved;
            public void Save(OnboardingState state) => Saved = state;
            public void Clear() => Saved = new OnboardingState();
        }
    }
}
