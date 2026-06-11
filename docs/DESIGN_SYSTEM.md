# Codara Design System

Codara uses an original dark technology aesthetic: near-black backgrounds, raised anthracite surfaces, electric purple primary actions, and turquoise learning feedback.

## Foundations

- `CodaraTheme` stores semantic colors, spacing, corners, touch targets, and motion durations.
- `DesignSystemContext` supplies the active theme and accessibility preferences.
- `ThemeColorBinding`, `AdaptiveText`, `SafeAreaPanel`, and `MinimumTouchTarget` provide shared responsive behavior.
- Components consume semantic tokens instead of fixed colors.
- Light theme infrastructure exists; MVP ships with the generated dark theme.

## Accessibility

- Text scale is supported from `0.85x` to `1.5x`.
- High contrast strengthens secondary text.
- Reduce motion is available to animation systems through `AccessibilitySettings.ReduceMotion`.
- Interactive controls use a minimum 48-unit touch target.
- Text wraps and falls back to ellipsis for constrained layouts.

## Generated Assets

Run `Codara > Setup Design System` to create:

- `Assets/Codara/Data/DesignSystem/CodaraDarkTheme.asset`
- `Assets/Codara/Prefabs/Nox.prefab`
- `Assets/Codara/Scenes/DesignSystemPreview.unity`
