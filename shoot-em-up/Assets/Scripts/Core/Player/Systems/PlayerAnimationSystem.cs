using Leopotam.Ecs;
using ShootEmUp.Core.Player.Components;
using UnityEngine;

namespace ShootEmUp.Core.Player.Systems
{
    public class PlayerAnimationSystem : IEcsRunSystem
    {
        private static readonly int IsMoving = Animator.StringToHash("isMoving");
        private EcsFilter<PlayerRef> _playerFilter = null;

        public void Run()
        {
            if (_playerFilter.IsEmpty())
                return;

            foreach (int index in _playerFilter)
            {
                var playerRigidbody = _playerFilter.Get1(index).Value.Rigidbody;
                var playerAnimator = _playerFilter.Get1(index).Value.Animator;

                playerAnimator.SetFloat(IsMoving, playerRigidbody.velocity.magnitude);
                Debug.Log($"{playerRigidbody.velocity.magnitude}");
            }
        }
    }
}