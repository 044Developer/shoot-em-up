using Leopotam.Ecs;
using ShootEmUp.Core.Data.Scene;
using ShootEmUp.Core.Data.Static;
using ShootEmUp.Core.World.Components;
using UnityEngine;

namespace ShootEmUp.Core.World.Systems
{
    public class HUDInitSystem : IEcsInitSystem
    {
        private CoreStaticData _coreStaticData = null;
        private SceneData _sceneData = null;
        private EcsWorld _world = null;
        
        public void Init()
        {
            var joystickEntity = _world.NewEntity();

            var joystickHandler = Object.Instantiate(_coreStaticData.CorePrefabsStaticData.JoystickHandler, _sceneData.HUDParent);

            ref var joystickComponent = ref joystickEntity.Get<JoystickRef>();
            
            joystickComponent.Value = joystickHandler;
        }
    }
}