using System.Collections;
using System.Collections.Generic;
using SaveDataSystem;
using UnityEngine;

public interface IHighScoreHandler
{
    IHighScoreSaveHandler scoreSaveHandler { get; set; }


    (int, int) GetHighScore();
    void CheckForHighScore(int currentScore, int currentWave);
}