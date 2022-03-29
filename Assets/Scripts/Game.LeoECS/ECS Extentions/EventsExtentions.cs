using Leopotam.Ecs;

public static class EventsExtentions
{
    public static EcsEntity AddEvent<T>(this EcsWorld world) where T : struct
    {
        var entity = world.NewEntity();
        entity.Get<T>();

        return entity;
    }

    public static EcsEntity AddEvent<T>(this EcsWorld world, in T component) where T : struct
    {
        var entity = world.NewEntity();
        entity.Replace(in component);

        return entity;
    }
}