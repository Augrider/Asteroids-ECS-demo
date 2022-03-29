using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;
using Game.ECS.Extentions;

namespace Game.ECS.Systems
{
    public class SpawnNewWaveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<WaveSpawn>.Exclude<Timer<WaveSpawn>> _filterWaveEvent = null;

        private readonly IGameContext _gameContext = null;
        private readonly ISceneContext _sceneContext = null;
        private readonly EcsWorld _world = null;


        public void Run()
        {
            foreach (var i in _filterWaveEvent)
            {
                ref var waveEvent = ref _filterWaveEvent.GetEntity(i);
                ref var entityEventComponent = ref _filterWaveEvent.Get1(i);

                if (!entityEventComponent.timerStarted)
                    continue;

                SendSpawnEvents();

                waveEvent.Destroy();
            }
        }



        private void SendSpawnEvents()
        {
            var entitiesToSpawn = _gameContext.waveProvider.GetEntitiesToSpawn(_gameContext.gameState.currentWave);
            var spawnEvent = new SpawnEntityComponent();

            foreach (IEntitySpawnProvider entitySpawn in entitiesToSpawn)
            {
                spawnEvent.entitySpawnProvider = entitySpawn;
                (spawnEvent.position, spawnEvent.direction) = _sceneContext.spawnPlacement.GetPositionAndDirection();

                _world.AddEvent(spawnEvent);
            }
        }
    }
}