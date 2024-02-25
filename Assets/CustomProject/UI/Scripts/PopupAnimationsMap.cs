
using System.Collections.Generic;
using CustomProject.App.UI.ViewAnimationSystem;
using CustomProject.UI.Enums;
using CustomProject.UI.ViewAnimationSystem.Animations.Enums;
using UnityEngine;
using Screen = CustomProject.UI.Enums.Screen;

namespace CustomProject.UI
{
    public class PopupAnimationsMap
    {
        private static Dictionary<(Popup, Enums.Screen), (AnimationInfo<HideAnimation>, AnimationInfo<ShowAnimation>)> _popupAnimationsMap;

        static PopupAnimationsMap()
        {
            _popupAnimationsMap = new Dictionary<(Popup, Enums.Screen), (AnimationInfo<HideAnimation>, AnimationInfo<ShowAnimation>)>();
        }

        public static void Add(
            Popup popup, 
            Enums.Screen targetScreen,
            AnimationInfo<ShowAnimation> showAnimationInfo = null,
            AnimationInfo<HideAnimation> hideAnimationInfo = null)
        {
            if (_popupAnimationsMap.ContainsKey((popup, targetScreen)))
            {
                Debug.LogError($"Popup's \"{popup}\" show and hide animations " +
                               $"has already declared for screen {targetScreen}");
                return;
            }
            
            _popupAnimationsMap.Add((popup, targetScreen), (hideAnimationInfo, showAnimationInfo));
        }

        public static bool TryGet(Popup popup, Enums.Screen targetScreen,
            out (AnimationInfo<HideAnimation>, AnimationInfo<ShowAnimation>) animations)
        {
            return _popupAnimationsMap.TryGetValue((popup, targetScreen), out animations);
        }
    }
}