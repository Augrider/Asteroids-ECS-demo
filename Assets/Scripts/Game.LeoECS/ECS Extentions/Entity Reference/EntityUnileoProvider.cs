using Voody.UniLeo;

namespace Game.ECS.Extentions
{
    [UnityEngine.RequireComponent(typeof(EcsEntityReference))]
    public class EntityUnileoProvider : MonoProvider<EntityComponent> { }
}