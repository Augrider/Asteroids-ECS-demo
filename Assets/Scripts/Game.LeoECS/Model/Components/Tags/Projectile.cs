using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Game.ECS.Components
{
    [System.Serializable]
    public struct Projectile
    {
        public EcsEntity owner;
    }
}