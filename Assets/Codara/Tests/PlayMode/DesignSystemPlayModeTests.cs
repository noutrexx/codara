using System.Collections;
using Codara.Presentation.DesignSystem;
using Codara.Presentation.DesignSystem.Components;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Codara.Tests.PlayMode
{
    public sealed class DesignSystemPlayModeTests
    {
        [UnityTest]
        public IEnumerator ProgressBar_ClampsValue()
        {
            var gameObject = new GameObject("Progress", typeof(RectTransform), typeof(ProgressBar));
            var progress = gameObject.GetComponent<ProgressBar>();

            progress.SetValue(2f);
            yield return null;

            Assert.That(progress.Value, Is.EqualTo(1f));
            Object.Destroy(gameObject);
        }

        [UnityTest]
        public IEnumerator SafeAreaPanel_UsesNormalizedAnchors()
        {
            var gameObject = new GameObject("SafeArea", typeof(RectTransform), typeof(SafeAreaPanel));
            var panel = gameObject.GetComponent<SafeAreaPanel>();
            panel.Apply();
            yield return null;

            var rect = gameObject.GetComponent<RectTransform>();
            Assert.That(rect.anchorMin.x, Is.InRange(0f, 1f));
            Assert.That(rect.anchorMax.x, Is.InRange(0f, 1f));
            Object.Destroy(gameObject);
        }
    }
}
