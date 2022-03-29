namespace Game.ECS.Services
{
    internal class NullECSHandler : IECSHandler
    {
        public bool worldExists => false;

        public void AddEvent<T>() where T : struct { }
        public void AddEvent<T>(in T component) where T : struct { }
    }
}