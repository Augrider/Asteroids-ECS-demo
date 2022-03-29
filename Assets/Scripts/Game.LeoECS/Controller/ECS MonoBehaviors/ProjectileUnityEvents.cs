using System;
using System.Collections;
using System.Collections.Generic;
using Game.ECS.Components;
using Game.ECS.Services;
using Leopotam.Ecs;
using UnityEngine;

public class ProjectileUnityEvents : EntityUnityEvents
{
    private bool playerOwned;


    IEnumerator Start()
    {
        var entity = entityProvider.entity;

        if (ECSLocator.service.worldExists && entityProvider.assigned)
        {
            this.playerOwned = entity.Has<PlayerOwned>();
            yield break;
        }

        //Check if player owned;
        yield return new WaitWhile(() => !ECSLocator.service.worldExists || !entityProvider.assigned);

        entity = entityProvider.entity;
        this.playerOwned = entity.Has<PlayerOwned>();
    }


    protected override void OnEntityEnter(in EcsEntity other)
    {
        //Check if entity is enemy if playerOwned, else check if player
        bool isEnemy = CheckForEnemy(other);

        //If so, record hit
        if (!isEnemy)
            return;

        other.Get<DestroyComponent>();

        ref var entity = ref entityProvider.entity;

        //Destroy projectile if necessary
        if (entity.Has<DestroyOnHitComponent>())
            entity.Get<DestroyComponent>();
    }

    protected override void OnEntityStay(in EcsEntity other)
    {
        //Check if entity is enemy if playerOwned, else check if player
        bool isEnemy = CheckForEnemy(other);

        //If so, record hit
        if (!isEnemy)
            return;

        other.Get<DestroyComponent>();
    }



    private bool CheckForEnemy(EcsEntity other)
    {
        if (playerOwned)
            return other.Has<Enemy>();

        return other.Has<Player>();
    }
}
