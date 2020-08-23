using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Interfaces;
using Assets.Managers;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plant : MonoBehaviour, IInteractable {

    public PlantScriptableObject plantData;
    public DateTime growthTime;
    public int stage;
    public bool isSuperPlant;
    public List<Plant> neighbours = new List<Plant> ();
    public BoxCollider2D col2d;
    private SpriteRenderer spriteRenderer;
    private Color[] stageColors;

    //Audio
    public PlantAudio pAudio;


    private void Awake () {
        pAudio = GetComponent<PlantAudio>();
        spriteRenderer = GetComponent<SpriteRenderer> ();
        growthTime = new DateTime ();
        col2d.enabled = false;

        stageColors = new Color[4];
        stageColors[0] = Color.gray;
        stageColors[1] = Color.green;
        stageColors[2] = Color.yellow;
        stageColors[3] = Color.red;

        if (isSuperPlant) {
            InitializePlant (3);
        }
        FindNeighbours ();

        pAudio.growth = stage + 1;
        pAudio.prevGrowth = stage + 1;
    }

    private void Update () {
        if (stage > 0 && growthTime <= DateTime.Now) {
            col2d.enabled = true;
            GrowPlant ();
        }

        //Match Growth with audio
        pAudio.growth = stage + 1;
    }

    public void InitializePlant (int initStage) {
        plantData.health = plantData.maxHealth;
        growthTime = DateTime.Now.AddSeconds (plantData.baseGrowthTime);
        stage = initStage;
        spriteRenderer.color = stageColors[stage];
    }

    public void DoInteraction () {
        plantData.health--;
        if (plantData.health == 0) {
            CutPlant ();
        }
    }

    public void GrowPlant () {
        if (stage == 3) {
            SpreadPlants ();
        } else {
            stage++;
            spriteRenderer.color = stageColors[stage];
        }
        growthTime = DateTime.Now.AddSeconds (PlantManager.Instance.baseGrowthTime);
    }

    public void CutPlant () {
        Debug.Log ($"Plant Cut!");
        growthTime = DateTime.MaxValue;
        stage = 0;
        col2d.enabled = false;
        spriteRenderer.color = stageColors[stage];

        if (isSuperPlant) {
            InitializePlant (0);
        }
    }

    public void SpreadPlants () {
        List<Plant> newPlants = neighbours.Where (p => p.stage == 0).ToList ();
        if (newPlants.Count > 0) {
            var random = new System.Random ();
            int index = random.Next (newPlants.Count);
            newPlants[index].InitializePlant (1);
        }
    }

    private void FindNeighbours () {
        Plant[] plants = FindObjectsOfType<Plant> ();

        foreach (Plant p in plants) {

            Vector3Int plantPos = Vector3Int.CeilToInt (gameObject.transform.localPosition);
            Vector3Int otherPos = Vector3Int.CeilToInt (p.gameObject.transform.localPosition);

            if (otherPos == plantPos + Vector3Int.right ||
                otherPos == plantPos + Vector3Int.left ||
                otherPos == plantPos + Vector3Int.up ||
                otherPos == plantPos + Vector3Int.down
            ) {

                neighbours.Add (p);
            }
        }

    }
}