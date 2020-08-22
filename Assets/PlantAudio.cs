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
    public FMODUnity.StudioEventEmitter fmod;

    public float nextGrowthSpeed = 1f;

    private Vector2 distance;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        fmod = GetComponent<FMODUnity.StudioEventEmitter>();
        growth = 0;
        nextGrowth = 2;
    }
    private void Update()
    {
        //Distance
        distance = new Vector2(player.transform.position.x - gameObject.transform.position.x, player.transform.position.y - gameObject.transform.position.y);
        if (distance.x > 0)
        {
            fmod.SetParameter("PlantPanning", Mathf.Clamp(distance.magnitude, 0, max)*-1/max);
        } else
        {
            fmod.SetParameter("PlantPanning", Mathf.Clamp(distance.magnitude, 0, max)/max);
        }
        //Volume
        fmod.SetParameter("PlantVolume", Mathf.Clamp(distance.magnitude, 0, max)/ max);

        //FMOD
        fmod.SetParameter("PlantSize", growth);

        if (Time.time > nextGrowth && growth < 4)
        {
            nextGrowth = Time.time + nextGrowthSpeed;
            Grow();
            Debug.Log("Grow Plant!");
            growth++;
        }
    }
    // Update is called once per frame
    void Grow()
    {
        if (growth != 0)
            fmod.Play();
    }
}
