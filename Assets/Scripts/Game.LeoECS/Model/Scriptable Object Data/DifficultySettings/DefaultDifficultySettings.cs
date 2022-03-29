using System.Collections;
using System.Collections.Generic;
using Game.ECS.ScriptableObjects;
using UnityEngine;

namespace Game.ECS.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ECS/Game Settings/Wave")]
    public class DefaultDifficultySettings : DifficultySettings
    {
        [SerializeField] protected int initialWaveCost;
        [SerializeField] protected int waveCostRaise;

        [SerializeField] protected int maxSaucersPerWave;

        [SerializeField] protected SpaceEntityData asteroid;
        [SerializeField] protected SpaceEntityData saucer;


        public override IEntitySpawnProvider[] GetEntitiesToSpawn(int waveCount)
        {
            var totalCost = initialWaveCost + waveCostRaise * (waveCount - 1);

            var saucersAmount = GetSaucersAmount(totalCost, saucer.spawnScoreCost, maxSaucersPerWave + waveCount / 5);
            totalCost -= saucersAmount * saucer.spawnScoreCost;

            var asteroidsAmount = GetAsteroidsAmount(totalCost, asteroid.spawnScoreCost);

            return GetEntityArray(asteroidsAmount, saucersAmount);
        }


        private int GetSaucersAmount(int totalCost, int scoreCost, int maxSaucersPerWave)
        {
            var maxSaucers = Mathf.Min(maxSaucersPerWave, totalCost / scoreCost);

            return Random.Range(0, maxSaucers + 1);
        }

        private int GetAsteroidsAmount(int totalCost, int scoreCost)
        {
            return totalCost / scoreCost;
        }


        private IEntitySpawnProvider[] GetEntityArray(int asteroidsAmount, int saucersAmount)
        {
            var entityList = new List<IEntitySpawnProvider>();

            for (int i = 0; i < asteroidsAmount; i++)
                entityList.Add(asteroid);

            for (int i = 0; i < saucersAmount; i++)
                entityList.Add(saucer);

            return entityList.ToArray();
        }
    }
}