using System.Collections;
using System.Collections.Generic;
using Game.ECS.ScriptableObjects;
using UnityEngine;

namespace Game.ECS.SpawnProviders
{
    public class EdgesSpawnHandler : ISpawnPlacementProvider
    {
        private Bounds bounds;


        public EdgesSpawnHandler(Bounds bounds)
        {
            this.bounds = bounds;
        }


        public (Vector3, Vector2) GetPositionAndDirection()
        {
            var spawnPoint = GetRandomPoint();
            return (spawnPoint, GetRandomDirection(spawnPoint));
        }



        private Vector3 GetRandomPoint()
        {
            var circlePoint = Random.insideUnitCircle.normalized * bounds.size.magnitude;
            var randomPoint = bounds.ClosestPoint(circlePoint);

            randomPoint.z = 0;

            return randomPoint * 1.1f;
        }

        private Vector2 GetRandomDirection(Vector2 spawnPoint)
        {
            var circlePoint = Random.insideUnitCircle.normalized * bounds.extents.magnitude * 0.15f;
            return (circlePoint - spawnPoint).normalized;
        }
    }
}