
using CustomProject.UI.ViewAnimationSystem.Animations.Enums;
using CustomProject.UI.ViewAnimationSystem.Animations.ShowAnimations;
using UnityEngine;

namespace CustomProject.UI.ViewAnimationSystem.Animations.Factories
{
    public class ShowAnimationFactory: AnimationFactory<IShowAnimation, ShowAnimation>
    {
        public override IShowAnimation Create(ShowAnimation animationType)
        {
            switch (animationType)
            {
                case ShowAnimation.Appear:
                    return new Appearing();
                
                case ShowAnimation.SlideRight:
                    return new SlidingRight();
                
                case ShowAnimation.SlideUp:
                    return new SlidingUp();
                
                case ShowAnimation.SlideLeft:
                    return new SlidingLeft();

                case ShowAnimation.SlideDown:
                    return new SlidingBottom();
                
                case ShowAnimation.ScaleIn:
                    return new ScaleIn();
                
                case ShowAnimation.None:
                    return default;
                
                default:
                    Debug.LogWarning($"Show animation type \"{animationType}\" " +
                                     $"is not implemented in ShowAnimationFactory");
                    return default;
            }
        }
    }
}