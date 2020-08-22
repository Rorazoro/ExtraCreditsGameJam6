using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour
{

    public GameObject character;
    public GameObject footsteps;
    public GameObject cut;

    public float footstepsSpeed = 0.5f;
    private Vector2 prevPos;
    private Vector2 currentPos;
    private float nextFootstep;

    void FixedUpdate()
    {
        currentPos = character.transform.position;
        if (prevPos != currentPos)
        {
            if (Time.time > nextFootstep)
            {
                nextFootstep = Time.time + footstepsSpeed;
                footsteps.GetComponent<FMODUnity.StudioEventEmitter>().Play();
            }
        }
        Debug.Log(character.transform.position);
        prevPos = currentPos;
    }
}
