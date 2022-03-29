using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;

namespace Game.ECS.Systems
{
    public class ChasePlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Player, TransformComponent>.Exclude<DestroyComponent> _filterPlayers = null;
        private readonly EcsFilter<Enemy, TransformComponent, SpeedComponent, ChasePlayerComponent>.Exclude<DestroyComponent> _filterChasers = null;


        public void Run()
        {
            if (_filterPlayers.GetEntitiesCount() <= 0)
                return;

            foreach (var i in _filterChasers)
            {
                ref var enemyTransform = ref _filterChasers.Get2(i).entityTransform;

                ref var speedComponent = ref _filterChasers.Get3(i);
                ref var chaseParameters = ref _filterChasers.Get4(i);

                var playerTransform = GetPlayerTransform(_filterPlayers.GetEntitiesCount());

                SetEnemySpeed(in playerTransform, in enemyTransform, ref speedComponent, in chaseParameters);
            }
        }



        private Transform GetPlayerTransform(int playerCount)
        {
            var playerIndex = Random.Range(0, playerCount);

            return _filterPlayers.Get2(playerIndex).entityTransform;
        }

        private void SetEnemySpeed(in Transform playerTransform, in Transform enemyTransform, ref SpeedComponent speedComponent, in ChasePlayerComponent chaseParameters)
        {
            var distance = playerTransform.localPosition - enemyTransform.localPosition;
            var speed = chaseParameters.baseSpeed + chaseParameters.playerDistanceMultiplier * distance.magnitude;

            speedComponent.speed = speed * distance.normalized;
        }
    }
}