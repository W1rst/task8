
using System;
using System.Collections;
using UnityEngine;

namespace CustomProject.UI.ViewAnimationSystem.Animations.HideAnimations
{
    public class SlidingDown: AnimationBase, IHideAnimation
    {
        protected override IEnumerator GetAnimationCoroutine(IAnimatableView view,  AnimationData animationData,
            Action onCompleted)
        {
            float height = UICanvas.Instance.CanvasRectSize.y;
            Vector2 offsetToCenter = AnimationUtils.GetOffsetToCenter(view.Root);

            Vector2 startPos = Vector2.zero;
            startPos += offsetToCenter;
            
            Vector2 endPos = startPos;
            endPos.y -= height;
            
            return AnimationCore.MoveAnimCo(view.Root, startPos, endPos, animationData, onCompleted);
        }
    }
}