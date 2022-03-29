using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectsSystem.Variables;
using TMPro;

namespace UIElements
{
    public class CharacterState : MonoBehaviour
    {
        [SerializeField] private Vector2Variable position;
        [SerializeField] private FloatVariable rotation;
        [SerializeField] private FloatVariable speed;

        [SerializeField] private TextMeshProUGUI positionText;
        [SerializeField] private TextMeshProUGUI rotationText;
        [SerializeField] private TextMeshProUGUI speedText;


        void OnEnable()
        {
            position.valueChanged += SetPositionText;
            rotation.valueChanged += SetRotationText;
            speed.valueChanged += SetSpeedText;
        }

        void OnDisable()
        {
            position.valueChanged -= SetPositionText;
            rotation.valueChanged -= SetRotationText;
            speed.valueChanged -= SetSpeedText;
        }



        private void SetPositionText(Vector2 value) => positionText.SetText(value.ToString("F0"));
        private void SetRotationText(float value) => rotationText.SetText(value.ToString("F2"));
        private void SetSpeedText(float value) => speedText.SetText(value.ToString("F2"));
    }
}