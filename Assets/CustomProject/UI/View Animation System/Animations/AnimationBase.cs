
using System;
using System.Collections;
using CustomProject.Utils;
using UnityEngine;

namespace CustomProject.UI.ViewAnimationSystem.Animations
{
    public abstract class AnimationBase: IAnimation
    {
        private Coroutine _animCo;
        
        public IAnimation Play(IAnimatableView view, AnimationData animationData, Action onCompleted)
        {
            if (_animCo != null)
            {
                Coroutiner.StopCoroutine(_animCo);
            }

            _animCo = Coroutiner.StartCoroutine(GetAnimationCoroutine(view, animationData, onCompleted));
            return this;
        }

        public void Stop()
        {
            Coroutiner.StopCoroutine(_animCo);
        }

        protected abstract IEnumerator GetAnimationCoroutine(IAnimatableView view, AnimationData animationData, 
            Action onCompleted);
    }
}