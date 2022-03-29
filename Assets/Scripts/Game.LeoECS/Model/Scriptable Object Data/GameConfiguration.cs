using System.Collections;
using System.Collections.Generic;
using ScriptableObjectsSystem.Variables;
using UnityEngine;

namespace Game.ECS.ScriptableObjects
{
    [CreateAssetMenu]
    public class GameConfiguration : ScriptableObject, IGameContext
    {
        [SerializeField] private float _timeBetweenWaves = 1;

        [SerializeField] private GameState _gameState;
        [SerializeField] private DifficultySettings gameSettings;
        [SerializeField] private PlayerControls playerControls;


        public float waveSpawnCooldown => _timeBetweenWaves;

        public IGameState gameState => _gameState;

        public IWaveProvider waveProvider => gameSettings;
        public IInputProvider playerInputs => playerControls;

        public IHighScoreHandler highScoreHandler => gameSettings;
    }
}