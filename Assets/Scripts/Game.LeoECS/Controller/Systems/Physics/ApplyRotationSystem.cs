using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;

namespace Game.ECS.Systems
{
    public sealed class ApplyRotationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TransformComponent, RotationComponent> _filterRotation = null;


        public void Run()
        {
            foreach (var i in _filterRotation)
            {
                ref var transform = ref _filterRotation.Get1(i);
                ref var rotationComponent = ref _filterRotation.Get2(i);

                transform.rotationTransform.Rotate(0, 0, -rotationComponent.rotationSpeed * Time.fixedDeltaTime);
            }
        }
    }
}