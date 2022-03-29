using UnityEngine;
using TMPro;
using ScriptableObjectsSystem.Variables;

namespace UIElements
{
    public class GameStateUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI waveCount;
        [SerializeField] private TextMeshProUGUI scoreCount;

        [SerializeField] private IntVariable currentWave;
        [SerializeField] private IntVariable currentScore;


        void OnEnable()
        {
            currentWave.valueChanged += UpdateWaveCount;
            currentScore.valueChanged += UpdateScore;
        }

        void OnDisable()
        {
            currentWave.valueChanged -= UpdateWaveCount;
            currentScore.valueChanged -= UpdateScore;
        }



        private void UpdateWaveCount(int newValue) => waveCount.SetText(newValue.ToString());
        private void UpdateScore(int newValue) => scoreCount.SetText(newValue.ToString("D6"));
    }
}