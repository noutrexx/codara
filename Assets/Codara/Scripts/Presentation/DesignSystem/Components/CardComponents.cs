using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Codara.Presentation.DesignSystem.Components
{
    public class ThemedCard : ThemedComponent
    {
        [SerializeField] private Image surface;
        [SerializeField] private TMP_Text title;
        [SerializeField] private TMP_Text description;

        public void SetContent(string heading, string body)
        {
            if (title != null) title.text = heading ?? string.Empty;
            if (description != null) description.text = body ?? string.Empty;
        }

        public override void Refresh()
        {
            var theme = DesignSystemContext.Theme;
            if (theme == null)
            {
                return;
            }

            if (surface != null) surface.color = theme.GetColor(ColorToken.SurfaceRaised);
            if (title != null) title.color = theme.GetColor(ColorToken.TextPrimary, DesignSystemContext.Accessibility.HighContrast);
            if (description != null) description.color = theme.GetColor(ColorToken.TextSecondary, DesignSystemContext.Accessibility.HighContrast);
        }
    }

}
