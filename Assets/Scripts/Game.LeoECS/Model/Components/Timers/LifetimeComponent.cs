namespace Game.ECS.Components
{
    [System.Serializable]
    public struct LifetimeComponent
    {
        public float lifetimeSec;

        /// <summary>
        /// Set true if timer added to entity
        /// </summary>
        public bool timerStarted;
    }
}