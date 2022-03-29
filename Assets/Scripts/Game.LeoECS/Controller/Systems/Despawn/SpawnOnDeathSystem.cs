using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;
using CommonExtentions;

namespace Game.ECS.Systems
{
    public class SpawnOnDeathSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpawnOnDeathComponent, TransformComponent, DestroyComponent> _filterSpawners = null;

        private readonly EcsWorld _world = null;
        private readonly IGameContext _gameContext = null;


        public void Run()
        {
            foreach (var i in _filterSpawners)
            {
                ref var spawnComponent = ref _filterSpawners.Get1(i);
                ref var transform = ref _filterSpawners.Get2(i).entityTransform;

                SpawnEntities(transform.localPosition, transform.up, in spawnComponent);
            }
        }



        private void SpawnEntities(Vector3 position, Vector2 parentDirection, in SpawnOnDeathComponent spawnComponent)
        {
            var direction = parentDirection;

            for (int i = 0; i < spawnComponent.amount; i++)
            {
                SendSpawnEvent(spawnComponent.spawnProvider, position, direction);
                direction.Rotate(360f / spawnComponent.amount);
            }
        }

        private void SendSpawnEvent(IEntitySpawnProvider spawnProvider, Vector3 position, Vector2 direction)
        {
            var spawnEvent = new SpawnEntityComponent();

            spawnEvent.entitySpawnProvider = spawnProvider;
            spawnEvent.position = position;
            spawnEvent.direction = direction;

            _world.AddEvent(spawnEvent);
        }
    }
}