using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;

namespace Game.ECS.Systems
{
    public sealed class ApplyAccelerationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AccelerationComponent, SpeedComponent> _filterAcceleration = null;


        public void Run()
        {
            foreach (var i in _filterAcceleration)
            {
                ref var accelerationComponent = ref _filterAcceleration.Get1(i);
                ref var speedComponent = ref _filterAcceleration.Get2(i);

                var dragVector = GetDragValue(accelerationComponent, speedComponent.speed);
                speedComponent.speed += (accelerationComponent.acceleration - dragVector) * Time.fixedDeltaTime;
            }
        }



        private Vector2 GetDragValue(AccelerationComponent acceleration, Vector2 speedVector)
        {
            return (acceleration.dragValue + acceleration.dragSpeedMultiplier * speedVector.magnitude) * speedVector.normalized;
        }
    }
}