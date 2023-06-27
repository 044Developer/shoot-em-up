using System;
using ShootEmUp.AdditionalAssets.Joystick.Area;
using ShootEmUp.AdditionalAssets.Joystick.Data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ShootEmUp.AdditionalAssets.Joystick.Joystick
{
    public class JoystickHandler : MonoBehaviour, IJoystickHandler, IJoystickInputValue
    {
        public Vector2 AxisValue { get; private set; }
        public bool IsPressed { get; private set; }

        public Action<Vector2> OnDownAction { get; private set; }
        public Action<Vector2> OnPressedAction { get; private set; }
        public Action<Vector2> OnUpAction { get; private set; }
        
        [Header("Joystick")]
        [SerializeField] private RectTransform _joystickBackgroundRect = null;
        [SerializeField] private RectTransform _joystickForegroundRect = null;

        [Header("Settings")]
        [SerializeField] private JoystickInputType _inputType;
        [Range(0, 1)][SerializeField] private float _backgroundSize = 0;
        [Range(0, 1)][SerializeField] private float _foregroundSize = 0;
        [SerializeField] private bool _isJoystickLocked = false;

        [Header("Area")]
        [SerializeField] private JoystickAreaHandler _areaHandler = null;
        [SerializeField] private RectTransform _canvasRect = null;
        [SerializeField] private ScreenOrientationMatchType _screenMatchType;
        
        private int _fingerId = -1;

        public void Activate() 
        {
            gameObject.SetActive(true);
        }
    
        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
        
        public void OnUp(PointerEventData eventData)
        {
            if (!IsPressed) return;
            IsPressed = false;
            Hide();
            AxisValue = Vector2.zero;
            _fingerId = -1;
            OnUpAction?.Invoke(eventData.position);
    
        }
    
        public void OnDown(PointerEventData eventData)
        {
            IsPressed = true;
            Show();
            
            _fingerId = eventData.pointerId;
            _joystickBackgroundRect.position = eventData.position;
            OnDownAction?.Invoke(eventData.position);
            
            OnPressed(eventData.position);
        }
        
        private void OnValidate()
        {
            UpdateSize();
        }
    
        private void Awake()
        {
            _areaHandler.Initialize(this);
        }

        private void Start()
        {
#if UNITY_ANDRIOD || UNITY_IOS
            _inputType = InputType.Touch;
#endif
            UpdateSize();
            if (Application.isPlaying)
                Hide();
        }
    
        private void Update()
        {
            UpdateSize();
            
            if (!Application.isPlaying) 
            {
                return;
            }
            
            if (!IsPressed) 
                return;
    
            if (_inputType == JoystickInputType.Touch)
            {
                foreach (Touch touch in Input.touches)
                {
                    if (touch.fingerId == _fingerId)
                    {
                        OnPressed(touch.position);
                    }
                }
            }
            else if (_inputType == JoystickInputType.Mouse)
            {
                OnPressed(Input.mousePosition);
            }
        }
        
        private void UpdateSize()
        {
            Vector2 backgroundSize = GetBackgroundSize();
            _joystickBackgroundRect.sizeDelta = backgroundSize;
            _joystickForegroundRect.sizeDelta = backgroundSize * _foregroundSize;
        }
    
        private Vector2 GetBackgroundSize()
        {
            Vector2 backgroundSize;
            if (_screenMatchType == ScreenOrientationMatchType.Horizontal)
                backgroundSize = Vector2.one * _backgroundSize * _canvasRect.sizeDelta.x;
            else
                backgroundSize = Vector2.one * _backgroundSize * _canvasRect.sizeDelta.y;
    
            return backgroundSize;
        }
    
        private void OnPressed(Vector2 touchPosition)
        {
            if (IsPressed == false) return;
            Vector2 toMouse = touchPosition - (Vector2)_joystickBackgroundRect.position;
            float distance = toMouse.magnitude;
            float pixelSize = GetBackgroundSize().x;
            float radius = pixelSize * 0.5f;
    
            if (!_isJoystickLocked)
            {
                if (distance > radius)
                {
                    Vector2 offset = toMouse - toMouse.normalized * radius;
                    _joystickBackgroundRect.position += (Vector3)offset;
                }
            }
    
            float toMouseClamped = Mathf.Clamp(distance, 0, radius);
            Vector2 stickPosition = toMouse.normalized * toMouseClamped;
            AxisValue = stickPosition / radius;
            _joystickForegroundRect.localPosition = stickPosition;
            OnPressedAction?.Invoke(touchPosition);
        }
    
        private void Show()
        {
            _joystickBackgroundRect.gameObject.SetActive(true);
            _joystickForegroundRect.gameObject.SetActive(true);
        }
    
        private void Hide()
        {
            _joystickBackgroundRect.gameObject.SetActive(false);
            _joystickForegroundRect.gameObject.SetActive(false);
        }
    }
}