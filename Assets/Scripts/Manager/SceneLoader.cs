using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Managers {
    public class SceneLoader : SingletonBehaviour<SceneLoader> {

        [SerializeField]
        private bool isSceneLoaded = false;
        [SerializeField]
        private string currentScene;
        private Scenes startScene = Scenes.MainMenu;

        public bool IsSceneLoaded { get => isSceneLoaded; }
        public string CurrentScene { get => currentScene; }

        private void Start () {
            startScene = Application.isEditor ? DebugManager.Instance.DebugScene : Scenes.MainMenu;

            if (startScene != Scenes.Preload) {
                UnloadAllScenesExcept (Scenes.Preload);
                Action doAfter = null;

                LoadScene (startScene, 3f, doAfter);
            }
        }

        private void UnloadAllScenesExcept (Scenes sceneEnum) {
            int c = SceneManager.sceneCount;
            for (int i = 0; i < c; i++) {
                Scene scene = SceneManager.GetSceneAt (i);
                if (scene.name != sceneEnum.ToString ()) {
                    SceneManager.UnloadSceneAsync (scene);
                }
            }
        }

        public void LoadScene (Scenes sceneEnum, float waitTime, Action doAfter) {
            LoadScene (sceneEnum.ToString (), waitTime, doAfter);
        }

        public void LoadScene (string sceneName, float waitTime, Action doAfter) {
            StartCoroutine (LoadSceneRoutine (sceneName, waitTime, doAfter));
        }

        public IEnumerator LoadSceneRoutine (string sceneName, float waitTime, Action doAfter) {
            isSceneLoaded = false;

            //SceneManager.LoadScene (Scenes.Loading.ToString ());
            yield return new WaitForSeconds (waitTime);

            AsyncOperation asyncSceneLoad = SceneManager.LoadSceneAsync (sceneName);
            while (!asyncSceneLoad.isDone) {
                yield return new WaitForSeconds (0.1f);
            }

            SceneManager.SetActiveScene (SceneManager.GetSceneByName (sceneName));
            isSceneLoaded = true;
            currentScene = sceneName;

            if (doAfter != null) {
                doAfter ();
            }
        }

        public void QuitGame () {
            Debug.Log ("QUIT!!!");
            Application.Quit ();
        }
    }
}