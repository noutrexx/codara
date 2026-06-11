using UnityEngine;
using UnityEngine.UI;

namespace Codara.Presentation.DesignSystem
{
    [RequireComponent(typeof(Graphic))]
    public sealed class ThemeColorBinding : MonoBehaviour
    {
        [SerializeField] private ColorToken colorToken = ColorToken.TextPrimary;

        private Graphic graphic;

        private void Awake()
        {
            graphic = GetComponent<Graphic>();
            Apply();
        }

        private void OnEnable()
        {
            DesignSystemContext.Changed += Apply;
            Apply();
        }

        private void OnDisable()
        {
            DesignSystemContext.Changed -= Apply;
        }

        public void Apply()
        {
            if (graphic == null)
            {
                graphic = GetComponent<Graphic>();
            }

            if (DesignSystemContext.Theme != null)
            {
                graphic.color = DesignSystemContext.Theme.GetColor(
                    colorToken,
                    DesignSystemContext.Accessibility.HighContrast);
            }
        }
    }
}
