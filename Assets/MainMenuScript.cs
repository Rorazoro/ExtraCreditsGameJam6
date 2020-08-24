using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject SettingsMenu;
    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {

    }
    public void SettingsButton()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }
    public void ExitSettingsButton()
    {
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }
    public void ExitButton()
    {

    }
}
