using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;
using Game.ECS.Extentions;

namespace Game.ECS.Systems
{
    public class LifetimeExpiredCleanupSystem : IEcsRunSystem
    {
        private readonly EcsFilter<LifetimeComponent>.Exclude<Timer<LifetimeComponent>> _filterExpired = null;


        public void Run()
        {
            foreach (var i in _filterExpired)
            {
                ref var entity = ref _filterExpired.GetEntity(i);
                ref var lifetimeComponent = ref _filterExpired.Get1(i);

                if (lifetimeComponent.timerStarted)
                    entity.Get<DestroyComponent>();
            }
        }
    }
}