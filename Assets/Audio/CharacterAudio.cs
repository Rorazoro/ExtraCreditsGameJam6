using System.Collections;
using System.Collections.Generic;
using Assets.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAudio : MonoBehaviour
{
    private PlayerInput playerInput = null;
    private IInputHandler playerInputHandler = null;

    public GameObject character;
    public GameObject footsteps;
    public GameObject cut;

    public float footstepsSpeed = 0.5f;
    private Vector2 prevPos;
    private Vector2 currentPos;
    private float nextFootstep;

    private void Awake()
    {
        playerInput = character.GetComponent<PlayerInput>();
        playerInputHandler = new PlayerInputHandler(playerInput);
    }
    void FixedUpdate()
    {
        //Footstep Cooldown
        FootStep();
    }

    //Sounds
    public void FootStep()
    {
        currentPos = character.transform.position;
        if (prevPos != currentPos)
        {
            if (Time.time > nextFootstep)
            {
                nextFootstep = Time.time + footstepsSpeed;
                footsteps.GetComponent<FMODUnity.StudioEventEmitter>().Play(); ;
            }
        }
        prevPos = currentPos;
    }
    public void Cut()
    {
        cut.GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }
}
