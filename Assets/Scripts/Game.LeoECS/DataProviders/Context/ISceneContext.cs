using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneContext
{
    ISpawnPlacementProvider spawnPlacement { get; }
    Bounds gameArea { get; }

    Transform projectilesParent { get; }
    Transform spaceEntitiesParent { get; }

    bool gameSessionInProgress { get; }

    void ToggleGameSessionProgress(bool value);
}