using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voody.UniLeo;

namespace Game.ECS.ScriptableObjects
{
    [CreateAssetMenu]
    public class SpaceEntityData : ScriptableSpawnProvider
    {
        public int spawnScoreCost;
    }
}