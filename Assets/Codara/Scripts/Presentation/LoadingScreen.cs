using Codara.Application;
using UnityEngine;

namespace Codara.Presentation
{
    public sealed class LoadingScreen : MonoBehaviour, ILoadingScreen
    {
        [SerializeField] private CanvasGroup canvasGroup;

        public bool IsVisible { get; private set; }

        private void Awake()
        {
            SetVisible(false);
        }

        public void Show()
        {
            SetVisible(true);
        }

        public void Hide()
        {
            SetVisible(false);
        }

        private void SetVisible(bool visible)
        {
            IsVisible = visible;
            if (canvasGroup == null)
            {
                return;
            }

            canvasGroup.alpha = visible ? 1f : 0f;
            canvasGroup.blocksRaycasts = visible;
            canvasGroup.interactable = visible;
        }
    }
}
