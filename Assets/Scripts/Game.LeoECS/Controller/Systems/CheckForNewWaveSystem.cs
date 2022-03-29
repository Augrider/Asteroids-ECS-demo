using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;
using Game.ECS.Extentions;

namespace Game.ECS.Systems
{
    public class CheckForNewWaveSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly IGameContext _gameContext = null;

        private readonly EcsFilter<Enemy> _filterEnemies = null;
        private readonly EcsFilter<WaveSpawn> _filterEvents = null;


        public void Run()
        {
            foreach (var i in _filterEvents)
                return;

            if (_filterEnemies.GetEntitiesCount() <= 0)
                AddSpawnEvent();
        }



        private void AddSpawnEvent()
        {
            _gameContext.gameState.AddWave();

            var eventEntity = _world.AddEvent<WaveSpawn>();

            ref var waveSpawn = ref eventEntity.Get<WaveSpawn>();
            ref var timer = ref eventEntity.Get<Timer<WaveSpawn>>();

            timer.timeLeftSec = _gameContext.waveSpawnCooldown;
            waveSpawn.timerStarted = true;
        }
    }
}