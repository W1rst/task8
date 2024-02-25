
using CustomProject.UI.ViewAnimationSystem;
using UnityEngine;

namespace CustomProject.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class View: MonoBehaviour, IAnimatableView
    {
        [SerializeField] private bool _visible;

        public bool IsVisible => _visible;
        public RectTransform Root => _rootRectTr;
        public CanvasGroup CanvasGroup => _canvasGroup;

        private RectTransform _rootRectTr;
        private CanvasGroup _canvasGroup;
        
        private void Awake()
        {
            _rootRectTr = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _rootRectTr.gameObject.SetActive(_visible);
            OnAwake();
        }

        protected virtual void OnAwake()
        {
            
        }

        public void SetVisible()
        {
            if (!_visible)
            {
                _visible = true;
                if (_rootRectTr)
                {
                    _rootRectTr.gameObject.SetActive(true);
                    OnVisibilityStateChanged(_visible);
                }
            }
        }

        public void SetInvisible()
        {
            if (_visible)
            {
                _visible = false;
                if (_rootRectTr)
                {
                    _rootRectTr.gameObject.SetActive(false);
                    OnVisibilityStateChanged(_visible);
                }
            }
        }
        
        protected virtual void OnVisibilityStateChanged(bool visible)
        {
            
        }
    }
}