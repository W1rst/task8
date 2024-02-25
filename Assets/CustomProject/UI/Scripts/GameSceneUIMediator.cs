
using System;
using CustomProject.UI;
using CustomProject.UI.Enums;
using CustomProject.Utils;
using CustomProject.Utils.Inspector;
using Unity.VisualScripting;
using UnityEngine;

namespace CustomProject
{
    public class GameSceneUIMediator : MonoBehaviour
    {
#if UNITY_EDITOR
        [Header("UI Navigation:")]
        [InspectorButton("ShowStartScreen")]        [SerializeField] private string ShowStart;
        [InspectorButton("ShowPopupScreen")]         [SerializeField] private string ShowPopup;
        [InspectorButton("ShowJustScreen")]          [SerializeField] private string ShowJust;
        [InspectorButton("ShowPlayScreen")]          [SerializeField] private string ShowPlay;
        [InspectorButton("OpenLoadingPopup")]          [SerializeField] private string ShowLoading;
#endif

        private ScreenNavigator _screenNavigator;
        private PopupManager _popupManager;

        #region Unity Callbacks

        private void Awake()
        {
            _screenNavigator = ScreenNavigator.Instance;
            _popupManager = PopupManager.Instance;
        }

        private void Start()
        {
            ShowStartScreen();
        }

        #endregion

        #region Public Methods

        public void ShowStartScreen() => _screenNavigator.GoToScreen(UI.Enums.Screen.Start);
        public void ShowPopupScreen() => _screenNavigator.GoToScreen(UI.Enums.Screen.PopupDemonstration);
        public void ShowJustScreen() => _screenNavigator.GoToScreen(UI.Enums.Screen.JustScreen);
        public void ShowPlayScreen() => _screenNavigator.GoToScreen(UI.Enums.Screen.PlayScreen);

        public void OpenLoadingPopup() => _popupManager.OpenPopup(Popup.Loading, true);
        public void CloseLoadingPopup() => _popupManager.ClosePopup(Popup.Loading);
        public PopupView OpenErrorPopup() => _popupManager.OpenPopup(Popup.Error, true);
        public void CloseErrorPopup() => _popupManager.ClosePopup(Popup.Error);
        public PopupView OpenMessagePopup() => _popupManager.OpenPopup(Popup.Message, true);
        public void CloseMessagePopup() => _popupManager.ClosePopup(Popup.Message);

        #endregion
    }
}
