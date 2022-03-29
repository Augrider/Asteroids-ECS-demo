using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;
using Game.ECS.Extentions;
using Game.ECS.Services;

namespace Game.ECS.Systems
{
    public class CheckForPlayerDeadSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Player> _filterPlayers = null;

        private readonly ISceneContext _sceneContext = null;


        public void Run()
        {
            if (!_sceneContext.gameSessionInProgress)
            {
                FindIsPlayerLoaded();
                return;
            }

            foreach (var i in _filterPlayers)
                return;

            _sceneContext.ToggleGameSessionProgress(false);
            SceneLoaderLocator.service.ToGameOver();
        }



        private void FindIsPlayerLoaded()
        {
            foreach (var i in _filterPlayers)
                _sceneContext.ToggleGameSessionProgress(true);

            return;
        }
    }
}