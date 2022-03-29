using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;

namespace Game.ECS.Systems
{
    public class PlayerInputMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TransformComponent, RotationComponent, AccelerationComponent, InputParametersComponent, Player> _filterPlayers = null;

        private readonly IGameContext _gameContext = null;
        private readonly ISceneContext _sceneContext = null;


        public void Run()
        {
            foreach (var i in _filterPlayers)
            {
                ref var transform = ref _filterPlayers.Get1(i);
                ref var rotation = ref _filterPlayers.Get2(i);
                ref var acceleration = ref _filterPlayers.Get3(i);
                ref var inputParameters = ref _filterPlayers.Get4(i);

                var direction = transform.rotationTransform.up;

                acceleration.acceleration = (_gameContext.playerInputs.movementInput.y * inputParameters.maxAcceleration) * direction;
                rotation.rotationSpeed = _gameContext.playerInputs.movementInput.x * inputParameters.rotationSpeed;
            }
        }
    }
}