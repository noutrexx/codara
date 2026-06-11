using UnityEngine;
using UnityEngine.UI;

namespace Codara.Presentation.DesignSystem
{
    [RequireComponent(typeof(LayoutElement))]
    public sealed class MinimumTouchTarget : MonoBehaviour
    {
        [SerializeField, Min(1f)] private float fallbackSize = 48f;

        private void Awake()
        {
            Apply();
        }

        public void Apply()
        {
            var size = DesignSystemContext.Theme != null
                ? DesignSystemContext.Theme.MinimumTouchTarget
                : fallbackSize;
            var layout = GetComponent<LayoutElement>();
            layout.minWidth = size;
            layout.minHeight = size;
        }
    }
}
