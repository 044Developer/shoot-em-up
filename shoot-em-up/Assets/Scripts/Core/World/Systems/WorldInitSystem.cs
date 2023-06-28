using Leopotam.Ecs;
using ShootEmUp.Core.Data.Scene;
using ShootEmUp.Core.Data.Static;
using ShootEmUp.Core.World.Components;
using UnityEngine;

namespace ShootEmUp.Core.World.Systems
{
    public class WorldInitSystem : IEcsInitSystem
    {
        private CoreStaticData _coreStaticData = null;
        private SceneData _sceneData = null;
        private EcsWorld _world = null;
        
        public void Init()
        {
            var cameraEntity = _world.NewEntity();

            var cameraView = Object.Instantiate(_coreStaticData.CorePrefabsStaticData.CameraViewPrefab, _sceneData.SingleEntitiesParent);

            cameraView.CameraAngleTransform.rotation = Quaternion.Euler(_coreStaticData.CameraStaticData.CameraAngle.x, _coreStaticData.CameraStaticData.CameraAngle.y, _coreStaticData.CameraStaticData.CameraAngle.z);
            cameraView.CameraDepthTransform.localPosition = _coreStaticData.CameraStaticData.CameraDistance;
            
            ref var cameraComponent = ref cameraEntity.Get<CameraRef>();
            cameraComponent.Value = cameraView;
        }
    }
}