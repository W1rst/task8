
using CustomProject.App.UI.ViewAnimationSystem;
using CustomProject.UI.Enums;
using CustomProject.UI.ViewAnimationSystem;
using CustomProject.UI.ViewAnimationSystem.Animations.Enums;
using System;
using System.Diagnostics;
using UnityEngine;
using Screen = CustomProject.UI.Enums.Screen;

namespace CustomProject.UI
{
    public static class UIAnimationsConfig
    {
        public static void Initialize()
        {
            ScreensTransitionAnimationsSetup();
            PopupAnimationsSetup();
        }

        private static void ScreensTransitionAnimationsSetup()
        {
            AddScreenTransition(Screen.Start, Screen.PopupDemonstration, HideAnimation.SlideLeft, ShowAnimation.SlideLeft);
            AddScreenTransition(Screen.PopupDemonstration, Screen.Start, HideAnimation.SlideRight, ShowAnimation.SlideRight);
            AddScreenTransition(Screen.PopupDemonstration, Screen.JustScreen, HideAnimation.SlideLeft, ShowAnimation.SlideLeft);
            AddScreenTransition(Screen.JustScreen, Screen.PopupDemonstration, HideAnimation.SlideRight, ShowAnimation.SlideRight);
            AddScreenTransition(Screen.JustScreen, Screen.PlayScreen, HideAnimation.SlideLeft, ShowAnimation.SlideLeft);
            AddScreenTransition(Screen.PlayScreen, Screen.JustScreen, HideAnimation.SlideRight, ShowAnimation.SlideRight);
        }

        private static void PopupAnimationsSetup()
        {
            AddPopupAnimations(Popup.Loading, new Screen[]{ Screen.Start, Screen.PopupDemonstration, Screen.JustScreen, Screen.PlayScreen },
                ShowAnimation.Appear, HideAnimation.Disappear);

            AddPopupAnimations(Popup.Error, new Screen[] { Screen.Start, Screen.PopupDemonstration, Screen.JustScreen, Screen.PlayScreen},
                  ShowAnimation.Appear, HideAnimation.Disappear);

            AddPopupAnimations(Popup.Message, new Screen[] { Screen.Start, Screen.PopupDemonstration, Screen.JustScreen, Screen.PlayScreen },
                ShowAnimation.Appear, HideAnimation.Disappear);
        }

        private static void AddScreenTransition(Screen hide,Screen show, HideAnimation hideAnim, ShowAnimation showAnim,
            float showDuration = 0.25f, float hideDuration = 0.25f)
        {
            ScreenTransitionAnimationsMap.Add(hide, show, 
                AnimationUtils.CreateAnimationInfo(hideAnim, showDuration),
                AnimationUtils.CreateAnimationInfo(showAnim, hideDuration)
            );
        }

        private static void AddPopupAnimations(Popup popup, Screen[] screens, ShowAnimation showAnimation,
            HideAnimation hideAnimation, float showDuration = 0.25f, float hideDuration = 0.25f)
        {
            foreach (var screen in screens)
            {
                PopupAnimationsMap.Add(popup, screen, 
                    AnimationUtils.CreateAnimationInfo(showAnimation, showDuration), 
                    AnimationUtils.CreateAnimationInfo(hideAnimation, hideDuration));   
            }
        }
        
    }
}