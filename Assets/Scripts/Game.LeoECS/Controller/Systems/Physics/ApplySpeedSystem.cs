using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;

namespace Game.ECS.Systems
{
    public sealed class ApplySpeedSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpeedComponent, TransformComponent> _filterSpeed = null;


        public void Run()
        {
            foreach (var i in _filterSpeed)
            {
                ref var speedComponent = ref _filterSpeed.Get1(i);
                ref var transformComponent = ref _filterSpeed.Get2(i);

                var increment = (Vector3)speedComponent.speed * Time.fixedDeltaTime;
                increment.z = 0;

                transformComponent.entityTransform.position += increment;
            }
        }
    }
}