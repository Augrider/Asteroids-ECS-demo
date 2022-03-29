using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECS.Components
{
    [System.Serializable]
    public struct Player
    {
        public EcsEntity weaponPrimary;
        public EcsEntity weaponSpecial;
    }
}