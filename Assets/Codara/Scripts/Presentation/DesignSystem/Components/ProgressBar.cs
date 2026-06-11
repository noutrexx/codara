using UnityEngine;
using UnityEngine.UI;

namespace Codara.Presentation.DesignSystem.Components
{
    public class ProgressBar : ThemedComponent
    {
        [SerializeField] private Image fill;
        [SerializeField] private Image track;
        [SerializeField, Range(0f, 1f)] private float value;

        public float Value => value;

        public void SetValue(float nextValue)
        {
            value = Mathf.Clamp01(nextValue);
            if (fill != null) fill.fillAmount = value;
        }

        public override void Refresh()
        {
            var theme = DesignSystemContext.Theme;
            if (theme == null) return;
            if (fill != null)
            {
                fill.color = theme.GetColor(ColorToken.Secondary, DesignSystemContext.Accessibility.HighContrast);
                fill.fillAmount = value;
            }
            if (track != null) track.color = theme.GetColor(ColorToken.SurfaceRaised);
        }
    }
}
