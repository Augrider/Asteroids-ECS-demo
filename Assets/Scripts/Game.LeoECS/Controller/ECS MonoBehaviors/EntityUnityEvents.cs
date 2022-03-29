using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.ECS.Services;
using Game.ECS.Extentions;
using Leopotam.Ecs;
using Game.ECS.Components;
using System;

public abstract class EntityUnityEvents : MonoBehaviour
{
    [SerializeField] protected EcsEntityReference entityProvider;


    protected void OnBecameInvisible()
    {
        if (!ECSLocator.service.worldExists || !entityProvider.assigned)
            return;

        Debug.LogWarningFormat("Invisible!");

        ref var entity = ref entityProvider.entity;
        entity.Get<InvisibleComponent>();
    }

    protected void OnBecameVisible()
    {
        if (!ECSLocator.service.worldExists || !entityProvider.assigned)
            return;

        ref var entity = ref entityProvider.entity;
        entity.Del<InvisibleComponent>();
    }


    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (!ECSLocator.service.worldExists || !entityProvider.assigned)
            return;

        if (!other.gameObject.TryGetComponent<EcsEntityReference>(out var otherEntityProvider))
            return;

        if (otherEntityProvider.assigned)
            OnEntityEnter(in otherEntityProvider.entity);

        // ref var entity = ref entityProvider.entity;
        // ref var collisionsComponent = ref entity.Get<CollisionsComponent>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!ECSLocator.service.worldExists || !entityProvider.assigned)
            return;

        if (!other.gameObject.TryGetComponent<EcsEntityReference>(out var otherEntityProvider))
            return;

        if (otherEntityProvider.assigned)
            OnEntityStay(in otherEntityProvider.entity);
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (!ECSLocator.service.worldExists || !entityProvider.assigned)
            return;

        if (!other.gameObject.TryGetComponent<EcsEntityReference>(out var otherEntityProvider))
            return;

        if (otherEntityProvider.assigned)
            OnEntityExit(in otherEntityProvider.entity);
    }


    protected virtual void OnEntityEnter(in EcsEntity other) { }
    protected virtual void OnEntityStay(in EcsEntity other) { }
    protected virtual void OnEntityExit(in EcsEntity other) { }
}
