
using System;
using CustomProject.App.UI.ViewAnimationSystem;
using CustomProject.UI.ViewAnimationSystem.Animations;
using UnityEngine;

namespace CustomProject.UI.ViewAnimationSystem
{
    public static class AnimationUtils
    {
        public static Vector2 GetOffsetToCenter(RectTransform view)
        {
            Vector2 pivot = view.pivot;
            Rect rect = view.rect;

            float xOffset = -((0.5f - pivot.x) * rect.width);
            float yOffset = -((0.5f - pivot.y) * rect.height);

            return new Vector2(xOffset, yOffset);
        }
        
        public static AnimationInfo<E> CreateAnimationInfo<E>(E animation, float duration) where E: Enum
        {
            AnimationData animationData = new AnimationData() { duration = duration };
            return new AnimationInfo<E>() { animationType = animation, animationData = animationData };
        }
    }
}