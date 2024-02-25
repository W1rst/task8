
using System;

namespace CustomProject.UI.ViewAnimationSystem.Animations
{
    public abstract class AnimationFactory<T, E> where T: IAnimation where E: Enum
    {
        public abstract T Create(E animationType);
    }
}