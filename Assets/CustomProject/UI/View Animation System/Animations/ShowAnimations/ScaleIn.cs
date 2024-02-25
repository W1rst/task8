
using System;
using System.Collections;
using UnityEngine;

namespace CustomProject.UI.ViewAnimationSystem.Animations.ShowAnimations
{
    public class ScaleIn: AnimationBase, IShowAnimation
    {
        protected override IEnumerator GetAnimationCoroutine(IAnimatableView view, AnimationData animationData,
            Action onCompleted)
        {
            view.Root.localPosition = AnimationUtils.GetOffsetToCenter(view.Root);

            Vector3 scaleTo = new Vector3(1,1 ,1);
            Vector3 scaleFrom = new Vector3(0,0 ,0);
            
            return AnimationCore.ResizeAnimCo(view.Root, scaleFrom, scaleTo, animationData, onCompleted);
        }
    }
}