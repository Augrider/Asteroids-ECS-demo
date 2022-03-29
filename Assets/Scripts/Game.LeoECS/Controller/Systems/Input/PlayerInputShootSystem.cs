using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;
using Game.ECS.Extentions;

namespace Game.ECS.Systems
{
    public class PlayerInputShootSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Player, ProjectileLauncher>.Exclude<Timer<LauncherCooldown>> _filterPlayers = null;

        private readonly EcsWorld _world = null;

        private readonly IGameContext _gameContext = null;
        private readonly ISceneContext _sceneContext = null;
        private readonly IPlayerDataProvider _playerDataProvider = null;


        public void Run()
        {
            foreach (var i in _filterPlayers)
            {
                ref var entity = ref _filterPlayers.GetEntity(i);

                ref var playerData = ref _filterPlayers.Get1(i);
                ref var launcher = ref _filterPlayers.Get2(i);

                var _position = launcher.launcherPoint.position;
                var _direction = launcher.launcherPoint.up;

                if (_gameContext.playerInputs.shootSpecial)
                {
                    if (!AllowedToShoot(in playerData.weaponSpecial, out var fireCooldown))
                        continue;

                    Debug.LogWarningFormat("Shooting...");

                    SendSpawnEvent(_playerDataProvider.weaponSpecial.projectileSpawn, _position, _direction);
                    entity.Get<Timer<LauncherCooldown>>().timeLeftSec = fireCooldown;
                    return;
                }

                if (_gameContext.playerInputs.shootPrimary)
                {
                    Debug.LogWarningFormat("Primary {0}, weapon data {1}", _playerDataProvider.weaponPrimary, playerData.weaponPrimary);
                    if (!AllowedToShoot(in playerData.weaponPrimary, out var fireCooldown))
                        continue;

                    Debug.LogWarningFormat("Shooting...");

                    SendSpawnEvent(_playerDataProvider.weaponPrimary.projectileSpawn, _position, _direction);
                    entity.Get<Timer<LauncherCooldown>>().timeLeftSec = fireCooldown;
                    return;
                }
            }
        }



        private bool AllowedToShoot(in EcsEntity laserWeapon, out float fireCooldown)
        {
            Debug.LogWarningFormat("Checking weapon...");

            ref var weaponState = ref laserWeapon.Get<WeaponStateComponent>();
            fireCooldown = weaponState.fireCooldown;

            if (weaponState.chargesLeft > 0)
            {
                weaponState.chargesLeft -= 1;
                weaponState.currentCharge -= 1;
                return true;
            }

            return false;
        }

        private void SendSpawnEvent(IEntitySpawnProvider spawnProvider, Vector3 _position, Vector3 _direction)
        {
            var spawnEvent = new SpawnEntityComponent()
            {
                entitySpawnProvider = spawnProvider,
                position = _position,
                direction = _direction
            };

            _world.AddEvent(spawnEvent);
        }
    }
}