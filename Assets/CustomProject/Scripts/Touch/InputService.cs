
using System;
using CustomProject.Utils;
using UnityEngine;

namespace CustomProject.Core.Services.Input
{
    public class InputService: MonoBehaviourSceneSingleton<InputService>
    {
        public const int LeftMouseButton = 0;
        public const int RightMouseButton = 1;
        public const int MiddleMouseButton = 2;
        public const int FirstTouch = 0;
        public const int SecondTouch = 1;

        public static Vector2 CurrentMousePosition => UnityEngine.Input.mousePosition;
        
        public static event Action OnBackButtonPressed;
        public static event Action<PointerEventArgs> OnTap;
        public static event Action<PointerEventArgs> OnPointerPressed;
        public static event Action<PointerEventArgs> OnPointerReleased;
        public static event Action<DragEventArgs> OnDrag;
        public static event Action<ZoomEventArgs> OnZoom;

        private readonly InputServiceSettings _inputSettings = new InputServiceSettings();
        private float _sqrDragMinDistance;
        private float _dpiCorrection;
        private Vector2 _currentPressedPosition;
        private bool _pointerPressed;
        private bool _dragging;
        
        private bool _pinching;
        private float _pinchDistance;

        protected override void OnSingletonInitialized()
        {
            base.OnSingletonInitialized();
            
            float dpi = Screen.dpi;
            if (Screen.dpi == 0)
            {
                dpi = _inputSettings.DefaultDPI;
            }

            #if UNITY_EDITOR
            float minDragDistance = _inputSettings.MinDragDistanceInches * dpi;
            #elif UNITY_ANDROID || UNITY_IOS
            float minDragDistance = _inputSettings.MinDragDistanceInches * dpi;
            #endif

            _sqrDragMinDistance = minDragDistance * minDragDistance;
        }

        private void Update()
        {
            #if UNITY_ANDROID || UNITY_EDITOR
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                OnBackButtonPressed?.Invoke();
            }
            #endif
            
            #if UNITY_EDITOR
            OnUpdateEditor();
            #elif UNITY_ANDROID || UNITY_IOS
            OnUpdateMobile();
            #endif
        }

        private void OnUpdateEditor()
        {
            if (UnityEngine.Input.GetMouseButton(LeftMouseButton) && _pointerPressed)
            {
                Vector2 newCurrentPressedPosition = UnityEngine.Input.mousePosition;
                if (!_dragging)
                {
                    _dragging = IsDrag(_currentPressedPosition, newCurrentPressedPosition);
                }

                if (_dragging)
                {
                    Vector2 delta = newCurrentPressedPosition - _currentPressedPosition;

                    DragEventArgs dragEventArgs = new DragEventArgs() 
                    { 
                        delta = delta, 
                        position = _currentPressedPosition 
                    };

                    OnDrag?.Invoke(dragEventArgs);
                }
               
                _currentPressedPosition = newCurrentPressedPosition;
            }

            if (UnityEngine.Input.GetMouseButtonDown(LeftMouseButton) && !_pointerPressed)
            {
                _currentPressedPosition = UnityEngine.Input.mousePosition;
                _pointerPressed = true;

                PointerEventArgs pointerEventArgs = new PointerEventArgs()
                {
                    pointerId = LeftMouseButton,
                    position = UnityEngine.Input.mousePosition
                };

                OnPointerPressed?.Invoke(pointerEventArgs);
            }

            if (UnityEngine.Input.GetMouseButtonUp(LeftMouseButton) && _pointerPressed)
            {
                PointerEventArgs pointerEventArgs = new PointerEventArgs()
                {
                    pointerId = LeftMouseButton,
                    position = _currentPressedPosition
                };

                if (_dragging)
                {
                    _dragging = false;
                }
                else
                {
                    OnTap?.Invoke(pointerEventArgs);
                }

                _pointerPressed = false;
                OnPointerReleased?.Invoke(pointerEventArgs);
            }

            float scrollY = UnityEngine.Input.mouseScrollDelta.y;
            if (scrollY != 0)
            {
                ZoomEventArgs zoomEventArgs = new ZoomEventArgs() { zoom = scrollY * _inputSettings.ZoomMultiplier };
                OnZoom?.Invoke(zoomEventArgs);
            }
        }

        private void OnUpdateMobile()
        {
            if (UnityEngine.Input.touchCount == 1 && _pointerPressed)
            {
                Vector2 newCurrentPressedPosition = UnityEngine.Input.touches[FirstTouch].position;
                
                if (!_dragging)
                {
                    _dragging = IsDrag(_currentPressedPosition, newCurrentPressedPosition);
                }

                if (_dragging)
                {

                    if (IsDrag(newCurrentPressedPosition, _currentPressedPosition))
                    {
                        Vector2 delta = newCurrentPressedPosition - _currentPressedPosition;

                        DragEventArgs dragEventArgs = new DragEventArgs()
                        {
                            delta = delta,
                            position = _currentPressedPosition
                        };

                        OnDrag?.Invoke(dragEventArgs);
                    }
                }

                _currentPressedPosition = newCurrentPressedPosition;
            }

            if (UnityEngine.Input.touchCount == 1 && !_pointerPressed)
            {
                _currentPressedPosition = UnityEngine.Input.touches[FirstTouch].position;
                _pointerPressed = true;

                PointerEventArgs pointerEventArgs = new PointerEventArgs()
                {
                    pointerId = FirstTouch,
                    position = _currentPressedPosition
                };

                OnPointerPressed?.Invoke(pointerEventArgs);
            }

            if (UnityEngine.Input.touchCount == 0 && _pointerPressed)
            {
                PointerEventArgs pointerEventArgs = new PointerEventArgs()
                {
                    pointerId = FirstTouch,
                    position = _currentPressedPosition
                };

                if (_dragging)
                {
                    _dragging = false;
                }
                else if (_pinching)
                {
                    _pinching = false;
                }
                else
                {
                    OnTap?.Invoke(pointerEventArgs);
                }

                _pointerPressed = false;
                OnPointerReleased?.Invoke(pointerEventArgs);
            }

            if (UnityEngine.Input.touchCount == 2)
            {
                Touch touch1 = UnityEngine.Input.GetTouch(FirstTouch);
                Touch touch2 = UnityEngine.Input.GetTouch(SecondTouch);

                if (touch2.phase == TouchPhase.Began)
                {
                    _pinchDistance = Vector2.Distance(touch1.position, touch2.position);
                }

                if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
                {
                    float newDist = Vector2.Distance(touch1.position, touch2.position);
                    float delta = newDist - _pinchDistance;
                    _pinchDistance = newDist;

                    ZoomEventArgs zoomEventArgs = new ZoomEventArgs() { zoom = delta };
                    
                    if (!_pinching)
                    {
                        _pinching = true;
                    }

                    OnZoom?.Invoke(zoomEventArgs);
                }
            }
        }

        private bool IsDrag(Vector2 position1, Vector2 position2)
        {
            float distance = (position2 - position1).sqrMagnitude;

            if (distance > _sqrDragMinDistance)
                return true;

            return false;
        }
    }
}