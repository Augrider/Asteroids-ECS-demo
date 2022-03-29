using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Game.ECS.Components
{
    [System.Serializable]
    public struct WeaponStateComponent
    {
        public EcsEntity owner;
        public IWeaponProvider weaponProvider;

        public float fireCooldown;
        public float fullChargeCooldown;
        public int maxCharges;

        public float currentCharge;
        public int chargesLeft;
    }
}