
using System;
using System.Collections;
using UnityEngine;

namespace CustomProject.UI.ViewAnimationSystem.Animations.ShowAnimations
{
    public class SlidingRight: AnimationBase, IShowAnimation
    {
        protected override IEnumerator GetAnimationCoroutine(IAnimatableView view, AnimationData animationData,
            Action onCompleted)
        {
            float width = UICanvas.Instance.CanvasRectSize.x;                                                                                        
            Vector2 offsetToCenter = AnimationUtils.GetOffsetToCenter(view.Root);                                              
                                                                                                                   
            Vector2 startPos = Vector2.zero;                                                                                
            startPos.x -= width;                                                                                               
            startPos += AnimationUtils.GetOffsetToCenter(view.Root);                                                           
                                                                                                                   
            Vector2 endPos = offsetToCenter;                                                                 
                                                                                                                   
            return AnimationCore.MoveAnimCo(view.Root, startPos, endPos, animationData, onCompleted);
        }
    }
}