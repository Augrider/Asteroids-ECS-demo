using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;

namespace Game.ECS.Systems
{
    public class UpdateWeaponStatesSystem : IEcsRunSystem
    {
        private readonly EcsFilter<WeaponStateComponent> _filterWeapons = null;


        public void Run()
        {
            foreach (var i in _filterWeapons)
            {
                ref var weaponState = ref _filterWeapons.Get1(i);

                weaponState.currentCharge = GetNewCurrentCharge
                (
                    weaponState.currentCharge,
                    weaponState.fullChargeCooldown,
                    weaponState.maxCharges,
                    Time.deltaTime
                );

                weaponState.chargesLeft = GetChargesLeft(weaponState.currentCharge);
            }
        }



        private static int GetChargesLeft(float currentCharge)
        {
            return Mathf.FloorToInt(currentCharge);
        }

        private static float GetNewCurrentCharge(float currentCharge, float fullChargeCooldown, int maxCharges, float deltaTime)
        {
            return Mathf.Clamp(currentCharge + deltaTime / fullChargeCooldown, 0, maxCharges);
        }
    }
}