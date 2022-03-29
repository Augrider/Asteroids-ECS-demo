using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
using System;
using Game.ECS.Components;
using Game.ECS.Services;
using Game.ECS.Systems;
using Game.ECS.Extentions;

namespace Game.ECS
{
    public class ECSLoader : MonoBehaviour, IECSHandler
    {
        public bool worldExists => _world != null;
        private EcsWorld _world;

        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;

        [SerializeField] private SceneContext _sceneContext;
        [SerializeField] private ScriptableObjects.GameConfiguration _gameContext;
        [SerializeField] private ScriptableObjects.PlayerDataProvider _playerDataProvider;


        IEnumerator Start()
        {
            ECSLocator.Provide(this);

            _world = new EcsWorld();

            _updateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);

            InitializeUpdateSystems();
            InitializeFixedUpdateSystems();

            _updateSystems.Init();
            _fixedUpdateSystems.Init();

            yield return null;

            CreatePlayerWeapons();
        }

        void Update()
        {
            _updateSystems?.Run();
        }

        void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }


        void OnDestroy()
        {
            _world?.Destroy();
            _updateSystems?.Destroy();
            _fixedUpdateSystems?.Destroy();

            _world = null;
            _updateSystems = null;
            _fixedUpdateSystems = null;

            ECSLocator.Provide(null);
            _gameContext.gameState.Reset();
        }


        public void AddEvent<T>() where T : struct
        {
            _world?.AddEvent<T>();
        }

        public void AddEvent<T>(in T component) where T : struct
        {
            _world?.AddEvent<T>(in component);
        }



        private void InitializeUpdateSystems()
        {
            _updateSystems
                .ConvertScene()

                //Initialize weapons and player
                .Add(new SpawnPlayerSystem())
                .Add(new CreatePlayerWeaponsSystem())

                //Provide entity references
                .Add(new ProvideEntitySystem())

                //Check for wave spawn
                .Add(new CheckForNewWaveSystem())
                .Add(new SpawnNewWaveSystem())

                //Check for player death
                .Add(new CheckForPlayerDeadSystem())

                //Handle input and AI
                .Add(new PlayerInputMoveSystem())
                .Add(new PlayerInputShootSystem())
                .Add(new ChasePlayerSystem())

                //Update weapon states
                .Add(new UpdateWeaponStatesSystem())

                //Update Player UI
                .Add(new PlayerUpdateUISystem())

                //Handle entities pre-Cleanup behavior
                .Add(new SpawnOnDeathSystem())
                .Add(new AddScoreSystem())
                //Handle entities cleanup
                .Add(new DespawnDamagedSystem())
                //Handle entities spawn
                .Add(new SpawnEntitiesSystem())

                .OneFrame<SpawnEntityComponent>()

                .Inject((ISceneContext)_sceneContext)
                .Inject((IGameContext)_gameContext)
                .Inject((IPlayerDataProvider)_playerDataProvider);
        }

        private void InitializeFixedUpdateSystems()
        {
            _fixedUpdateSystems
                .Add(new SetInitialSpeedSystem())

                //Handle lifetime entities
                .Add(new LifetimeExpiredCleanupSystem())
                .Add(new SetLifetimeTimersSystem())

                //Handle invisible projectiles
                .Add(new RemoveLifetimeFromVisibleProjectilesSystem())
                .Add(new AddLifetimeToInvisibleProjectilesSystem())

                .Add(new TimerSystem<LifetimeComponent>())
                .Add(new TimerSystem<LauncherCooldown>())
                .Add(new TimerSystem<WaveSpawn>())

                .Add(new ApplyRotationSystem())
                .Add(new ApplyAccelerationSystem())
                .Add(new ApplySpeedSystem())

                //Handle invisible entities
                .Add(new LoopEntitiesSystem())

                .Inject((ISceneContext)_sceneContext)
                .Inject((IGameContext)_gameContext)
                .Inject((IPlayerDataProvider)_playerDataProvider);
        }


        private void CreatePlayerWeapons()
        {
            var postInitSystem = new EcsSystems(_world);

            postInitSystem

            .Add(new CreatePlayerWeaponsSystem())
            .Inject((IPlayerDataProvider)_playerDataProvider)

            .Init();

            postInitSystem.Destroy();
        }
    }
}