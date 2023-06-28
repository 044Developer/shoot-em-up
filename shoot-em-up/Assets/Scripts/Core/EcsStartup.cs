using Leopotam.Ecs;
using ShootEmUp.Core.Data.Scene;
using ShootEmUp.Core.Data.Static;
using ShootEmUp.Core.Player.Systems;
using ShootEmUp.Core.World.Systems;
using UnityEngine;

namespace ShootEmUp.Core
{
    sealed class EcsStartup : MonoBehaviour
    {
        [Header("Static")]
        [SerializeField] private CoreStaticData _coreStaticData = null;
        
        [Header("Scene")]
        [SerializeField] private SceneData _sceneData = null;
        
        private EcsWorld _world;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;

        private void Start()
        {
            _world = new EcsWorld();

            RegisterUpdateSystems();
            
            RegisterFixedUpdateSystems();

            DebugECSInEditor();
        }

        private void Update()
        {
            _updateSystems?.Run();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }

        private void OnDestroy()
        {
            CleanUpdateSystems();
            
            CleanFixedUpdateSystems();
            
            CleanWorld();
        }

        #region Update System

        private void RegisterUpdateSystems()
        {
            _updateSystems = new EcsSystems(_world);
            
            _updateSystems
                .Add(new WorldInitSystem())
                .Add(new PlayerInitSystem())
                .Add(new HUDInitSystem())
                .Add(new PlayerAnimationSystem())
                .Add(new CameraMoveSystem())
                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()

                .Inject(_coreStaticData)
                .Inject(_sceneData)
                .Init();
        }

        private void CleanUpdateSystems()
        {
            if (_updateSystems != null)
            {
                _updateSystems.Destroy();
                _updateSystems = null;
            }
        }
        
        #endregion

        #region Fixed Update System
        
        private void RegisterFixedUpdateSystems()
        {
            _fixedUpdateSystems = new EcsSystems(_world);
            
            _fixedUpdateSystems
                // register your systems here, for example:
                .Add(new PlayerMoveSystem())
                // .Add (new TestSystem2 ())

                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()

                .Inject(_coreStaticData)
                .Inject(_sceneData)
                .Init();
        }

        private void CleanFixedUpdateSystems()
        {   
            if (_fixedUpdateSystems != null)
            {
                _fixedUpdateSystems.Destroy();
                _fixedUpdateSystems = null;
            }
        }
        
        #endregion

        private void CleanWorld()
        {
            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }

        private void DebugECSInEditor()
        {
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_updateSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_fixedUpdateSystems);
#endif
        }
    }
}