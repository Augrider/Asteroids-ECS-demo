using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.ECS.Services;

namespace Game.ECS.View
{
    public class ButtonEvents : MonoBehaviour
    {
        public void StartGame() => SceneLoaderLocator.service.ToGame();
        public void Restart() => SceneLoaderLocator.service.ToGame();
        public void ToMainMenu() => SceneLoaderLocator.service.ToMainMenu();
        public void Quit() => Application.Quit();
    }
}