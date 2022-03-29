using UnityEngine;
using Leopotam.Ecs;
using Game.ECS.Components;

namespace Game.ECS.Systems
{
    public class LoopEntitiesSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TransformComponent, SpeedComponent, InvisibleComponent>.Exclude<LifetimeComponent> _filterInvisible = null;

        private readonly ISceneContext _sceneContext = null;


        public void Run()
        {
            foreach (var i in _filterInvisible)
            {
                ref var transform = ref _filterInvisible.Get1(i).entityTransform;
                ref var speedComponent = ref _filterInvisible.Get2(i);

                Vector2 multiplier = GetAxisMultipliers(transform.position, speedComponent.speed);

                transform.position *= multiplier;
            }
        }



        private Vector2 GetAxisMultipliers(Vector3 position, Vector2 speed)
        {
            var invertX = _sceneContext.gameArea.extents.x < Mathf.Abs(position.x);
            var invertY = _sceneContext.gameArea.extents.y < Mathf.Abs(position.y);

            var directionX = Mathf.Sign(position.x * speed.x);
            var directionY = Mathf.Sign(position.y * speed.y);

            return new Vector2(invertX ? -directionX * 0.95f : 1, invertY ? -directionY * 0.95f : 1);
        }
    }
}