
using System;
using CustomProject.UI.ViewAnimationSystem.Animations;

namespace CustomProject.App.UI.ViewAnimationSystem
{
    public class AnimationInfo<E> where E: Enum
    {
        public E animationType;
        public AnimationData animationData;
    }
}