using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlantAudio : MonoBehaviour
{
    public GameObject player;

    [Range(0, 4)]
    public int growth;
    public int prevGrowth;
    public float max = 8;
    public FMODUnity.StudioEventEmitter grow;
    public FMODUnity.StudioEventEmitter burn;
    public FMODUnity.StudioEventEmitter cut;

    private Vector2 distance;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        //Distance
        distance = new Vector2(player.transform.position.x - gameObject.transform.position.x, player.transform.position.y - gameObject.transform.position.y);
        if (distance.x > 0)
        {
            grow.SetParameter("PlantPanning", Mathf.Clamp(distance.magnitude, 0, max)*-1/max);
        } else
        {
            grow.SetParameter("PlantPanning", Mathf.Clamp(distance.magnitude, 0, max)/max);
        }
        //Volume
        grow.SetParameter("PlantVolume", Mathf.Clamp(distance.magnitude, 0, max)/ max);

        //FMOD
        grow.SetParameter("PlantSize", growth);

        if (prevGrowth != growth)
        {
            if (prevGrowth < growth)
            {
                //Plant has grown
                Grow();
            } else if (prevGrowth > growth)
            {
                //Plant has been cut
                Cut();
            }
            prevGrowth = growth;
        } else
        {
            prevGrowth = growth;
        }
    }
    // Update is called once per frame
    public void Grow()
    {
        grow.Play();
    }
    public void Burn()
    {
        burn.Play();
    }
    public void Cut()
    {
        cut.Play();
    }
}
