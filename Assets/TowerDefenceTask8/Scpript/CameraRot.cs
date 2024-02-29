using UnityEngine;

public class MobileCameraRot : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 0.5f;
    [SerializeField] private float _moveSpeed = 5f;

    private Vector2 _lastTouchPosition;
    private bool _isDragging = false;
    private Vector2 _inversionMultiplier = new Vector2(-1f, -1f);

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _isDragging = true;
                _lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                _isDragging = false;
            }

            if (_isDragging)
            {
                Vector2 currentTouchPosition = touch.position;
                float deltaX = (currentTouchPosition.x - _lastTouchPosition.x) * _inversionMultiplier.x;
                float deltaY = (currentTouchPosition.y - _lastTouchPosition.y) * _inversionMultiplier.y;

                Vector3 moveDirection = new Vector3(deltaX, deltaY, 0f) * _sensitivity;
                moveDirection = transform.TransformDirection(moveDirection);
                transform.localPosition += moveDirection * _moveSpeed * Time.deltaTime;

                _lastTouchPosition = currentTouchPosition;
            }
        }
    }
}
