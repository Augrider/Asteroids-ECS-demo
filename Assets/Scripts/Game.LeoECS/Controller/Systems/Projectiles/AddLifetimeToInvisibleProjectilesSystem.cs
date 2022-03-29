using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;
using Game.ECS.Extentions;

namespace Game.ECS.Systems
{
    public class AddLifetimeToInvisibleProjectilesSystem : IEcsRunSystem
    {
        private readonly IPlayerDataProvider _playerDataProvider = null;

        private readonly EcsFilter<PlayerOwned, Projectile, InvisibleComponent, SpeedComponent>.Exclude<LifetimeComponent> _filterInvisible = null;


        public void Run()
        {
            foreach (var i in _filterInvisible)
            {
                ref var entity = ref _filterInvisible.GetEntity(i);

                entity.Get<LifetimeComponent>().lifetimeSec = _playerDataProvider.invisibleProjectilesLifetime;
            }
        }
    }
}