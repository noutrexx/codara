using UnityEngine;

namespace Codara.Presentation.DesignSystem
{
    public sealed class DesignSystemBootstrap : MonoBehaviour
    {
        [SerializeField] private CodaraTheme activeTheme;

        private void Awake()
        {
            if (activeTheme == null && DesignSystemContext.Theme == null)
            {
                activeTheme = ScriptableObject.CreateInstance<CodaraTheme>();
            }

            if (activeTheme != null) DesignSystemContext.SetTheme(activeTheme);
        }
    }
}
