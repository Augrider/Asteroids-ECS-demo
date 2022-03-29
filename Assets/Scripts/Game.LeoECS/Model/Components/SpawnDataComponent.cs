namespace Game.ECS.Components
{
    [System.Serializable]
    public struct SpawnDataComponent
    {
        public float speed;
        public float rotationSpeed;

        public bool randomizeSpeed;
        public bool randomizeRotationSpeed;

        public float speedDelta;
        public float rotationSpeedDelta;
    }
}