// Simple Scroll-Snap - https://assetstore.unity.com/packages/tools/gui/simple-scroll-snap-140884
// Copyright (c) Daniel Lochner

using UnityEngine;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class TanslateX : TransitionEffectBase<RectTransform>
    {
        public override void OnTransition(RectTransform rectTransform, float distance)
        {
            rectTransform.localPosition = new Vector3(distance, rectTransform.localPosition.y, rectTransform.localPosition.z);
        }
    }
}
