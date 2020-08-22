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

    public float ReverbTime = 0;
    public float ReverbWet = 0;

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
        music.SetParameter("Volume", musicSlider.value);
        ambience.SetParameter("Volume", ambienceSlider.value);

        foreach(GameObject go in plants)
        {
            go.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("OverallVolume", SFXSlider.value);
        }
        player.GetComponentInChildren<CharacterAudio>().Volume = SFXSlider.value;

        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("ReverbTime", ReverbTime);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("ReverbWet", ReverbWet);
    }
}
