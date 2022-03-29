using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnPlacementProvider
{
    (Vector3, Vector2) GetPositionAndDirection();
}