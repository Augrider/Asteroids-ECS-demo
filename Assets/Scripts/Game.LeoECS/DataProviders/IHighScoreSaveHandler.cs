using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveDataSystem
{
    public interface IHighScoreSaveHandler
    {
        /// <summary>
        /// Save high score
        /// </summary>
        void Save(string difficultyName, int highScore, int highestWave);

        /// <summary>
        /// Load high score
        /// </summary>
        (int highScore, int highestWave) Load(string difficultyName);
    }
}