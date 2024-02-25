
using System;
using UnityEngine;

namespace CustomProject.Core.Services.Input
{
    [Serializable]
    public class InputServiceSettings
    {
        [SerializeField] private float _minDragDistanceInches = 0.0025f;
        [SerializeField] private float _defaultDPI = 160f;

        [Header("Editor Input Settings:")]
        [SerializeField] private float _zoomMulitplier = 4f;

        public float ZoomMultiplier => _zoomMulitplier;
        public float MinDragDistanceInches => _minDragDistanceInches;
        public float DefaultDPI => _defaultDPI;
    }
}