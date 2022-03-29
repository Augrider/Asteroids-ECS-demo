using System.Collections;
using System.Collections.Generic;
using Game.ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

public class PlayerUnityEvents : EntityUnityEvents
{
    protected override void OnEntityEnter(in EcsEntity other)
    {
        var entity = entityProvider.entity;
        var isPlayer = entity.Has<Player>();

        bool isEnemy = CheckForEnemy(other, isPlayer);

        if (isEnemy)
            entity.Get<DestroyComponent>();
    }



    private bool CheckForEnemy(EcsEntity other, bool isPlayer)
    {
        if (isPlayer)
            return other.Has<Enemy>();

        return other.Has<Player>();
    }
}