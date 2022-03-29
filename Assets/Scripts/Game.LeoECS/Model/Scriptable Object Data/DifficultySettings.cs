using System;
using System.Collections;
using System.Collections.Generic;
using SaveDataSystem;
using UnityEngine;

namespace Game.ECS.ScriptableObjects
{
    /// <summary>
    /// Base class for storing high score and getting entities for waves
    /// </summary>
    public abstract class DifficultySettings : ScriptableObject, IWaveProvider, IHighScoreHandler
    {
        public int highScore { get; private set; }
        public int highestWave { get; private set; }

        public IHighScoreSaveHandler scoreSaveHandler { get; set; }


        public (int, int) GetHighScore()
        {
            if (highestWave == 0 && scoreSaveHandler != null)
                LoadHighScore();

            return (highScore, highestWave);
        }

        public void CheckForHighScore(int highScore, int highestWave)
        {
            SaveHighScore(highScore, highestWave);
        }



        private void LoadHighScore()
        {
            (highScore, highestWave) = scoreSaveHandler.Load(this.name);
        }

        private void SaveHighScore(int highScore, int highestWave)
        {
            if (this.highScore < highScore)
                this.highScore = highScore;

            if (this.highestWave < highestWave)
                this.highestWave = highestWave;

            scoreSaveHandler?.Save(this.name, highScore, highestWave);
        }


        public abstract IEntitySpawnProvider[] GetEntitiesToSpawn(int waveCount);
    }
}