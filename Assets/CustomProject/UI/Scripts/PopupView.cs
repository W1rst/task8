
using CustomProject.UI.Enums;
using CustomProject.Core.Services.Input;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace CustomProject.UI
{
    public abstract class PopupView : View
    {
        [Space(-4f)]
        [Header("Popup Base Setup")]
        [SerializeField] private RectTransform _popupContainerRoot;
        [SerializeField] private Button _closeButton;
        [SerializeField] private bool _backButtonActive = true;
        
        public abstract Popup Popup { get; }

        public void SubscribeOnClose(UnityAction action)
        {
            _closeButton.onClick.AddListener(action);
        }

        public void UnsubscribeOnClose(UnityAction action)
        {
            _closeButton.onClick.RemoveListener(action);
        }


        protected override void OnAwake()
        {
            base.OnAwake();
            if (_popupContainerRoot == null && Root.childCount > 0)
            {
                _popupContainerRoot = Root.GetChild(0).GetComponent<RectTransform>();
            }
            
            PopupManager.Instance.RegisterPopup(Popup, this);
        }

        private void OnDestroy()
        {
            PopupManager.Instance.UnregisterPopup(Popup);

            if (_backButtonActive)
                InputService.OnBackButtonPressed -= OnBackButtonPressedCallback;
            
            if (_closeButton)
                _closeButton.onClick.RemoveListener(OnCloseButtonPressedCallback);
        }

        protected override void OnVisibilityStateChanged(bool visible)
        {
            base.OnVisibilityStateChanged(visible);
            
            if (visible)
            {
                if (_backButtonActive)
                    InputService.OnBackButtonPressed += OnBackButtonPressedCallback;

                if (_closeButton)
                    _closeButton.onClick.AddListener(OnCloseButtonPressedCallback);
            }
            else
            {
                if (_backButtonActive)
                    InputService.OnBackButtonPressed -= OnBackButtonPressedCallback;
            
                if (_closeButton)
                    _closeButton.onClick.RemoveListener(OnCloseButtonPressedCallback);
            }
        }

        protected virtual void ClosePopup()
        {
            Debug.Log("Close popup");
            PopupManager.Instance.ClosePopup(Popup);
        }
        
        private void OnBackButtonPressedCallback()
        {
            ClosePopup();
        }
        
        private void OnCloseButtonPressedCallback()
        {
            ClosePopup();
        }
    }
}
