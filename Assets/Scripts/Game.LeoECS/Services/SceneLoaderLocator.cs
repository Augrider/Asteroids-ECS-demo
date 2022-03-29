namespace Game.ECS.Services
{
    public static class SceneLoaderLocator
    {
        private static ISceneLoader nullService { get; } = new NullSceneLoader();
        public static ISceneLoader service { get; private set; } = nullService;


        public static void Provide(ISceneLoader value)
        {
            service = value != null ? value : nullService;
        }
    }
}