using UnityEngine;

namespace Codara.Presentation.DesignSystem
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class SafeAreaPanel : MonoBehaviour
    {
        private Rect lastSafeArea;
        private Vector2Int lastScreenSize;
        private RectTransform rectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            Apply();
        }

        private void Update()
        {
            if (lastSafeArea != Screen.safeArea ||
                lastScreenSize.x != Screen.width ||
                lastScreenSize.y != Screen.height)
            {
                Apply();
            }
        }

        public void Apply()
        {
            if (rectTransform == null)
            {
                rectTransform = GetComponent<RectTransform>();
            }

            var safeArea = Screen.safeArea;
            var width = Mathf.Max(1f, Screen.width);
            var height = Mathf.Max(1f, Screen.height);
            rectTransform.anchorMin = new Vector2(safeArea.xMin / width, safeArea.yMin / height);
            rectTransform.anchorMax = new Vector2(safeArea.xMax / width, safeArea.yMax / height);
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
            lastSafeArea = safeArea;
            lastScreenSize = new Vector2Int(Screen.width, Screen.height);
        }
    }
}
