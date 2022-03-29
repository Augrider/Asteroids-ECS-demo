using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.ECS.Services;
using SceneManagementSystem;

public class GameSceneLoader : SceneLoader, ISceneLoader
{
    private enum SceneState { MainMenu, Game, GameOver }

    private SceneState state;

    [SerializeField] private GameObject loadingScreen;

    [SerializeField] private ScenePackage mainMenu;
    [SerializeField] private ScenePackage gameScenes;

    [SerializeField] private SceneData gameUI;
    [SerializeField] private SceneData gameOver;


    protected override void Awake()
    {
        base.Awake();

        SceneLoaderLocator.Provide(this);

        this.state = SceneState.Game;
        ToMainMenu();
    }

    void OnDestroy()
    {
        SceneLoaderLocator.Provide(null);
    }


    public void ToMainMenu()
    {
        if (state == SceneState.MainMenu)
            return;

        state = SceneState.MainMenu;

        ShowLoadingScreen();
        UnloadAll();

        LoadFromScenePackage(mainMenu, doAfterLoad: HideLoadingScreen);
    }

    public void ToGame()
    {
        if (state == SceneState.Game)
            return;

        state = SceneState.Game;

        ShowLoadingScreen();
        UnloadAll();

        LoadFromScenePackage(gameScenes, doAfterLoad: HideLoadingScreen);
    }

    public void ToGameOver()
    {
        if (state == SceneState.GameOver)
            return;

        state = SceneState.GameOver;

        StartCoroutine(WaitForShowGameOverScreen());
    }


    protected override void ShowLoadingScreen()
    {
        loadingScreen.SetActive(true);
    }

    protected override void HideLoadingScreen()
    {
        loadingScreen.SetActive(false);
    }



    private IEnumerator WaitForShowGameOverScreen()
    {
        yield return UnloadFromSceneData(gameUI);
        yield return LoadFromSceneData(gameOver);
    }
}
