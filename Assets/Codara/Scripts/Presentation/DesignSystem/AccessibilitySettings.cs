using System;

namespace Codara.Presentation.DesignSystem
{
    [Serializable]
    public sealed class AccessibilitySettings
    {
        private const float MinimumTextScale = 0.85f;
        private const float MaximumTextScale = 1.5f;

        public float TextScale { get; private set; } = 1f;
        public bool HighContrast { get; private set; }
        public bool ReduceMotion { get; private set; }

        public void SetTextScale(float scale)
        {
            TextScale = Math.Max(MinimumTextScale, Math.Min(MaximumTextScale, scale));
        }

        public void SetHighContrast(bool enabled)
        {
            HighContrast = enabled;
        }

        public void SetReduceMotion(bool enabled)
        {
            ReduceMotion = enabled;
        }
    }
}
