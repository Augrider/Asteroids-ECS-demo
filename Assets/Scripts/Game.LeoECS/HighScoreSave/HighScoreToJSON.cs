using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveDataSystem
{
    public class HighScoreToJSON : IHighScoreSaveHandler
    {
        public (int highScore, int highestWave) Load(string difficultyName)
        {
            var dataString = "";
            var filePath = GetFilePath(difficultyName);

            if (System.IO.File.Exists(filePath))
                dataString = System.IO.File.ReadAllText(filePath);

            if (string.IsNullOrEmpty(dataString))
                return (0, 1);

            var highScoreData = JsonUtility.FromJson<HighScoreData>(dataString);
            return (highScoreData.highScore, highScoreData.highestWave);
        }

        public void Save(string difficultyName, int highScore, int highestWave)
        {
            var dataString = JsonUtility.ToJson(new HighScoreData(highScore, highestWave));
            var filePath = GetFilePath(difficultyName);

            System.IO.File.WriteAllText(filePath, dataString);
        }



        private string GetFileName(string difficultyName)
        {
            return difficultyName + "HighScore.json";
        }

        private string GetFilePath(string difficultyName)
        {
            return System.IO.Path.Combine(Application.persistentDataPath, GetFileName(difficultyName));
        }


        [Serializable]
        private struct HighScoreData
        {
            public int highScore;
            public int highestWave;


            public HighScoreData(int highScore, int highestWave)
            {
                this.highScore = highScore;
                this.highestWave = highestWave;
            }
        }
    }
}