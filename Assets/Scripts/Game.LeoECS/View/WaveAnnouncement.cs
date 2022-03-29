using System;
using UnityEngine;
using TMPro;
using ScriptableObjectsSystem.Variables;
using System.Collections.Generic;
using System.Collections;

namespace UIElements
{
    public class WaveAnnouncement : MonoBehaviour
    {
        [SerializeField] private GameObject parent;

        [SerializeField] private TextMeshProUGUI waveCount;
        [SerializeField] private IntVariable currentWave;

        [SerializeField] private float showTime = 1.5f;


        void OnEnable()
        {
            currentWave.valueChanged += UpdateWaveCount;
        }

        void OnDisable()
        {
            currentWave.valueChanged -= UpdateWaveCount;
        }



        private void UpdateWaveCount(int newValue)
        {
            if (newValue <= 0)
                return;

            var waveString = String.Join(" ", "Wave", newValue.ToString());
            waveCount.SetText(waveString);

            StopAllCoroutines();
            StartCoroutine(WaitAndHide());
        }


        private IEnumerator WaitAndHide()
        {
            parent.SetActive(true);

            yield return new WaitForSeconds(showTime);

            parent.SetActive(false);
        }
    }
}