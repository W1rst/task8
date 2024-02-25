
using System;
using System.Collections;
using UnityEngine;

namespace CustomProject.UI.ViewAnimationSystem.Animations.ShowAnimations
{
    public class SlidingBottom: AnimationBase, IShowAnimation
    {
        protected override IEnumerator GetAnimationCoroutine(IAnimatableView view, AnimationData animationData,
            Action onCompleted)
        {
            float height = UICanvas.Instance.CanvasRectSize.y;                                           
            Vector2 offsetToCenter = AnimationUtils.GetOffsetToCenter(view.Root);

            Vector2 startPos = Vector2.zero;                                   
            startPos.y += height;                                                  
            startPos += offsetToCenter;              
                                                                      
            Vector2 endPos = offsetToCenter;                   
            
            return AnimationCore.MoveAnimCo(view.Root, startPos, endPos, animationData, onCompleted);
        }
    }
}