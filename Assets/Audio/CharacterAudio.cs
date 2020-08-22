using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAudio : MonoBehaviour
{
    [Range(0, 1)]
    public float Volume = 0;

    public GameObject character;
    public GameObject footsteps;
    public GameObject footstepsLow;
    public GameObject cut;

    public float footstepsSpeed = 0.5f;
    [Range(0, 1)]
    public float Grass_or_Stone = 0;

    private float nextFootstep;
    public int feet = 0;

    private void Awake()
    {
        nextFootstep = 0;
    }
    //Functions
    private void Update()
    {
        footsteps.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("FootstepVolume", Volume);
        footstepsLow.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("FootstepVolume", Volume);
        cut.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("CutVolume", Volume);
        footsteps.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("Grass_Stone", Grass_or_Stone);
        footstepsLow.GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("Grass_Stone", Grass_or_Stone);

    }
    //Sounds
    public void FootStep()
    {
        if (Time.time > nextFootstep)
        {
            nextFootstep = Time.time + footstepsSpeed;
            if(feet == 0)
            {
                footsteps.GetComponent<FMODUnity.StudioEventEmitter>().Play();
                feet = 1;
            } else
            {
                footstepsLow.GetComponent<FMODUnity.StudioEventEmitter>().Play();
                feet = 0;
            }
        }
    }
    public void Cut()
    {
        cut.GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }
}
