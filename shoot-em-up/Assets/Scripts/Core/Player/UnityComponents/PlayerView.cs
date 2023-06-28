using UnityEngine;

namespace ShootEmUp.Core.Player.UnityComponents
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform _transform = null;
        [SerializeField] private Rigidbody _rigidbody = null;
        [SerializeField] private Animator _animator = null;

        public Transform Transform => _transform;
        public Rigidbody Rigidbody => _rigidbody;
        public Animator Animator => _animator;
    }
}