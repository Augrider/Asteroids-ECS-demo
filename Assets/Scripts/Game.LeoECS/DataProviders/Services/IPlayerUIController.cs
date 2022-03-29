using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

public interface IPlayerUIController
{
    void UpdatePlayerPosition(Vector3 value);
    void UpdatePlayerSpeed(Vector2 value);
    void UpdatePlayerOrientation(Transform rotationTransform);

    void UpdateLaserCharges(float currentCharge);
}