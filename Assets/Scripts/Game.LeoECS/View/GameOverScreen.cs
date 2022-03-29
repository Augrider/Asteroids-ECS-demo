using System;
using System.Collections;
using System.Collections.Generic;
using Game.ECS.ScriptableObjects;
using ScriptableObjectsSystem.Variables;
using TMPro;
using UnityEngine;

namespace Game.ECS.View
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private GameConfiguration gameConfiguration;
        private IGameContext gameContext => gameConfiguration;

        [SerializeField] private TextMeshProUGUI scoreCount;
        [SerializeField] private TextMeshProUGUI waveCount;
        [SerializeField] private TextMeshProUGUI highScoreText;


        void Start()
        {
            HandleHighScore();
            SetText();
        }



        private void HandleHighScore()
        {
            gameContext.highScoreHandler.scoreSaveHandler = new SaveDataSystem.HighScoreToJSON();
            gameContext.highScoreHandler.CheckForHighScore(gameContext.gameState.currentScore, gameContext.gameState.currentWave);
        }


        private void SetText()
        {
            scoreCount.SetText("Score " + gameContext.gameState.currentScore.ToString("D6"));
            waveCount.SetText("Wave " + gameContext.gameState.currentWave.ToString());

            (var highScore, var highestWave) = gameContext.highScoreHandler.GetHighScore();
            highScoreText.SetText("Highscore " + highScore.ToString("D6") + " (" + highestWave.ToString() + ")");
        }
    }
}