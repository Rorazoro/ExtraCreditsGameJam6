using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlantAudio : MonoBehaviour
{
    public GameObject player;

    [Range(0, 4)]
    public int growth;
    public float max = 8;
    private float nextGrowth;
    public FMODUnity.StudioEventEmitter grow;
    public FMODUnity.StudioEventEmitter burn;

    public float nextGrowthSpeed = 1f;

    private Vector2 distance;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        growth = 0;
        nextGrowth = 2;
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

        if (Time.time > nextGrowth && growth < 4)
        {
            nextGrowth = Time.time + nextGrowthSpeed;
            Grow();
            growth++;
        }
    }
    // Update is called once per frame
    void Grow()
    {
        if (growth != 0)
            grow.Play();
    }
    void Burn()
    {
        burn.Play();
    }
}
