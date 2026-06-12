using Codara.Application;
using Codara.Domain;
using UnityEngine;
using UnityEngine.UI;

namespace Codara.Presentation
{
    public sealed class GamificationDemoController : MonoBehaviour
    {
        [SerializeField] private Text byteLabel;
        [SerializeField] private Text streakLabel;
        [SerializeField] private Text energyLabel;
        [SerializeField] private Text questLabel;
        [SerializeField] private Slider energySlider;

        private readonly ByteLedger ledger = new();
        private readonly StreakState streak = new();
        private readonly EnergyState energy = new(5);
        private readonly ProgressTracker quests = new();
        private readonly GamificationService service = new();

        private void Start()
        {
            service.Grant(ledger, ByteSource.Lesson, "demo-lesson", 35);
            streak.CompleteDay("2026-06-12");
            energy.Consume(1);
            quests.Add(ProgressMetric.LessonsCompleted, 1);
            Refresh();
        }

        public void SimulateLesson()
        {
            service.Grant(ledger, ByteSource.Lesson, "demo-" + ledger.Total, 15);
            quests.Add(ProgressMetric.LessonsCompleted, 1);
            energy.Consume(1);
            Refresh();
        }

        private void Refresh()
        {
            if (byteLabel != null) byteLabel.text = $"BYTE  {ledger.Total}";
            if (streakLabel != null) streakLabel.text = $"KOD ZİNCİRİ  {streak.Current} gün";
            if (energyLabel != null) energyLabel.text = $"İŞLEM GÜCÜ  {energy.Current}/{energy.Maximum}";
            if (questLabel != null) questLabel.text = $"GÜNLÜK GÖREV  {quests.Get(ProgressMetric.LessonsCompleted)}/3 ders";
            if (energySlider != null) energySlider.value = (float)energy.Current / energy.Maximum;
        }
    }
}
