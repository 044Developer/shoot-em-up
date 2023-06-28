using UnityEngine;

namespace ShootEmUp.Core.Data.Static
{
    [CreateAssetMenu(menuName = "StaticData/Static Data Container", fileName = "core_static_data")]
    public class CoreStaticData : ScriptableObject
    {
        [Header("Prefabs")]
        [SerializeField] private CorePrefabsStaticData _corePrefabsStaticData = null;

        [Header("Player Settings")]
        [SerializeField] private CorePlayerStaticData _playerStaticData = null;
        
        [Header("Camera Settings")]
        [SerializeField] private CoreCameraStaticData _cameraStaticData = null;
        
        public CorePrefabsStaticData CorePrefabsStaticData => _corePrefabsStaticData;
        public CorePlayerStaticData PlayerStaticData => _playerStaticData;
        public CoreCameraStaticData CameraStaticData => _cameraStaticData;
    }
}