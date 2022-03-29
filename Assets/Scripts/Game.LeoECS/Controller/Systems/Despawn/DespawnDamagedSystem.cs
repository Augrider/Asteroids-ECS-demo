using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;

namespace Game.ECS.Systems
{
    public class DespawnDamagedSystem : IEcsRunSystem
    {
        private readonly EcsFilter<DestroyComponent> _filterDestroyed = null;


        public void Run()
        {
            foreach (var i in _filterDestroyed)
            {
                ref var entity = ref _filterDestroyed.GetEntity(i);
                ref var destroy = ref _filterDestroyed.Get1(i);

                if (entity.Has<TransformComponent>())
                {
                    ref var transform = ref entity.Get<TransformComponent>().entityTransform;
                    GameObject.Destroy(transform.gameObject);
                }

                Debug.LogWarningFormat("Entity {0} destroyed", entity);
                entity.Destroy();
            }
        }
    }
}