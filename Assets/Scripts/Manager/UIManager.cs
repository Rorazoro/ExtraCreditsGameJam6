using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Managers {
    public class UIManager : SingletonBehaviour<UIManager> {

        [SerializeField]
        private GameObject levelUIPrefab = null;
        [SerializeField]
        private GameObject[] playerUIPrefabs = null;

        private GameObject LevelUI;
        private List<GameObject> ActivePlayerUI = new List<GameObject> ();

        public void SetupLevelUI () {
            LevelUI = Instantiate (levelUIPrefab);
        }

        public void SetupPlayerUI (int playerIndex) {
            GameObject playerUI = Instantiate (playerUIPrefabs[playerIndex]);
            playerUI.transform.SetParent (LevelUI.transform, false);
            ActivePlayerUI.Add (playerUI);
        }
    }
}