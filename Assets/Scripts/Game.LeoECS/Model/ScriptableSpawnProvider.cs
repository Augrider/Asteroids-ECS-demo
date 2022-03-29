using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableSpawnProvider : ScriptableObject, IEntitySpawnProvider
{
    [SerializeField] private GameObject prefab;


    public GameObject GetNewEntity(ISceneContext sceneContext, Vector3 position, Vector2 direction)
    {
        var entityObject = Instantiate(prefab, GetParentTransform(sceneContext));

        entityObject.transform.localPosition = position;
        entityObject.transform.up = direction;

        return entityObject;
    }



    protected virtual Transform GetParentTransform(ISceneContext sceneContext) => sceneContext.spaceEntitiesParent;
}