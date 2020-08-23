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

    private void Awake () {
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
    }

    private void Update () {
        if (stage > 0 && growthTime <= DateTime.Now) {
            col2d.enabled = true;
            GrowPlant ();
        }
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
        growthTime = DateTime.MinValue;
        stage = 0;
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
        Grid grid = FindObjectOfType<Grid> ();
        Transform gridTransform = grid.transform;

        foreach (Plant plant in plants) {
            Transform otherT = plant.gameObject.transform;
            if (((otherT.position.x == transform.position.x - gridTransform.localScale.x || otherT.position.x == transform.position.x + gridTransform.localScale.x) && otherT.position.y == transform.position.y) ||
                ((otherT.position.x == transform.position.x - gridTransform.localScale.x || otherT.position.x == transform.position.x + gridTransform.localScale.x) && (otherT.position.y == transform.position.y + gridTransform.localScale.y || otherT.position.y == transform.position.y - gridTransform.localScale.y)) ||
                ((otherT.position.y == transform.position.y - gridTransform.localScale.y || otherT.position.y == transform.position.y + gridTransform.localScale.y) && otherT.position.x == transform.position.x)) {
                neighbours.Add (plant);
            }
        }

    }
}