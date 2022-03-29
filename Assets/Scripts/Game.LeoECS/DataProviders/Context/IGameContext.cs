using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameContext
{
    float waveSpawnCooldown { get; }

    IWaveProvider waveProvider { get; }
    IInputProvider playerInputs { get; }

    IGameState gameState { get; }
    IHighScoreHandler highScoreHandler { get; }
}