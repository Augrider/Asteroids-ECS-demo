using UnityEngine;

namespace Game.ECS.Services
{
    internal class NullPlayerUI : IPlayerUIController
    {
        public void UpdateLaserCharges(float currentCharge) { }

        public void UpdatePlayerOrientation(Transform rotationTransform) { }
        public void UpdatePlayerPosition(Vector3 value) { }
        public void UpdatePlayerSpeed(Vector2 value) { }
    }
}