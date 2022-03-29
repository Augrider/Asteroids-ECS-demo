using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;

namespace Game.ECS.Systems
{
    public class CreatePlayerWeaponsSystem : IEcsInitSystem
    {
        private readonly IPlayerDataProvider _playerDataProvider = null;
        private readonly EcsWorld _world = null;

        private readonly EcsFilter<Player> _filterPlayers = null;


        public void Init()
        {
            foreach (var i in _filterPlayers)
            {
                ref var player = ref _filterPlayers.GetEntity(i);
                ref var playerComponent = ref _filterPlayers.Get1(i);

                var bulletState = _playerDataProvider.weaponPrimary.CreateWeaponState(_world, in player);
                var laserState = _playerDataProvider.weaponSpecial.CreateWeaponState(_world, in player);

                playerComponent.weaponPrimary = bulletState;
                playerComponent.weaponSpecial = laserState;
            }
        }
    }
}