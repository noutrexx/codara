using System;
using System.Collections.Generic;

namespace Codara.Domain
{
    public enum ByteSource { Lesson, CorrectStreak, DailyQuest, Review, MiniProject, SectionExam, Achievement }

    public sealed class ByteLedger
    {
        private readonly HashSet<string> rewardIds = new(StringComparer.Ordinal);
        public int Total { get; private set; }
        public IReadOnlyCollection<string> RewardIds => rewardIds;

        public bool Award(string rewardId, int amount)
        {
            if (string.IsNullOrWhiteSpace(rewardId)) throw new ArgumentException("Reward id is required.", nameof(rewardId));
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
            if (!rewardIds.Add(rewardId)) return false;
            Total += amount;
            return true;
        }
    }

    public enum StreakStatus { Active, Protected, Broken, PendingVerification }

    public sealed class StreakState
    {
        private readonly HashSet<string> completedDayKeys = new(StringComparer.Ordinal);
        public int Current { get; private set; }
        public int Best { get; private set; }
        public int Backups { get; private set; }
        public string LastCompletedDayKey { get; private set; } = string.Empty;
        public StreakStatus Status { get; private set; } = StreakStatus.Active;

        public bool CompleteDay(string trustedDayKey)
        {
            if (string.IsNullOrWhiteSpace(trustedDayKey)) throw new ArgumentException("Trusted day key is required.", nameof(trustedDayKey));
            if (!completedDayKeys.Add(trustedDayKey)) return false;
            Current++;
            Best = Math.Max(Best, Current);
            LastCompletedDayKey = trustedDayKey;
            Status = StreakStatus.Active;
            return true;
        }

        public void AddBackup() => Backups++;

        public bool ProtectMissedDay()
        {
            if (Backups <= 0) return false;
            Backups--;
            Status = StreakStatus.Protected;
            return true;
        }

        public void Break()
        {
            Current = 0;
            Status = StreakStatus.Broken;
        }
    }

    public sealed class EnergyState
    {
        public EnergyState(int maximum, int current = -1)
        {
            if (maximum <= 0) throw new ArgumentOutOfRangeException(nameof(maximum));
            Maximum = maximum;
            Current = current < 0 ? maximum : Math.Min(maximum, Math.Max(0, current));
        }
        public int Maximum { get; }
        public int Current { get; private set; }
        public bool UnlimitedPractice { get; private set; }

        public void SetUnlimitedPractice(bool enabled) => UnlimitedPractice = enabled;
        public bool Consume(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
            if (UnlimitedPractice) return true;
            if (Current < amount) return false;
            Current -= amount;
            return true;
        }
        public void Restore(int amount) => Current = Math.Min(Maximum, Current + Math.Max(0, amount));
    }
}
