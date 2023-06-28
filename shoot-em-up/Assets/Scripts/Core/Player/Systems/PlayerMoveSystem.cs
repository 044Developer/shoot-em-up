using Leopotam.Ecs;
using ShootEmUp.Core.Data.Static;
using ShootEmUp.Core.Player.Components;
using ShootEmUp.Core.World.Components;
using UnityEngine;

namespace ShootEmUp.Core.Player.Systems
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private CoreStaticData _staticData = null;
        private EcsFilter<PlayerRef> _playerFilter = null;
        private EcsFilter<JoystickRef> _joystickFilter = null;

        public void Run()
        {
            Vector2 cachedInputVector = Vector2.zero;
            
            foreach (int index in _joystickFilter)
            {
                Vector2 inputVector = _joystickFilter.Get1(index).Value.AxisValue;
                cachedInputVector = inputVector;
            }

            foreach (int index in _playerFilter)
            {
                var playerRigidbody = _playerFilter.Get1(index).Value.Rigidbody;
                var playerTransform = _playerFilter.Get1(index).Value.Transform;
                
                playerRigidbody.velocity = new Vector3(cachedInputVector.x, 0f, cachedInputVector.y) * _staticData.PlayerStaticData.PlayerSpeed;

                if (playerRigidbody.velocity != Vector3.zero)
                {
                    playerTransform.rotation = Quaternion.LookRotation(playerRigidbody.velocity, Vector3.up);
                }
            }
        }
    }
}