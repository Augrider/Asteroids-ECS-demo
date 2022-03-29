using UnityEngine;

namespace Game.ECS.Components
{
    [System.Serializable]
    public struct SpawnOnDeathComponent
    {
        public IEntitySpawnProvider spawnProvider => entityData;
        [SerializeField] private ScriptableSpawnProvider entityData;

        public int amount;
    }
}