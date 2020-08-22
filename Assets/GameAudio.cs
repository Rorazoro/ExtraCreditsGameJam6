using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAudio : MonoBehaviour
{
    public Slider ambienceSlider;
    public Slider musicSlider;
    public Slider SFXSlider;

    public FMODUnity.StudioEventEmitter ambience;
    public FMODUnity.StudioEventEmitter music;

    private GameObject player;
    private GameObject[] plants;

    [Range(0,1)]
    public float ReverbTime = 0;
    [Range(0, 1)]
    public float ReverbWet = 0;

    public float ambienceVolume;
    public float musicVolume;
    public float sfxVolume;

    // Start is called before the first frame update
    void Awake()
    {
        ambience.Play();
        music.Play();

        player = GameObject.FindWithTag("Player");
        plants = GameObject.FindGameObjectsWithTag("Plant");
    }

    // Update is called once per frame
    void Update()
    {
        musicVolume = musicSlider.value;
        ambienceVolume = ambienceSlider.value;
        sfxVolume = SFXSlider.value;

        music.SetParameter("Volume", musicVolume);
        ambience.SetParameter("Volume", ambienceVolume);

        foreach(GameObject go in plants)
        {
            go.GetComponent<PlantAudio>().grow.SetParameter("OverallVolume", sfxVolume);
            go.GetComponent<PlantAudio>().burn.SetParameter("OverallVolume", sfxVolume);

        }
        player.GetComponentInChildren<CharacterAudio>().Volume = sfxVolume;

        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("ReverbTime", ReverbTime);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("ReverbWet", ReverbWet);
    }
}
