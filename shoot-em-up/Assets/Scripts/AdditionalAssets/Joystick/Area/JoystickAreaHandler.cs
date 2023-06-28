using ShootEmUp.AdditionalAssets.Joystick.Joystick;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ShootEmUp.AdditionalAssets.Joystick.Area
{
    public class JoystickAreaHandler : MonoBehaviour, IJoystickAreaHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Color _playColor;
        [SerializeField] private Image _areaDebugImage = null;
        
        private IJoystickHandler _handler = null;
        
        public void Initialize(IJoystickHandler handler)
        {
            _handler = handler;
            _areaDebugImage.color = _playColor;
        }

        public void OnPointerDown(PointerEventData eventData) => 
            _handler.OnDown(eventData);

        public void OnPointerUp(PointerEventData eventData) => 
            _handler.OnUp(eventData);
    }
}