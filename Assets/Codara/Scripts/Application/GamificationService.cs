using System;
using Codara.Domain;

namespace Codara.Application
{
    public sealed class GamificationService
    {
        public bool Grant(ByteLedger ledger, ByteSource source, string sourceId, int amount)
        {
            if (ledger == null) throw new ArgumentNullException(nameof(ledger));
            return ledger.Award($"{source}:{sourceId}", amount);
        }

        public bool CompleteAndReward(ProgressDefinition definition, ProgressTracker tracker, ByteLedger ledger, ByteSource source)
        {
            if (!tracker.Complete(definition)) return false;
            return Grant(ledger, source, definition.Id, definition.ByteReward);
        }
    }

    public sealed class TrustedTimeGuard
    {
        public bool IsSuspicious(DateTimeOffset previousTrustedUtc, DateTimeOffset currentUtc, TimeSpan maximumForwardJump)
            => currentUtc < previousTrustedUtc || currentUtc - previousTrustedUtc > maximumForwardJump;

        public string DayKey(DateTimeOffset trustedUtc, TimeSpan userOffset)
            => trustedUtc.ToOffset(userOffset).ToString("yyyy-MM-dd");
    }
}
