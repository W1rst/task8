
using UnityEngine;
using UnityEngine.UI;
using Screen = CustomProject.UI.Enums.Screen;

namespace CustomProject.UI
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public abstract class ScreenView : View
    {
        public abstract Enums.Screen Screen { get; }

        private Canvas _inheritedCanvas;        
        
        protected override void OnAwake()
        {
            base.OnAwake();
            ScreenNavigator.Instance.RegisterScreen(Screen, this);
        }

        protected void OnDestroy()
        {
            ScreenNavigator.Instance.UnregisterScreen(Screen);
        }
    }
}
