using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;

namespace Game.ECS.Systems
{
    public class CreateFirstWaveSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;


        public void Init()
        {
            _world.AddEvent<WaveSpawn>();
        }
    }
}