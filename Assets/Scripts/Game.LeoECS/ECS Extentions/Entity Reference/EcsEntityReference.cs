using System;
using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECS.Extentions
{
    public class EcsEntityReference : MonoBehaviour
    {
        public bool assigned => !_entity.IsNull() && _entity.IsAlive();
        public ref EcsEntity entity
        {
            get
            {
                if (_entity.IsNull()) Debug.LogWarning("Entity is not assigned!");
                return ref _entity;
            }
        }

        private EcsEntity _entity;


        public void Provide(in EcsEntity entity)
        {
            _entity = entity;
            Debug.LogWarningFormat("GameObject {0}, entity {1} provided", gameObject, entity);
        }
    }
}