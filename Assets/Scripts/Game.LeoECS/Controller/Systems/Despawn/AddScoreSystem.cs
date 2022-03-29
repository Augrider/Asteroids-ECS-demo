using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;

namespace Game.ECS.Systems
{
    public class AddScoreSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ScoreComponent, DestroyComponent> _filterScore = null;

        private readonly IGameContext _gameContext = null;


        public void Run()
        {
            foreach (var i in _filterScore)
            {
                ref var scoreComponent = ref _filterScore.Get1(i);

                _gameContext.gameState.AddScore(scoreComponent.value);
            }
        }
    }
}