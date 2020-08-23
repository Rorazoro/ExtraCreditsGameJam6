using UnityEngine;

public class LevelManager : SingletonBehaviour<LevelManager> {
    public Pillar[] pillars;

    public int MaxPillarOvergrowth;
    public int PillarOvergrowth;
    public bool isGameOver;

    private void Awake () {
        pillars = FindObjectsOfType<Pillar> ();
        MaxPillarOvergrowth = pillars.Length / 2;
    }

    private void Update () {
        if (PillarOvergrowth >= MaxPillarOvergrowth && !isGameOver) {
            GameOver ();
        }
    }

    private void GameOver () {
        Debug.Log ("Game Over");
        StopAllPlantGrowth ();
        isGameOver = true;
    }

    private void StopAllPlantGrowth () {
        Plant[] plants = FindObjectsOfType<Plant> ();
        foreach (Plant p in plants) {
            p.isGrowing = false;
        }
    }

    public void IncreaseOvergrowth () {
        PillarOvergrowth++;
    }
}