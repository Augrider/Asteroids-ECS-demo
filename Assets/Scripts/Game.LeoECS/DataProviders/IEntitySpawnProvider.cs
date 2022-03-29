using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntitySpawnProvider
{
    GameObject GetNewEntity(ISceneContext sceneContext, Vector3 position, Vector2 direction);
}