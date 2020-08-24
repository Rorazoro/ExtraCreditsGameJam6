using System.Collections;
using System.Collections.Generic;
using Assets.Managers;
using UnityEngine;

public class MainMenuUI : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject SettingsMenu;
    // Start is called before the first frame update
    void Start () {
        MainMenu.SetActive (true);
        SettingsMenu.SetActive (false);
    }

    public void PlayButton () {
        SceneLoader.Instance.LoadScene (Scenes.Prototype2, 1f, null);
    }

    public void SettingsButton () {
        MainMenu.SetActive (false);
        SettingsMenu.SetActive (true);
    }

    public void ExitSettingsButton () {
        MainMenu.SetActive (true);
        SettingsMenu.SetActive (false);
    }

    public void ExitButton () {

    }
}