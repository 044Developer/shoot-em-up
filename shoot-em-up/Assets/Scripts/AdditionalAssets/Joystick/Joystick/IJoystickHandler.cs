using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ShootEmUp.AdditionalAssets.Joystick.Joystick
{
    public interface IJoystickHandler
    {
        Action<Vector2> OnDownAction { get; }
        Action<Vector2> OnPressedAction { get; }
        Action<Vector2> OnUpAction { get; }
        void Activate();
        void Deactivate();
        void OnDown(PointerEventData eventData);
        void OnUp(PointerEventData eventData);
    }
}