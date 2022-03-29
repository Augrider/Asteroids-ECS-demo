using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;
using Game.ECS.Extentions;

namespace Game.ECS.Systems
{
    public class RemoveLifetimeFromVisibleProjectilesSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerOwned, LifetimeComponent, Projectile, SpeedComponent>.Exclude<InvisibleComponent> _filterInvisible = null;


        public void Run()
        {
            foreach (var i in _filterInvisible)
            {
                ref var entity = ref _filterInvisible.GetEntity(i);

                entity.Del<LifetimeComponent>();
                entity.Del<Timer<LifetimeComponent>>();
            }
        }
    }
}