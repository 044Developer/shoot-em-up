using ShootEmUp.AdditionalAssets.Joystick.Joystick;
using ShootEmUp.Core.Player.UnityComponents;
using ShootEmUp.Core.World.UnityComponents;
using UnityEngine;

namespace ShootEmUp.Core.Data.Static
{
    [CreateAssetMenu(menuName = "StaticData/Core Prefab Static Data", fileName = "core_prefabs_static_data")]
    public class CorePrefabsStaticData : ScriptableObject
    {
        [Header("World")]
        [SerializeField] private CameraView _cameraViewPrefab = null;

        [Header("Player")]
        [SerializeField] private PlayerView _playerViewPrefab = null;

        [Header("UI")]
        [SerializeField] private JoystickHandler _joystickHandler = null;

        public CameraView CameraViewPrefab => _cameraViewPrefab;
        public PlayerView PlayerViewPrefab => _playerViewPrefab;
        public JoystickHandler JoystickHandler => _joystickHandler;
    }
}