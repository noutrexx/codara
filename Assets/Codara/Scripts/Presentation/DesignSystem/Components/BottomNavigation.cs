using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Codara.Presentation.DesignSystem.Components
{
    public sealed class BottomNavigation : ThemedComponent
    {
        [SerializeField] private List<Button> items = new List<Button>();
        [SerializeField] private int selectedIndex;

        public event Action<int> SelectionChanged;

        public void Select(int index)
        {
            if (index < 0 || index >= items.Count || index == selectedIndex)
            {
                return;
            }

            selectedIndex = index;
            SelectionChanged?.Invoke(index);
            Refresh();
        }

        public override void Refresh()
        {
            var theme = DesignSystemContext.Theme;
            if (theme == null)
            {
                return;
            }

            for (var index = 0; index < items.Count; index++)
            {
                var image = items[index] != null ? items[index].targetGraphic as Image : null;
                if (image != null)
                {
                    image.color = theme.GetColor(index == selectedIndex ? ColorToken.Primary : ColorToken.SurfaceRaised);
                }
            }
        }
    }
}
