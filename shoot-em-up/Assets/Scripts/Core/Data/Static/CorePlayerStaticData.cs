using UnityEngine;

namespace ShootEmUp.Core.Data.Static
{
    [CreateAssetMenu(menuName = "StaticData/Core Player Static Data", fileName = "core_player_static_data")]
    public class CorePlayerStaticData : ScriptableObject
    {
        [Header("Settings")]
        [SerializeField] private float _playerSpeed = 5f;

        public float PlayerSpeed => _playerSpeed;
    }
}