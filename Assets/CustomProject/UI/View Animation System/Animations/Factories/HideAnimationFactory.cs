
using CustomProject.UI.ViewAnimationSystem.Animations.Enums;
using CustomProject.UI.ViewAnimationSystem.Animations.HideAnimations;
using UnityEngine;

namespace CustomProject.UI.ViewAnimationSystem.Animations.Factories
{
    public class HideAnimationFactory: AnimationFactory<IHideAnimation, HideAnimation>
    {
        public override IHideAnimation Create(HideAnimation animationType)
        {
            switch (animationType)
            {
                case HideAnimation.Disappear:
                    return new Disappearing();
                
                case HideAnimation.SlideRight:
                    return new SlidingRight();
                
                case HideAnimation.SlideUp:
                    return new SlidingUp();
                
                case HideAnimation.SlideLeft:
                    return new SlidingLeft();

                case HideAnimation.SlideDown:
                    return new SlidingDown();

                case HideAnimation.None:
                    return default;
                
                default:
                    Debug.LogWarning($"Hide animation type \"{animationType}\" " +
                                     $"is not implemented in HideAnimationFactory");
                    return default;
            }
        }
    }
}