
using System.Collections.Generic;
using CustomProject.UI.ViewAnimationSystem;
using UnityEngine;
using Screen = CustomProject.UI.Enums.Screen;

namespace CustomProject.UI
{
    public class ScreenNavigator
    {
        private static ScreenNavigator _instance;
        
        public static ScreenNavigator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ScreenNavigator();
                }

                return _instance;
            }
        }

        public ScreenView CurrentScreenView => _currentScreenView;
        
        private Dictionary<Enums.Screen, ScreenView> _screens;
        private ScreenView _currentScreenView;

        private ScreenNavigator()
        {
            _screens = new Dictionary<Enums.Screen, ScreenView>();
        }
        
        public void RegisterScreen(Enums.Screen screen, ScreenView screenView)
        {
            if (!_screens.ContainsKey(screen))
            {
                _screens.Add(screen, screenView);
            }
            else
            {
                Debug.LogError($"Unable to register screen \"{screen}\", cuz it has already registered");
            }
        }

        public ScreenView UnregisterScreen(Enums.Screen screen)
        {
            if (!_screens.ContainsKey(screen))
            {
                Debug.Log($"Unable to unregister screen \"{screen}\", cuz it hasn't registered yet");
                return null;
            }

            ScreenView screenView = _screens[screen];
            _screens.Remove(screen);

            return screenView;
        }

        public void GoToScreen(Enums.Screen targetScreen)
        {
            if (!_screens.ContainsKey(targetScreen))
            {
                Debug.Log($"Unable to show screen \"{targetScreen}\", cuz it hasn't registered yet");
                return;
            }

            ScreenView targetScreenView = _screens[targetScreen];
            targetScreenView.SetVisible();
            
            if (_currentScreenView == null)
            {
                _currentScreenView = targetScreenView;
                return;
            }

            ScreenView previousScreenView = _currentScreenView;
            targetScreenView.SetVisible();
            
            UIAnimationSystem.Instance.AnimateScreenTransition(
                previousScreenView,
                targetScreenView,
                () => { previousScreenView.SetInvisible(); },
                () => { },
                () => { previousScreenView.SetInvisible();});
            
            _currentScreenView = targetScreenView;
            _currentScreenView.SetVisible();
        }
    }
}
