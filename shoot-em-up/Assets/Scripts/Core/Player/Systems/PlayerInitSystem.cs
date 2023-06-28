using Leopotam.Ecs;
using ShootEmUp.Core.Data.Scene;
using ShootEmUp.Core.Data.Static;
using ShootEmUp.Core.Player.Components;
using UnityEngine;

namespace ShootEmUp.Core.Player.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private CoreStaticData _coreStaticData = null;
        private SceneData _sceneData = null;
        private EcsWorld _world = null;
        
        public void Init()
        {
            var playerView = Object.Instantiate(_coreStaticData.CorePrefabsStaticData.PlayerViewPrefab, _sceneData.SingleEntitiesParent);

            var playerEntity = _world.NewEntity();
            ref var playerComponent = ref playerEntity.Get<PlayerRef>();
            playerComponent.Value = playerView;
        }
    }
}