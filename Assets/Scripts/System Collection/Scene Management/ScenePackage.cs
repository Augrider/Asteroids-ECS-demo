using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

namespace SceneManagementSystem
{
    /// <summary>
    /// Contains scene data collection and handles it's load/unload
    /// </summary>

    [CreateAssetMenu(fileName = "NewScenePackage", menuName = "Scene Package", order = 151)]
    public class ScenePackage : ScriptableObject
    {
        [SerializeField] private SceneData[] sceneReferences;


        public IEnumerator Load(Action doBeforeLoad = null, Action doAfterLoad = null)
        {
            if (sceneReferences.Length <= 0)
                throw new ArgumentNullException("No scenes found in package!");

            doBeforeLoad?.Invoke();
            yield return null;

            foreach (SceneData sceneData in sceneReferences)
                yield return sceneData.Load();

            doAfterLoad?.Invoke();
            yield return null;
        }

        public IEnumerator Unload(Action doBeforeUnload = null, Action doAfterUnload = null)
        {
            if (sceneReferences.Length <= 0)
                throw new ArgumentNullException("No scenes found in package!");

            doBeforeUnload?.Invoke();
            yield return null;

            foreach (SceneData sceneData in sceneReferences)
                yield return sceneData.Unload();

            doAfterUnload?.Invoke();
            yield return null;
        }



        private string GetName(SceneReference sceneRef)
        {
            string[] SceneSplittedName = sceneRef.ScenePath.Split('/');
            string SceneNameWithOutExtension = SceneSplittedName[SceneSplittedName.Length - 1].Split('.')[0];
            return SceneNameWithOutExtension;
        }
    }
}