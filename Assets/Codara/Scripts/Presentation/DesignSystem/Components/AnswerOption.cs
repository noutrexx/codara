using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Codara.Presentation.DesignSystem.Components
{
    public sealed class AnswerOption : ThemedComponent
    {
        public enum AnswerState { Idle, Selected, Correct, Incorrect }

        [SerializeField] private Image surface;
        [SerializeField] private TMP_Text label;
        [SerializeField] private AnswerState state;

        public void SetState(AnswerState nextState)
        {
            state = nextState;
            Refresh();
        }

        public override void Refresh()
        {
            var theme = DesignSystemContext.Theme;
            if (theme == null || surface == null) return;
            var token = state switch
            {
                AnswerState.Selected => ColorToken.Primary,
                AnswerState.Correct => ColorToken.Success,
                AnswerState.Incorrect => ColorToken.Error,
                _ => ColorToken.SurfaceRaised
            };
            surface.color = theme.GetColor(token, DesignSystemContext.Accessibility.HighContrast);
            if (label != null) label.color = theme.GetColor(ColorToken.TextPrimary, DesignSystemContext.Accessibility.HighContrast);
        }
    }
}
