
using System;
using System.Collections.Generic;
using CustomProject.App.UI.ViewAnimationSystem;
using CustomProject.UI.ViewAnimationSystem.Animations;
using CustomProject.UI.ViewAnimationSystem.Animations.Enums;
using CustomProject.UI.ViewAnimationSystem.Animations.Factories;
using UnityEngine;
using Screen = CustomProject.UI.Enums.Screen;

namespace CustomProject.UI.ViewAnimationSystem
{
    public class UIAnimationSystem
    {
        public static UIAnimationSystem Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UIAnimationSystem();
                }
                
                return _instance;
            }
        }

        private static UIAnimationSystem _instance;
        
        private ShowAnimationFactory _showAnimationFactory;
        private HideAnimationFactory _hideAnimationFactory;
        private Dictionary<IAnimatableView, IAnimation> _animatingViews;

        private UIAnimationSystem()
        {
            _animatingViews = new Dictionary<IAnimatableView, IAnimation>();
            _showAnimationFactory = new ShowAnimationFactory();
            _hideAnimationFactory = new HideAnimationFactory();
            UIAnimationsConfig.Initialize();
        }

        public void ShowView(IAnimatableView view, AnimationInfo<ShowAnimation> showAnimationInfo, Action onCompleted=null)
        {
            RemoveAnimatingView(view);

            ShowAnimation animationType = showAnimationInfo.animationType;
            if (animationType == ShowAnimation.None)
            {
                onCompleted?.Invoke();
                return;
            }
            
            IShowAnimation animation = _showAnimationFactory.Create(animationType);
            
            if (animation == null)
            {
                Debug.LogError($"Unable to obtain show animation \"{showAnimationInfo.animationType}\"");
                onCompleted?.Invoke();
                return;
            }
            
            AddAnimatingView(view, animation);
            animation.Play(view, showAnimationInfo.animationData, onCompleted);
        }
        
        public void HideView(IAnimatableView view, AnimationInfo<HideAnimation> hideAnimationInfo, Action onCompleted=null)
        {
            RemoveAnimatingView(view);

            HideAnimation animationType = hideAnimationInfo.animationType;
            if (animationType == HideAnimation.None)
            {
                onCompleted?.Invoke();
                return;
            }

            IHideAnimation animation = _hideAnimationFactory.Create(hideAnimationInfo.animationType);
            
            if (animation == null)
            {
                Debug.LogError($"Unable to obtain hide animation \"{hideAnimationInfo.animationType}\"");
                onCompleted?.Invoke();
                return;
            }

            AddAnimatingView(view, animation);
            animation.Play(view, hideAnimationInfo.animationData, onCompleted);
        }

        public void AnimateScreenTransition(ScreenView hideScreenView, ScreenView showScreenView, 
            Action onHideScreenCompleted=null, 
            Action onShowScreenCompleted=null,
            Action onTransitionFailed=null)
        {
            if (ScreenTransitionAnimationsMap.TryGet(hideScreenView.Screen, showScreenView.Screen,
                    out (AnimationInfo<HideAnimation>, AnimationInfo<ShowAnimation>) transitionAnimations))
            {
                AnimateViewsTransition(hideScreenView, showScreenView, transitionAnimations, 
                    onHideScreenCompleted, onShowScreenCompleted);
                return;
            }
            
            onTransitionFailed?.Invoke();
        }

        public void AnimatePopupShowing(PopupView targetPopup, Screen screen, 
            Action onCompleted=null, 
            Action onFailed=null)
        {
            if (PopupAnimationsMap.TryGet(targetPopup.Popup, screen,
                    out (AnimationInfo<HideAnimation>, AnimationInfo<ShowAnimation>) popupAnimations))
            {
                ShowView(targetPopup, popupAnimations.Item2, onCompleted);
                return;
            }
            
            onFailed?.Invoke();
        }

        public void AnimatePopupClosing(PopupView targetPopup, Screen screen, 
            Action onCompleted=null, 
            Action onFailed=null)
        {
            if (PopupAnimationsMap.TryGet(targetPopup.Popup, screen,
                    out (AnimationInfo<HideAnimation>, AnimationInfo<ShowAnimation>) popupAnimations))
            {
                HideView(targetPopup, popupAnimations.Item1, onCompleted);
                return;
            }
            
            onFailed?.Invoke();
        }

        
        private void AnimateViewsTransition(
            IAnimatableView hideScreen,
            IAnimatableView showScreen,
            (AnimationInfo<HideAnimation>, AnimationInfo<ShowAnimation>) transitionAnimations,
            Action onHideCompleted=null,
            Action onShowCompleted=null)
        {
            HideView(hideScreen, transitionAnimations.Item1, onHideCompleted);
            ShowView(showScreen, transitionAnimations.Item2, onShowCompleted);
        }

        private void AddAnimatingView(IAnimatableView view, IAnimation animation)
        {
            _animatingViews.Add(view, animation);
        }

        private void RemoveAnimatingView(IAnimatableView view)
        {
            if (_animatingViews.TryGetValue(view, out IAnimation animation))
            {
                animation.Stop();
                _animatingViews.Remove(view);
            }
        }
    }
}
