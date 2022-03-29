using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.ECS.SpawnProviders;

public class SceneContext : MonoBehaviour, ISceneContext
{
    public ISpawnPlacementProvider spawnPlacement { get; private set; }

    public Transform projectilesParent => _projectilesParent;
    public Transform spaceEntitiesParent => _spaceEntitiesParent;

    public Bounds gameArea { get; private set; }

    public bool gameSessionInProgress { get; private set; } = false;


    [SerializeField] private Transform _projectilesParent;
    [SerializeField] private Transform _spaceEntitiesParent;

    [SerializeField] private RectTransform _floor;


    void Awake()
    {
        this.gameArea = new Bounds(_floor.position, _floor.rect.size);
        this.spawnPlacement = new EdgesSpawnHandler(gameArea);
    }


    public void ToggleGameSessionProgress(bool value) => this.gameSessionInProgress = value;
}