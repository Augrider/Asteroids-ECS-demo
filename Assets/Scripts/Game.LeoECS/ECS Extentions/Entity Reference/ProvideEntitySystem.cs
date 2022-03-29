using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Game.ECS.Extentions
{
    public class ProvideEntitySystem : IEcsRunSystem
    {
        private readonly EcsFilter<EntityComponent> _filterEntityComponents;


        public void Run()
        {
            foreach (var i in _filterEntityComponents)
            {
                ref var entity = ref _filterEntityComponents.GetEntity(i);
                ref var providerComponent = ref _filterEntityComponents.Get1(i);

                providerComponent.ecsEntityReference.Provide(in entity);

                entity.Del<EntityComponent>();
            }
        }
    }
}