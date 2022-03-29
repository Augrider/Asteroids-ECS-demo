namespace Game.ECS.Services
{
    public static class ECSLocator
    {
        public static IECSHandler service { get; private set; } = nullService;
        private static IECSHandler nullService { get; } = new NullECSHandler();


        public static void Provide(IECSHandler value)
        {
            service = value != null ? value : nullService;
        }
    }
}