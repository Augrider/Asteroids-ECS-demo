using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.ECS.Services;
using ScriptableObjectsSystem.Variables;

public class PlayerUI : MonoBehaviour, IPlayerUIController
{
    [SerializeField] private Vector2Variable position;
    [SerializeField] private FloatVariable speed;
    [SerializeField] private FloatVariable angle;

    [SerializeField] private FloatVariable currentCharge;


    void Awake()
    {
        PlayerUILocator.Provide(this);
    }

    void OnDestroy()
    {
        PlayerUILocator.Provide(null);
    }


    public void UpdateLaserCharges(float value)
    {
        currentCharge.SetValue(value);
    }

    public void UpdatePlayerOrientation(Transform rotationTransform)
    {
        angle.SetValue(rotationTransform.eulerAngles.z);
    }

    public void UpdatePlayerPosition(Vector3 value)
    {
        position.SetValue(value);
    }

    public void UpdatePlayerSpeed(Vector2 value)
    {
        speed.SetValue(value.magnitude);
    }
}
