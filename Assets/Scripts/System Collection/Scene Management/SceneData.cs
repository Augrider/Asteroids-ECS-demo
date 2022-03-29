using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagementSystem
{
    /// <summary>
    /// Contains reference to scene asset and handles it's load/unload
    /// </summary>

    [CreateAssetMenu(fileName = "NewSceneData", menuName = "Scene Data", order = 152)]
    public class SceneData : ScriptableObject
    {
        [SerializeField] private SceneReference sceneReference;


        public string GetSceneName()
        {
            string[] SceneSplittedName = sceneReference.ScenePath.Split('/');
            string SceneNameWithOutExtension = SceneSplittedName[SceneSplittedName.Length - 1].Split('.')[0];
            return SceneNameWithOutExtension;
        }


        public IEnumerator Load(Action doBeforeLoad = null, Action doAfterLoad = null)
        {
            if (sceneReference == null)
                throw new ArgumentNullException("Scene reference is empty!");

            doBeforeLoad?.Invoke();
            yield return null;

            var operation = SceneManager.LoadSceneAsync(GetSceneName(), LoadSceneMode.Additive);
            while (!operation.isDone)
                yield return null;

            doAfterLoad?.Invoke();
            yield return null;
        }

        public IEnumerator Unload(Action doBeforeUnload = null, Action doAfterUnload = null)
        {
            if (sceneReference == null)
                throw new ArgumentNullException("Scene reference is empty!");

            doBeforeUnload?.Invoke();
            yield return null;

            var scene = SceneManager.GetSceneByPath(sceneReference.ScenePath);

            if (scene.IsValid() && scene.isLoaded)
            {
                var operation = SceneManager.UnloadSceneAsync(scene);

                while (!operation.isDone)
                    yield return null;
            }

            doAfterUnload?.Invoke();
            yield return null;
        }
    }
}