
using UnityEngine;

namespace CustomProject.UI.ViewAnimationSystem
{
    public interface IAnimatableView
    {
        RectTransform Root { get; }
        CanvasGroup CanvasGroup { get; }
    }
}