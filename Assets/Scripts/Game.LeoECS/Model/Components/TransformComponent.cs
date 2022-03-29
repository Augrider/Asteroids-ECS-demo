using UnityEngine;

namespace Game.ECS.Components
{
    [System.Serializable]
    public struct TransformComponent
    {
        public Transform entityTransform;
        public Transform rotationTransform;
    }
}