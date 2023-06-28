using UnityEngine;

namespace ShootEmUp.Core.Data.Static
{
    [CreateAssetMenu(menuName = "StaticData/Core Camera Static Data", fileName = "core_camera_static_data")]
    public class CoreCameraStaticData : ScriptableObject
    {
        [Header("Settings")]
        [SerializeField] private Vector3 _cameraAngle = Vector3.zero;
        [SerializeField] private Vector3 _cameraDistance = Vector3.zero;

        public Vector3 CameraAngle => _cameraAngle;
        public Vector3 CameraDistance => _cameraDistance;
    }
}