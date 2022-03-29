namespace Game.ECS.Services
{
    public static class PlayerUILocator
    {
        private static IPlayerUIController nullService { get; } = new NullPlayerUI();
        public static IPlayerUIController service { get; private set; } = nullService;


        public static void Provide(IPlayerUIController value)
        {
            service = value != null ? value : nullService;
        }
    }
}