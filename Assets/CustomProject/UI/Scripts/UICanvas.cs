
using CustomProject.Utils;
using UnityEngine;

namespace CustomProject.UI
{
    [RequireComponent(typeof(Canvas))]
    public class UICanvas: MonoBehaviourSceneSingleton<UICanvas>
    {
        public Canvas Canvas { get; private set; }
        public Vector2 CanvasRectSize { get; private set; }
        
        protected override void OnSingletonInitialized()
        {
            Canvas = GetComponent<Canvas>();
            Rect canvasRect = Canvas.GetComponent<RectTransform>().rect;
            CanvasRectSize = new Vector2(canvasRect.width, canvasRect.height);
        }
    }
}