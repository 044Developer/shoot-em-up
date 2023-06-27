using ShootEmUp.AdditionalAssets.Joystick.Joystick;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ShootEmUp.AdditionalAssets.Joystick.Area
{
    public class JoystickAreaHandler : MonoBehaviour, IJoystickAreaHandler, IPointerDownHandler, IPointerUpHandler
    {
        private IJoystickHandler _handler = null;
        
        public void Initialize(IJoystickHandler handler) => 
            _handler = handler;

        public void OnPointerDown(PointerEventData eventData) => 
            _handler.OnDown(eventData);

        public void OnPointerUp(PointerEventData eventData) => 
            _handler.OnUp(eventData);
    }
}