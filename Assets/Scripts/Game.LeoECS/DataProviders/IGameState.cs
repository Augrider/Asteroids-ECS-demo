using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameState
{
    int currentWave { get; }
    int currentScore { get; }

    void AddScore(int value);
    void AddWave();

    void Reset();
}