using System.Collections;
using System.Collections.Generic;
using Assets.Managers;
using UnityEngine;

public class MainMenuUI : MonoBehaviour {
    public void PlayGame () {
        SceneLoader.Instance.LoadScene (Scenes.Prototype2, 1f, null);
    }
}