using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

/// <summary>
/// Provider for projectiles and weapon states. Creates entities in code for parameters injection
/// </summary>
public interface IWeaponProvider
{
    IEntitySpawnProvider projectileSpawn { get; }
    EcsEntity CreateWeaponState(EcsWorld world, in EcsEntity owner);
}