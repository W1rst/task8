
using System;
using System.Collections;
using UnityEngine;

namespace CustomProject.UI.ViewAnimationSystem.Animations.HideAnimations
{
    public class Disappearing: AnimationBase, IHideAnimation
    {
        protected override IEnumerator GetAnimationCoroutine(IAnimatableView view, AnimationData animationData,
            Action onCompleted)
        {
            view.Root.localPosition = AnimationUtils.GetOffsetToCenter(view.Root);
            
            return AnimationCore.AlphaAnimCo(view.CanvasGroup, 1f, 0f, animationData, onCompleted);
        }
    }
}