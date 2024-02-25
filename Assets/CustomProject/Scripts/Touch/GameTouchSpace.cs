
using System;
using System.Collections;
using System.Collections.Generic;
using CustomProject.Core.Services.Input;
using CustomProject.Utils;
using UnityEngine;

namespace CustomProject
{
    public class GameTouchSpace : MonoBehaviourSceneSingleton<GameTouchSpace>
    {
        private const float TapSpeedCalcInterval = 0.25f;

        public static event Action OnTap;
        public static event EventHandler<DragEventArgs> OnDrag;
        public static event EventHandler<float> OnZoom;
        public static event Action OnHoldStarted;
        public static event Action OnHoldEnded;

        protected override void OnSingletonInitialized()
        {
            base.OnSingletonInitialized();

            InputService.OnZoom += OnZoomCallback;
            InputService.OnPointerPressed += OnHoldStartedCallback;
            InputService.OnPointerReleased += OnHoldEndedCallback;
        }

        private void OnDestroy()
        {
            InputService.OnZoom -= OnZoomCallback;
            InputService.OnPointerPressed -= OnHoldStartedCallback;
            InputService.OnPointerReleased -= OnHoldEndedCallback;
        }

        private void OnZoomCallback(ZoomEventArgs eventArgs)
        {
            Debug.Log("Zooming");
            OnZoom?.Invoke(this, eventArgs.zoom);
        }

        private void OnHoldStartedCallback(PointerEventArgs eventArgs)
        {
            OnHoldStarted?.Invoke();
            Debug.Log("Pointer Pressed");
        }

        private void OnHoldEndedCallback(PointerEventArgs eventArgs)
        {
            OnHoldEnded?.Invoke();
            Debug.Log("Pointer Released");
        }
    }
}
