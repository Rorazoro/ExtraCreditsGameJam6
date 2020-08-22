using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{

    public GameObject character;
    public GameObject footsteps;
    public GameObject cut;

    public float footstepsSpeed = 0.5f;

    void FixedUpdate()
    {
        //If its moving, iniciate a sort of "cooldown" timer for the footstep SFX.
        /*
        if (Moving)
        {
            //Cooldown timer
            footsteps.GetComponent<FMODUnity.StudioEventEmitter>().Play();
        } else
        {
            footsteps.GetComponent<FMODUnity.StudioEventEmitter>().Stop();
        }
        */
    }
}
