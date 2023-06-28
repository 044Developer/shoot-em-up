using Leopotam.Ecs;
using ShootEmUp.Core.Player.Components;
using ShootEmUp.Core.World.Components;
using UnityEngine;

namespace ShootEmUp.Core.World.Systems
{
    public class CameraMoveSystem : IEcsRunSystem
    {
        private EcsFilter<CameraRef> _cameraFilter = null;
        private EcsFilter<PlayerRef> _playerFilter = null;

        public void Run()
        {
            Transform playerPosition = null;
            
            foreach (int index in _playerFilter)
            {
                playerPosition = _playerFilter.Get1(index).Value.Transform;
            }

            if (playerPosition == null)
                return;

            foreach (int index in _cameraFilter)
            {
                var cameraPosition = _cameraFilter.Get1(index).Value.CameraTransform;

                cameraPosition.position = playerPosition.position;
            }
        }
    }
}