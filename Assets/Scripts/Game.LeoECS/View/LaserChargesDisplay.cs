using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectsSystem.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.ECS.View
{
    public class LaserChargesDisplay : MonoBehaviour
    {
        [SerializeField] private Game.ECS.ScriptableObjects.WeaponData weaponData;

        [SerializeField] private FloatVariable weaponChargeState;
        private int maxCharges => weaponData.maxCharges;
        private int chargesLeft => Mathf.FloorToInt(weaponChargeState);
        private float timeForFullRecharge => (maxCharges - weaponChargeState.runtimeValue) * weaponData.fullChargeCooldown;

        [SerializeField] private TextMeshProUGUI chargesCount;
        [SerializeField] private TextMeshProUGUI timeForFullRechargeText;
        [SerializeField] private Slider[] sliderBars;


        void OnEnable()
        {
            weaponChargeState.valueChanged += OnChargesChanged;
            OnChargesChanged(weaponChargeState.runtimeValue);
        }

        void OnDisable()
        {
            weaponChargeState.valueChanged -= OnChargesChanged;
        }



        private void OnChargesChanged(float value)
        {
            chargesCount.SetText(chargesLeft.ToString());
            timeForFullRechargeText?.SetText(timeForFullRecharge.ToString("F2") + " s");

            FillBars(value);
        }


        private void FillBars(float value)
        {
            for (int i = 0; i < sliderBars.Length; i++)
            {
                if (i < chargesLeft)
                    sliderBars[i].SetValueWithoutNotify(1);

                if (i > chargesLeft)
                    sliderBars[i].SetValueWithoutNotify(0);

                sliderBars[i].SetValueWithoutNotify(value - i);
            }
        }
    }
}