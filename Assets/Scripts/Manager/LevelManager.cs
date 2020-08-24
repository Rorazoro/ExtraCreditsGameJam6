using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Managers;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public Pillar[] pillars;
    public List<PlantScriptableObject> randomPlants;

    public int MaxPillarOvergrowth;
    public int PillarOvergrowth;
    public bool isGameOver;
    public GameObject EndGameDialogue;
    public GameObject Player;

    private void Awake () {
        pillars = FindObjectsOfType<Pillar> ();
        MaxPillarOvergrowth = pillars.Length;
    }

    private void Update () {
        if (PillarOvergrowth >= MaxPillarOvergrowth && !isGameOver) {
            GameOver ();
        }
    }

    private void GameOver () {
        Debug.Log ("Game Over");
        StopAllPlantGrowth ();
        //StopPlayerMovement ();
        isGameOver = true;
        Cursor.visible = true;
        FadeInEndGameDialogue ();
    }

    private void StopPlayerMovement () {
        PlayerInput input = Player.GetComponent<PlayerInput> ();
        input.enabled = false;
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

    public void FadeInEndGameDialogue () {
        DialogueManager dialogueManager = GameObject.Find ("LevelManager").GetComponent<DialogueManager> ();
        DialogueContainer container = EndGameDialogue.GetComponent<DialogueContainer> ();
        Image image = EndGameDialogue.GetComponent<Image> ();

        EndGameDialogue.SetActive (true);
        StartCoroutine (DoFade (image, image.color.a, 1, 0.4f));
        dialogueManager.StartDialogue (container);
    }

    private IEnumerator DoFade (Image image, float start, float end, float duration) {
        float counter = 0f;

        while (counter < duration) {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp (start, end, counter / duration);
            image.color = new Color (image.color.r, image.color.g, image.color.b, alpha);
            yield return new WaitForSeconds (0.05f);
        }
    }
}