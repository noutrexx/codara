using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Codara.Presentation.DesignSystem.Components
{
    public abstract class CodaraButton : ThemedComponent
    {
        [SerializeField] private Button button;
        [SerializeField] private Image background;
        [SerializeField] private TMP_Text label;
        [SerializeField] private ColorToken backgroundToken = ColorToken.Primary;
        [SerializeField] private ColorToken textToken = ColorToken.TextPrimary;

        public Button Button => button;

        public override void Refresh()
        {
            var theme = DesignSystemContext.Theme;
            if (theme == null)
            {
                return;
            }

            if (background != null)
            {
                background.color = theme.GetColor(backgroundToken, DesignSystemContext.Accessibility.HighContrast);
            }

            if (label != null)
            {
                label.color = theme.GetColor(textToken, DesignSystemContext.Accessibility.HighContrast);
            }
        }
    }

}
