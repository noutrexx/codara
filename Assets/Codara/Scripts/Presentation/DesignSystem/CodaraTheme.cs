using System;
using UnityEngine;

namespace Codara.Presentation.DesignSystem
{
    public enum ThemeMode
    {
        Dark,
        Light
    }

    public enum ColorToken
    {
        Background,
        Surface,
        SurfaceRaised,
        Primary,
        Secondary,
        Success,
        Error,
        Warning,
        TextPrimary,
        TextSecondary,
        Border,
        Overlay
    }

    [CreateAssetMenu(menuName = "Codara/Design System/Theme", fileName = "CodaraTheme")]
    public sealed class CodaraTheme : ScriptableObject
    {
        [SerializeField] private ThemeMode mode = ThemeMode.Dark;
        [SerializeField] private Color background = new Color32(8, 9, 13, 255);
        [SerializeField] private Color surface = new Color32(20, 22, 29, 255);
        [SerializeField] private Color surfaceRaised = new Color32(31, 34, 44, 255);
        [SerializeField] private Color primary = new Color32(145, 72, 255, 255);
        [SerializeField] private Color secondary = new Color32(27, 224, 203, 255);
        [SerializeField] private Color success = new Color32(49, 240, 204, 255);
        [SerializeField] private Color error = new Color32(255, 104, 104, 255);
        [SerializeField] private Color warning = new Color32(255, 185, 64, 255);
        [SerializeField] private Color textPrimary = new Color32(246, 247, 251, 255);
        [SerializeField] private Color textSecondary = new Color32(174, 180, 195, 255);
        [SerializeField] private Color border = new Color32(58, 63, 78, 255);
        [SerializeField] private Color overlay = new Color(0f, 0f, 0f, 0.72f);
        [SerializeField] private float cornerSmall = 8f;
        [SerializeField] private float cornerMedium = 14f;
        [SerializeField] private float cornerLarge = 22f;
        [SerializeField] private float spaceSmall = 8f;
        [SerializeField] private float spaceMedium = 16f;
        [SerializeField] private float spaceLarge = 24f;
        [SerializeField] private float minimumTouchTarget = 48f;
        [SerializeField] private float animationFast = 0.12f;
        [SerializeField] private float animationNormal = 0.22f;

        public ThemeMode Mode => mode;
        public float CornerSmall => cornerSmall;
        public float CornerMedium => cornerMedium;
        public float CornerLarge => cornerLarge;
        public float SpaceSmall => spaceSmall;
        public float SpaceMedium => spaceMedium;
        public float SpaceLarge => spaceLarge;
        public float MinimumTouchTarget => minimumTouchTarget;
        public float AnimationFast => animationFast;
        public float AnimationNormal => animationNormal;

        public Color GetColor(ColorToken token, bool highContrast = false)
        {
            var color = token switch
            {
                ColorToken.Background => background,
                ColorToken.Surface => surface,
                ColorToken.SurfaceRaised => surfaceRaised,
                ColorToken.Primary => primary,
                ColorToken.Secondary => secondary,
                ColorToken.Success => success,
                ColorToken.Error => error,
                ColorToken.Warning => warning,
                ColorToken.TextPrimary => textPrimary,
                ColorToken.TextSecondary => textSecondary,
                ColorToken.Border => border,
                ColorToken.Overlay => overlay,
                _ => throw new ArgumentOutOfRangeException(nameof(token), token, null)
            };

            if (!highContrast)
            {
                return color;
            }

            return token == ColorToken.TextSecondary ? textPrimary : color;
        }
    }
}
