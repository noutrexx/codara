using Codara.Presentation.DesignSystem;
using NUnit.Framework;
using UnityEngine;

namespace Codara.Tests.EditMode
{
    public sealed class DesignSystemTests
    {
        [Test]
        public void AccessibilitySettings_ClampTextScale()
        {
            var settings = new AccessibilitySettings();

            settings.SetTextScale(10f);
            Assert.That(settings.TextScale, Is.EqualTo(1.5f));

            settings.SetTextScale(0f);
            Assert.That(settings.TextScale, Is.EqualTo(0.85f));
        }

        [Test]
        public void HighContrast_ReplacesSecondaryTextColor()
        {
            var theme = ScriptableObject.CreateInstance<CodaraTheme>();

            Assert.That(
                theme.GetColor(ColorToken.TextSecondary, true),
                Is.EqualTo(theme.GetColor(ColorToken.TextPrimary)));
        }

        [Test]
        public void Theme_HasAccessibleMinimumTouchTarget()
        {
            var theme = ScriptableObject.CreateInstance<CodaraTheme>();

            Assert.That(theme.MinimumTouchTarget, Is.GreaterThanOrEqualTo(48f));
        }
    }
}
