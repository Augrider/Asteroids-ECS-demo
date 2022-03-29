using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;
using Game.ECS.Extentions;

namespace Game.ECS.Systems
{
    public class SpawnEntitiesSystem : IEcsRunSystem
    {
        private readonly ISceneContext _sceneContext = null;

        private readonly EcsFilter<SpawnEntityComponent> _filterSpawnEvents = null;


        public void Run()
        {
            foreach (var i in _filterSpawnEvents)
            {
                ref var spawnEvent = ref _filterSpawnEvents.Get1(i);

                Debug.LogWarningFormat("Spawning {0}, position {1}, direction {2}", spawnEvent.entitySpawnProvider, spawnEvent.position, spawnEvent.direction);
                spawnEvent.entitySpawnProvider.GetNewEntity(_sceneContext, spawnEvent.position, spawnEvent.direction);
            }
        }
    }
}