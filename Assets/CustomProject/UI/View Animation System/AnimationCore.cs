
using System;
using System.Collections;
using UnityEngine;

namespace CustomProject.UI.ViewAnimationSystem.Animations
{
    public class AnimationCore
    {
        public static IEnumerator MoveAnimCo(RectTransform rectTr, Vector2 startCoord, Vector2 endCoord, 
            AnimationData animationData, Action onCompleted)
        {
            float t = 0;
            float duration = animationData.duration;
            
            rectTr.localPosition = startCoord; 
            while (t < duration)
            {
                t += Time.deltaTime;

                rectTr.localPosition = Vector2.Lerp(startCoord, endCoord, t/duration);
                
                yield return null;
            }
            
            onCompleted?.Invoke();
        } 
        
        public static IEnumerator AlphaAnimCo(CanvasGroup canvasGroup, float startValue, float endValue, 
            AnimationData animationData, Action onCompleted)
        {
            float t = 0;
            float duration = animationData.duration;

            startValue = Mathf.Clamp01(startValue);
            endValue = Mathf.Clamp01(endValue);    
            
            canvasGroup.alpha = startValue;
            while (t < duration)
            {
                t += Time.deltaTime;

                canvasGroup.alpha = Mathf.Lerp(startValue, endValue, t/duration);
                
                yield return null;
            }
            
            onCompleted?.Invoke();
        }    
        
        public static IEnumerator ResizeAnimCo(RectTransform rectTr, Vector3 scaleFrom, Vector3 scaleTo, 
            AnimationData animationData, Action onCompleted)
        {
            float t = 0;
            float duration = animationData.duration;
            
            rectTr.localScale = scaleFrom; 
            while (t < duration)
            {
                t += Time.unscaledDeltaTime;

                rectTr.localScale = Vector2.Lerp(scaleFrom, scaleTo, t/duration);
                
                yield return null;
            }
            
            onCompleted?.Invoke();
        } 
    }
}