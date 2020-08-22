using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAudio : MonoBehaviour
{

    public GameObject character;
    public GameObject footsteps;
    public GameObject cut;

    public float footstepsSpeed = 0.5f;
    private float nextFootstep;

    private void Awake()
    {
        nextFootstep = 0;
    }
    //Functions

    //Sounds
    public void FootStep()
    {
        if (Time.time > nextFootstep)
        {
            nextFootstep = Time.time + footstepsSpeed;
            footsteps.GetComponent<FMODUnity.StudioEventEmitter>().Play();
        }
    }
    public void Cut()
    {
        cut.GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }
}
