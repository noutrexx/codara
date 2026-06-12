using System;
using Codara.Application;
using Codara.Domain;
using NUnit.Framework;

namespace Codara.Tests.EditMode
{
    public sealed class GamificationTests
    {
        [Test]
        public void ByteLedger_RejectsDuplicateReward()
        {
            var ledger = new ByteLedger();
            Assert.That(ledger.Award("lesson:1", 10), Is.True);
            Assert.That(ledger.Award("lesson:1", 10), Is.False);
            Assert.That(ledger.Total, Is.EqualTo(10));
        }

        [Test]
        public void Streak_DoesNotAdvanceTwiceForSameDay()
        {
            var streak = new StreakState();
            Assert.That(streak.CompleteDay("2026-06-12"), Is.True);
            Assert.That(streak.CompleteDay("2026-06-12"), Is.False);
            Assert.That(streak.Current, Is.EqualTo(1));
        }

        [Test]
        public void Streak_BackupProtectsOneMissedDay()
        {
            var streak = new StreakState();
            streak.AddBackup();
            Assert.That(streak.ProtectMissedDay(), Is.True);
            Assert.That(streak.ProtectMissedDay(), Is.False);
            Assert.That(streak.Status, Is.EqualTo(StreakStatus.Protected));
        }

        [Test]
        public void Energy_UnlimitedPracticeDoesNotConsume()
        {
            var energy = new EnergyState(5);
            energy.SetUnlimitedPractice(true);
            Assert.That(energy.Consume(3), Is.True);
            Assert.That(energy.Current, Is.EqualTo(5));
        }

        [Test]
        public void TrustedTimeGuard_DetectsClockRollbackAndLargeJump()
        {
            var guard = new TrustedTimeGuard();
            var trusted = DateTimeOffset.UtcNow;
            Assert.That(guard.IsSuspicious(trusted, trusted.AddMinutes(-1), TimeSpan.FromDays(2)), Is.True);
            Assert.That(guard.IsSuspicious(trusted, trusted.AddDays(5), TimeSpan.FromDays(2)), Is.True);
        }

        [Test]
        public void AchievementCatalog_ContainsAtLeastTwentyDefinitions()
            => Assert.That(AchievementCatalog.CreateDefault().Count, Is.GreaterThanOrEqualTo(20));

        [Test]
        public void ProgressCompletion_CannotRewardTwice()
        {
            var tracker = new ProgressTracker();
            var ledger = new ByteLedger();
            var definition = new ProgressDefinition("quest-1", ProgressMetric.LessonsCompleted, 1, 20);
            tracker.Add(ProgressMetric.LessonsCompleted, 1);
            var service = new GamificationService();
            Assert.That(service.CompleteAndReward(definition, tracker, ledger, ByteSource.DailyQuest), Is.True);
            Assert.That(service.CompleteAndReward(definition, tracker, ledger, ByteSource.DailyQuest), Is.False);
            Assert.That(ledger.Total, Is.EqualTo(20));
        }
    }
}
