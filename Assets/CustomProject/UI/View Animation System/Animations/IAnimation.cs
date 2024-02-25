
using System;
using UnityEngine;

namespace CustomProject.UI.ViewAnimationSystem.Animations
{
    public interface IAnimation
    {
        IAnimation Play(IAnimatableView view, AnimationData animationData, Action onCompleted);
        void Stop();
    }
}