using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;
using Game.ECS.Extentions;

namespace Game.ECS.Systems
{
    public class SetLifetimeTimersSystem : IEcsRunSystem
    {
        private readonly EcsFilter<LifetimeComponent>.Exclude<Timer<LifetimeComponent>> _filterLifetime = null;


        public void Run()
        {
            foreach (var i in _filterLifetime)
            {
                ref var entity = ref _filterLifetime.GetEntity(i);
                ref var lifetimeComponent = ref _filterLifetime.Get1(i);

                if (!lifetimeComponent.timerStarted)
                {
                    entity.Get<Timer<LifetimeComponent>>().timeLeftSec = lifetimeComponent.lifetimeSec;
                    lifetimeComponent.timerStarted = true;
                }
            }
        }
    }
}