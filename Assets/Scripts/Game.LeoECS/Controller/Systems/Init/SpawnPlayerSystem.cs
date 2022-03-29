using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;

namespace Game.ECS.Systems
{
    public class SpawnPlayerSystem : IEcsPreInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly ISceneContext _sceneContext = null;
        private readonly IPlayerDataProvider _playerDataProvider = null;

        private readonly EcsFilter<Player> _filterPlayers = null;


        public void PreInit()
        {
            foreach (var i in _filterPlayers)
            {
                return;
            }

            _playerDataProvider.playerSpawn.GetNewEntity(_sceneContext, Vector3.zero, Vector2.zero);
        }
    }
}