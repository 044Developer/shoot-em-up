using UnityEngine;

namespace ShootEmUp.AdditionalAssets.Joystick.Joystick
{
    public interface IJoystickInputValue
    {
        Vector2 AxisValue { get; }
        bool IsPressed { get; }
    }
}