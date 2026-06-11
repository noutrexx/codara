using System;
using Codara.Application;
using TMPro;
using UnityEngine;

namespace Codara.Presentation
{
    public sealed class GlobalModal : MonoBehaviour, IModalService
    {
        [SerializeField] private GameObject content;
        [SerializeField] private TMP_Text titleLabel;
        [SerializeField] private TMP_Text messageLabel;

        private Action onClosed;

        public bool IsVisible => content != null && content.activeSelf;

        private void Awake()
        {
            Close();
        }

        public void Show(string title, string message, Action closed = null)
        {
            onClosed = closed;
            if (titleLabel != null)
            {
                titleLabel.text = title ?? string.Empty;
            }

            if (messageLabel != null)
            {
                messageLabel.text = message ?? string.Empty;
            }

            if (content != null)
            {
                content.SetActive(true);
            }
        }

        public void Close()
        {
            if (content != null)
            {
                content.SetActive(false);
            }

            var callback = onClosed;
            onClosed = null;
            callback?.Invoke();
        }
    }
}
