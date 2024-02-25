
using System.Collections.Generic;
using CustomProject.UI;
using CustomProject.UI.Enums;
using CustomProject.UI.ViewAnimationSystem;
using UnityEngine;
using Screen = CustomProject.UI.Enums.Screen;

namespace CustomProject
{
    public class PopupManager
    {
        private static PopupManager _instance;

        public static PopupManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PopupManager();
                }

                return _instance;
            }
        }

        private Dictionary<Popup, PopupView> _registeredPopups;
        private Dictionary<Popup, PopupView> _openedPopups = new Dictionary<Popup, PopupView>();
        private ScreenView _currentScreen;

        private PopupManager()
        {
            _registeredPopups = new Dictionary<Popup, PopupView>();
        }

        public void RegisterPopup(Popup popup, PopupView popupView)
        {
            if (!_registeredPopups.ContainsKey(popup))
            {
                _registeredPopups.Add(popup, popupView);
            }
            else
            {
                Debug.LogError($"Unable to register popup \"{popup}\", cuz it has already registered");
            }
        }

        public PopupView UnregisterPopup(Popup popup)
        {
            if (!_registeredPopups.ContainsKey(popup))
            {
                Debug.Log($"Unable to unregister popup \"{popup}\", cuz it hasn't registered yet");
                return null;
            }

            PopupView popupView = _registeredPopups[popup];
            _registeredPopups.Remove(popup);

            return popupView;
        }

        public PopupView OpenPopup(Popup popup, bool closeOtherPopups)
        {
            PopupView targetPopupView;
            if (!_registeredPopups.TryGetValue(popup, out targetPopupView))
            {
                Debug.LogError($"Unable to open popup \"{popup}\", cuz it hasn't registered yet");
                return null;
            }

            if (_openedPopups.ContainsKey(popup))
            {
                Debug.LogError($"Popup \"{popup}\" has already opened");
                return null;
            }
            
            if (closeOtherPopups)
            {
                CloseAllPopups();
            }
            
            _openedPopups.Add(popup, targetPopupView);
            targetPopupView.SetVisible();
            
            UI.Enums.Screen currentScreen = ScreenNavigator.Instance.CurrentScreenView.Screen;
            UIAnimationSystem.Instance.AnimatePopupShowing(targetPopupView, currentScreen);

            return targetPopupView;
        }

        public void ClosePopup(Popup popup)
        {
            if (_openedPopups.TryGetValue(popup, out PopupView popupView))
            {
                _openedPopups.Remove(popup);

                UI.Enums.Screen currentScreen = ScreenNavigator.Instance.CurrentScreenView.Screen;
                UIAnimationSystem.Instance.AnimatePopupClosing(popupView, currentScreen,
                    () =>
                    {
                        popupView.SetInvisible();
                    },
                    () =>
                    {
                        popupView.SetInvisible();
                    });
            }
            else
            {
                Debug.LogError($"Unable to close popup \"{popup}\", cuz it hasn't opened yet");
            }
        }

        public void CloseAllPopups()
        {
            foreach (KeyValuePair<Popup,PopupView> keyValuePair in _openedPopups)
            {
                PopupView popupView = keyValuePair.Value;
                popupView.SetInvisible();
            }
            
            _openedPopups.Clear();
        }

        public PopupView GetOpenedPopupView(Popup popup)
        {
            PopupView targetPopupView;
            if (!_registeredPopups.TryGetValue(popup, out targetPopupView))
            {
                Debug.LogError($"Unable to open popup \"{popup}\", cuz it hasn't registered yet");
                return null;
            }

            if (!_openedPopups.ContainsKey(popup))
            {
                Debug.LogError($"Popup \"{popup}\" is not opened");
                return null;
            }

            return targetPopupView;
        }
    }
}
