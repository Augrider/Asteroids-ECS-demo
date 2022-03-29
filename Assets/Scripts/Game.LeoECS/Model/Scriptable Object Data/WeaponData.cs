using System.Collections;
using System.Collections.Generic;
using Game.ECS.Components;
using Leopotam.Ecs;
using ScriptableObjectsSystem.Variables;
using UnityEngine;

namespace Game.ECS.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ECS/Weapon Data")]
    public class WeaponData : ScriptableSpawnProvider, IWeaponProvider, IEntitySpawnProvider
    {
        public IEntitySpawnProvider projectileSpawn => this;

        public int maxCharges => _maxCharges;
        public float fullChargeCooldown => _fullChargeCooldown;
        public float fireCooldown => _fireCooldown;

        [SerializeField] private int _maxCharges = 2;
        [SerializeField] private float _fullChargeCooldown = 0.5f;
        [SerializeField] private float _fireCooldown = 1;


        public EcsEntity CreateWeaponState(EcsWorld world, in EcsEntity owner)
        {
            var entity = world.NewEntity();

            ref var weaponState = ref entity.Get<WeaponStateComponent>();

            weaponState.weaponProvider = this;
            weaponState.owner = owner;

            weaponState.fireCooldown = fireCooldown;
            weaponState.fullChargeCooldown = fullChargeCooldown;
            weaponState.maxCharges = maxCharges;

            return entity;
        }


        protected override Transform GetParentTransform(ISceneContext sceneContext) => sceneContext.projectilesParent;
    }
}