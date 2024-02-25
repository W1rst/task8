
using System.Collections.Generic;
using CustomProject.App.UI.ViewAnimationSystem;
using CustomProject.UI.ViewAnimationSystem.Animations.Enums;
using UnityEngine;
using Screen = CustomProject.UI.Enums.Screen;

namespace CustomProject.UI
{
    public static class ScreenTransitionAnimationsMap
    {
        private static Dictionary<(Screen, Screen), (AnimationInfo<HideAnimation>, AnimationInfo<ShowAnimation>)> _transitionsMap;

        static ScreenTransitionAnimationsMap()
        {
            _transitionsMap = new Dictionary<(Screen, Screen), (AnimationInfo<HideAnimation>, AnimationInfo<ShowAnimation>)>();
        }
        
        public static void Add(
            Screen hideScreen, 
            Screen showScreen,
            AnimationInfo<HideAnimation> hideScreenAnimationInfo = null, 
            AnimationInfo<ShowAnimation> showScreenAnimationInfo = null)
        {
            if (_transitionsMap.ContainsKey((hideScreen, showScreen)))
            {
                Debug.LogError($"Transition animations between screen \"{hideScreen}\" and \"{showScreen}\" " +
                               $"has already declared!");
                return;
            }

            _transitionsMap.Add((hideScreen, showScreen), (hideScreenAnimationInfo, showScreenAnimationInfo));
        }

        public static bool TryGet(Screen fromScreen, Screen toScreen, 
            out (AnimationInfo<HideAnimation>, AnimationInfo<ShowAnimation>) transitionAnimations)
        {
            return _transitionsMap.TryGetValue((fromScreen, toScreen), out transitionAnimations);
        }
    }
}