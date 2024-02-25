
using System;
using System.Collections;
using UnityEngine;

namespace CustomProject.UI.ViewAnimationSystem.Animations.ShowAnimations
{
    public class Appearing: AnimationBase, IShowAnimation
    {
        protected override IEnumerator GetAnimationCoroutine(IAnimatableView view, AnimationData animationData,
            Action onCompleted)
        {
            view.Root.localPosition = AnimationUtils.GetOffsetToCenter(view.Root);
            
            return AnimationCore.AlphaAnimCo(view.CanvasGroup, 0f, 1f, animationData, onCompleted);
        }
    }
}