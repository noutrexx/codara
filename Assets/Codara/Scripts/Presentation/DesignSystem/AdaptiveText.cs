using TMPro;
using UnityEngine;

namespace Codara.Presentation.DesignSystem
{
    [RequireComponent(typeof(TMP_Text))]
    public sealed class AdaptiveText : MonoBehaviour
    {
        [SerializeField, Min(8f)] private float baseFontSize = 16f;
        [SerializeField] private bool enableWrapping = true;

        private TMP_Text label;

        private void Awake()
        {
            label = GetComponent<TMP_Text>();
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
            if (label == null)
            {
                label = GetComponent<TMP_Text>();
            }

            label.fontSize = baseFontSize * DesignSystemContext.Accessibility.TextScale;
            label.enableWordWrapping = enableWrapping;
            label.overflowMode = TextOverflowModes.Ellipsis;
        }
    }
}
