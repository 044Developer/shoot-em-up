using UnityEngine;

namespace ShootEmUp.Core.World.UnityComponents
{
    public class CameraView : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera = null;
        [SerializeField] private Transform _cameraTransform = null;
        [SerializeField] private Transform _cameraDepthTransform = null;
        [SerializeField] private Transform _cameraAngleTransform = null;

        public Camera MainCamera => _mainCamera;
        public Transform CameraTransform => _cameraTransform;
        public Transform CameraDepthTransform => _cameraDepthTransform;
        public Transform CameraAngleTransform => _cameraAngleTransform;
    }
}