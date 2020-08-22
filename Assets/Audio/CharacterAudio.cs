using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAudio : MonoBehaviour
{
    public bool hitPlayer = false;

    [Range(0, 1)]
    public float Volume = 0;

    public GameObject character;
    public GameObject footsteps;
    public GameObject footstepsLow;
    public GameObject cut;
    public GameObject hit;

    [Range(0, 1)]
    public float Grass_or_Stone = 0;

    //Functions
    private void Update()
    {
        //SFX Volume
        footsteps.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("FootstepVolume", Volume);
        footstepsLow.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("FootstepVolume", Volume);
        cut.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("CutVolume", Volume);
        hit.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("HitVolume", Volume);

        //Grass or Stone
        footsteps.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("Grass_Stone", Grass_or_Stone);
        footstepsLow.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("Grass_Stone", Grass_or_Stone);

        if (hitPlayer)
        {
            hitPlayer = false;
            hit.GetComponent<FMODUnity.StudioEventEmitter>().Play();
        }
    }
    //Sounds
    public void FootStep()
    {
        footsteps.GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }
    public void FootStepLow()
    {
        footsteps.GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }
    public void Cut()
    {
        cut.GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }
}
