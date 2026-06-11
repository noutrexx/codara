using System.Collections.Generic;
using Codara.Application;
using Codara.Domain;
using Codara.Infrastructure;
using NUnit.Framework;

namespace Codara.Tests.EditMode
{
    public sealed class OnboardingTests
    {
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        [TestCase(20)]
        public void DailyTarget_AcceptsSupportedValues(int value)
        {
            var state = new OnboardingState();
            state.SetDailyTarget(value);
            Assert.That(state.DailyTargetMinutes, Is.EqualTo(value));
        }

        [Test]
        public void DailyTarget_RejectsUnsupportedValue()
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => new OnboardingState().SetDailyTarget(30));
        }

        [Test]
        public void Repository_RestoresOfflineProgress()
        {
            var saves = new MemorySaveService();
            var repository = new LocalOnboardingRepository(saves);
            var state = new OnboardingState();
            state.SetDailyTarget(15);
            state.SetGoal(LearningGoal.Career);
            state.Advance();
            state.Advance();
            repository.Save(state);

            var restored = new LocalOnboardingRepository(saves).Load();

            Assert.That(restored.Step, Is.EqualTo(OnboardingStep.Experience));
            Assert.That(restored.DailyTargetMinutes, Is.EqualTo(15));
            Assert.That(restored.Goal, Is.EqualTo(LearningGoal.Career));
        }

        [Test]
        public void ErrorMapper_HidesTechnicalError()
        {
            var message = AuthenticationErrorMapper.ToUserMessage("internal-firebase-stack-trace");
            Assert.That(message, Does.Not.Contain("firebase").IgnoreCase);
        }

        private sealed class MemorySaveService : ILocalSaveService
        {
            private readonly Dictionary<string, string> values = new();
            public bool Exists(string key) => values.ContainsKey(key);
            public string Load(string key) => values.TryGetValue(key, out var value) ? value : null;
            public void Save(string key, string content) => values[key] = content;
            public void Delete(string key) => values.Remove(key);
        }
    }
}
