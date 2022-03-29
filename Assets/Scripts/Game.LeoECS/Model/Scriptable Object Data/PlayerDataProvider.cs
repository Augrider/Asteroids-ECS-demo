using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.ECS.ScriptableObjects
{
    [CreateAssetMenu]
    public class PlayerDataProvider : ScriptableObject, IPlayerDataProvider
    {
        public IEntitySpawnProvider playerSpawn => entityData;
        public IWeaponProvider weaponPrimary => primaryWeapon;
        public IWeaponProvider weaponSpecial => specialWeapon;

        public float invisibleProjectilesLifetime => _invisibleProjectilesLifetime;

        [SerializeField] private SpaceEntityData entityData;
        [SerializeField] private WeaponData primaryWeapon;
        [SerializeField] private WeaponData specialWeapon;

        [SerializeField] private float _invisibleProjectilesLifetime;
    }
}