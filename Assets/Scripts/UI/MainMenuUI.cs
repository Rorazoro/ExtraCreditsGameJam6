using System.Collections;
using System.Collections.Generic;
using Assets.Managers;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject SettingsMenu;

    public Slider ambienceSlider;
    public Slider musicSlider;
    public Slider SFXSlider;

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
        ambienceSlider.value = PlayerPrefs.GetFloat ("AmbVol", 1);
        musicSlider.value = PlayerPrefs.GetFloat ("MVol", 1);
        SFXSlider.value = PlayerPrefs.GetFloat ("SFXVol", 1);
    }

    public void ExitSettingsButton () {
        MainMenu.SetActive (true);
        SettingsMenu.SetActive (false);
    }

    public void OnMusicChange (float value) {
        //GameAudio.Instance.musicVolume = value;
        PlayerPrefs.SetFloat ("MVol", value);
    }

    public void OnAmbienceChange (float value) {
        //GameAudio.Instance.ambienceVolume = value;
        PlayerPrefs.SetFloat ("AmbVol", value);
    }

    public void OnSFXChange (float value) {
        //GameAudio.Instance.sfxVolume = value;
        PlayerPrefs.SetFloat ("SFXVol", value);
    }

    public void ExitButton () {

#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
        Debug.Log (this.name + " : " + this.GetType () + " : " + System.Reflection.MethodBase.GetCurrentMethod ().Name);
#endif
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE) 
        Application.Quit ();
#elif (UNITY_WEBGL)
        Application.OpenURL ("about:blank");
#endif

    }
}