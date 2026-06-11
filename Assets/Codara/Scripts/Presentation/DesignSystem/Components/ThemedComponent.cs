using UnityEngine;

namespace Codara.Presentation.DesignSystem.Components
{
    public abstract class ThemedComponent : MonoBehaviour
    {
        protected virtual void OnEnable()
        {
            DesignSystemContext.Changed += Refresh;
            Refresh();
        }

        protected virtual void OnDisable()
        {
            DesignSystemContext.Changed -= Refresh;
        }

        public abstract void Refresh();
    }
}
