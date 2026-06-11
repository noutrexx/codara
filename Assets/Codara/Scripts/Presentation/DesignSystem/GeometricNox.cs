using UnityEngine;
using UnityEngine.UI;

namespace Codara.Presentation.DesignSystem
{
    public sealed class GeometricNox : MonoBehaviour
    {
        [SerializeField] private Image[] segments;
        [SerializeField] private Image[] eyes;

        private void OnEnable()
        {
            DesignSystemContext.Changed += Refresh;
            Refresh();
        }

        private void OnDisable()
        {
            DesignSystemContext.Changed -= Refresh;
        }

        public void Refresh()
        {
            var theme = DesignSystemContext.Theme;
            if (theme == null)
            {
                return;
            }

            foreach (var segment in segments)
            {
                if (segment != null) segment.color = theme.GetColor(ColorToken.Primary);
            }

            foreach (var eye in eyes)
            {
                if (eye != null) eye.color = theme.GetColor(ColorToken.Secondary, DesignSystemContext.Accessibility.HighContrast);
            }
        }
    }
}
