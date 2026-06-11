using System;

namespace Codara.Presentation.DesignSystem
{
    public static class DesignSystemContext
    {
        public static event Action Changed;

        public static CodaraTheme Theme { get; private set; }
        public static AccessibilitySettings Accessibility { get; } = new AccessibilitySettings();

        public static void SetTheme(CodaraTheme theme)
        {
            Theme = theme ?? throw new ArgumentNullException(nameof(theme));
            Changed?.Invoke();
        }

        public static void NotifyAccessibilityChanged()
        {
            Changed?.Invoke();
        }
    }
}
