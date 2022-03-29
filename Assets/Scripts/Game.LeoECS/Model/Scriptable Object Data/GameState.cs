using System.Collections;
using System.Collections.Generic;
using ScriptableObjectsSystem.Variables;
using UnityEngine;

namespace Game.ECS.ScriptableObjects
{
    [CreateAssetMenu]
    public class GameState : ScriptableObject, IGameState
    {
        [SerializeField] private IntVariable _currentScore;
        [SerializeField] private IntVariable _currentWave;

        public int currentScore => _currentScore.runtimeValue;
        public int currentWave => _currentWave.runtimeValue;


        void Awake()
        {
            Reset();
        }


        public void AddScore(int value) => _currentScore.AddValue(value);
        public void AddWave() => _currentWave.AddValue(1);

        public void Reset()
        {
            _currentScore.SetValue(0);
            _currentWave.SetValue(0);
        }
    }
}