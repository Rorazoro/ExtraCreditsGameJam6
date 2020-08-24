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
    private float growthTime;
    private float growthTimeMax;
    public bool isGrowing = false;
    public int stage;
    private Pillar pillar;
    private List<Plant> neighbours = new List<Plant> ();
    public Collider2D col2d;

    private SpriteRenderer spriteRenderer;

    //Audio
    public PlantAudio pAudio;

    private void Awake () {
        pAudio = GetComponent<PlantAudio> ();
        spriteRenderer = GetComponent<SpriteRenderer> ();
        col2d.enabled = false;

        if (plantData.plantType == PlantType.Pillar) {
            FindPillar ();
        }
        FindNeighbours ();

        if (plantData.plantType == PlantType.Super) {
            InitializePlant (3);
        }
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

        SetStageSprite (stage);
        isGrowing = true;
    }

    public void DoInteraction () {
        // plantData.health--;
        // if (plantData.health == 0) {
        CutPlant ();
        //
    }

    public void GrowPlant () {
        if (stage == 3) {
            if (plantData.plantType == PlantType.Pillar) {
                pillar.IncreaseOvergrowth ();
            }
            SpreadPlants ();
        } else {
            stage++;
            SetStageSprite (stage);

            pAudio.Grow ();
        }
        growthTimeMax = plantData.baseGrowthTime * 10 * (stage + 1);
        growthTime = 0;
    }

    public void CutPlant () {
        growthTime = 0;
        stage = 0;
        col2d.enabled = false;
        SetStageSprite (stage);
        isGrowing = false;

        if (plantData.plantType == PlantType.Super) {
            InitializePlant (0);
        }
        if (plantData.plantType == PlantType.Pillar) {
            pillar.DecreaseOvergrowth ();
        }

        pAudio.Cut ();
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
        foreach (Plant p in Resources.FindObjectsOfTypeAll (typeof (Plant)) as Plant[]) {
            //Plant p = obj.GetComponent<Plant> ();

            if (p != null) {
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

    private void FindPillar () {
        Collider2D hitObject = Physics2D.OverlapCircle (transform.position, 3f, LayerMask.GetMask ("Pillars"));
        if (hitObject != null) {
            pillar = hitObject.gameObject.GetComponent<Pillar> ();
        } else {
            Debug.LogWarning ("Pillar Plant couldn't find Pillar");
        }
    }

    private void SetStageSprite (int stage) {
        float alpha = stage > 0 ? 255f : 0f;

        spriteRenderer.sprite = plantData.stageSprites[stage];
        spriteRenderer.color = new Color (spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
    }
}