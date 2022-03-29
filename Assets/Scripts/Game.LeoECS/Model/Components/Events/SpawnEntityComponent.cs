using UnityEngine;

namespace Game.ECS.Components
{
    [System.Serializable]
    public struct SpawnEntityComponent
    {
        public IEntitySpawnProvider entitySpawnProvider;

        public Vector3 position;
        public Vector2 direction;
    }
}