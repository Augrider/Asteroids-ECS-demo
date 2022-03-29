using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.ECS.Components
{
    [System.Serializable]
    public struct AccelerationComponent
    {
        public Vector2 acceleration;

        public float dragValue;
        public float dragSpeedMultiplier;
    }
}