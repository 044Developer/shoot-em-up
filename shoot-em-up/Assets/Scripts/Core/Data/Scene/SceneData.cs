using UnityEngine;

namespace ShootEmUp.Core.Data.Scene
{
    public class SceneData : MonoBehaviour
    {
        [Header("Prefab Containers")]
        [SerializeField] private Transform _singleEntitiesParent = null;
        [SerializeField] private Transform _poolableEntitiesParent = null;
        [SerializeField] private Transform _hudParent = null;

        public Transform SingleEntitiesParent => _singleEntitiesParent;
        public Transform PoolableEntitiesParent => _poolableEntitiesParent;
        public Transform HUDParent => _hudParent;
    }
}