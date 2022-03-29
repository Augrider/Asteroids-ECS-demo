using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;
using Game.ECS.Services;

namespace Game.ECS.Systems
{
    public class PlayerUpdateUISystem : IEcsRunSystem
    {
        private readonly EcsFilter<TransformComponent, SpeedComponent, RotationComponent, Player> _filterPlayers = null;


        public void Run()
        {
            foreach (var i in _filterPlayers)
            {
                ref var entity = ref _filterPlayers.GetEntity(i);

                ref var transform = ref _filterPlayers.Get1(i);
                ref var speedComponent = ref _filterPlayers.Get2(i);
                ref var rotationComponent = ref _filterPlayers.Get3(i);
                ref var playerComponent = ref _filterPlayers.Get4(i);

                var playerUI = PlayerUILocator.service;

                playerUI.UpdatePlayerPosition(transform.entityTransform.position);
                playerUI.UpdatePlayerSpeed(speedComponent.speed);
                playerUI.UpdatePlayerOrientation(transform.rotationTransform);

                if (playerComponent.weaponSpecial.IsNull() || !playerComponent.weaponSpecial.IsAlive() || !playerComponent.weaponSpecial.Has<WeaponStateComponent>())
                    return;

                playerUI.UpdateLaserCharges(playerComponent.weaponSpecial.Get<WeaponStateComponent>().currentCharge);
            }
        }
    }
}