using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerDataProvider
{
    IEntitySpawnProvider playerSpawn { get; }

    IWeaponProvider weaponPrimary { get; }
    IWeaponProvider weaponSpecial { get; }

    float invisibleProjectilesLifetime { get; }
}