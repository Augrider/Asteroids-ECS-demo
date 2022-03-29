using Leopotam.Ecs;
using UnityEngine;

namespace Game.ECS.Extentions
{
    /// <summary>
    /// System which automatically removes components of provided type after timer hits 0
    /// </summary>
    /// <typeparam name="TTimerFlag"></typeparam>
    public sealed class TimerSystem<TTimerFlag> : IEcsRunSystem
        where TTimerFlag : struct
    {
        // auto-injected fields.
        private readonly EcsFilter<Timer<TTimerFlag>> _filter = null;

        void IEcsRunSystem.Run()
        {
            foreach (var i in _filter)
            {
                ref var timer = ref _filter.Get1(i);
                timer.timeLeftSec -= Time.fixedDeltaTime;

                if (timer.timeLeftSec <= 0)
                {
                    _filter.GetEntity(i).Del<Timer<TTimerFlag>>();
                }
            }
        }
    }
}