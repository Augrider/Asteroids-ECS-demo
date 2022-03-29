using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;

namespace Game.ECS.Systems
{
    public class SetInitialSpeedSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpawnDataComponent, TransformComponent> _filterEntities = null;


        public void Run()
        {
            foreach (var i in _filterEntities)
            {
                ref var entity = ref _filterEntities.GetEntity(i);

                ref var spawnComponent = ref _filterEntities.Get1(i);
                ref var transform = ref _filterEntities.Get2(i);

                if (entity.Has<SpeedComponent>())
                    SetSpeed(in entity, in transform, spawnComponent.speed, spawnComponent.randomizeSpeed, spawnComponent.speedDelta);

                if (entity.Has<RotationComponent>())
                    SetRotationSpeed(in entity, spawnComponent.rotationSpeed, spawnComponent.randomizeRotationSpeed, spawnComponent.rotationSpeedDelta);

                entity.Del<SpawnDataComponent>();
            }
        }



        private void SetSpeed(in EcsEntity entity, in TransformComponent transform, float value, bool randomize, float variance)
        {
            var speed = randomize ? variance * Random.Range(-1f, 1f) : 0;
            speed += value;

            entity.Get<SpeedComponent>().speed = transform.entityTransform.up * speed;
        }

        private void SetRotationSpeed(in EcsEntity entity, float value, bool randomize, float variance)
        {
            var rotationSpeed = randomize ? variance * Random.Range(-1f, 1f) : 0;
            rotationSpeed += value;

            entity.Get<RotationComponent>().rotationSpeed = rotationSpeed;
        }
    }
}