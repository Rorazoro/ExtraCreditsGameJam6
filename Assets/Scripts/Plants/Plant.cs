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
    public float growthTime;
    public float growthTimeMax;
    public bool isGrowing = false;
    public int stage;
    public bool isSuperPlant;
    public List<Plant> neighbours = new List<Plant> ();
    public Collider2D col2d;
    public Sprite[] stageSprites;

    private SpriteRenderer spriteRenderer;

    //Audio
    public PlantAudio pAudio;

    private void Awake () {
        pAudio = GetComponent<PlantAudio> ();
        spriteRenderer = GetComponent<SpriteRenderer> ();
        col2d.enabled = false;

        if (isSuperPlant) {
            InitializePlant (3);
        }
        FindNeighbours ();

        pAudio.growth = stage + 1;
        pAudio.prevGrowth = stage + 1;
    }

    private void Update () {
        if (isGrowing && growthTime == growthTimeMax) {
            //col2d.enabled = true;
            GrowPlant ();
        } else {
            growthTime++;
        }
    }

    public void InitializePlant (int initStage) {
        plantData.health = plantData.maxHealth;
        stage = initStage;

        growthTimeMax = plantData.baseGrowthTime * 10 * (stage + 1);
        growthTime = 0;

        spriteRenderer.sprite = stageSprites[stage];
        isGrowing = true;
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
            spriteRenderer.sprite = stageSprites[stage];
        }
        growthTimeMax = plantData.baseGrowthTime * 10 * (stage + 1);
        growthTime = 0;

        //Match Growth with audio
        pAudio.growth = stage + 1;
    }

    public void CutPlant () {
        Debug.Log ($"Plant Cut!");
        growthTime = 0;
        stage = 0;
        col2d.enabled = false;
        spriteRenderer.sprite = stageSprites[stage];
        isGrowing = false;

        if (isSuperPlant) {
            InitializePlant (0);
        }
    }

    public void SpreadPlants () {
        List<Plant> newPlants = neighbours.Where (p => !p.isGrowing).ToList ();
        if (newPlants.Count > 0) {
            var random = new System.Random ();
            int index = random.Next (newPlants.Count);
            newPlants[index].InitializePlant (0);
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