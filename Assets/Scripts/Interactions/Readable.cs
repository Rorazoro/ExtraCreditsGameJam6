using Assets.Interfaces;
using Assets.Managers;
using UnityEngine;

[RequireComponent (typeof (CircleCollider2D))]
public class Readable : MonoBehaviour, IInteractable {
    public Dialogue dialogue;
    public void DoInteraction () {
        //DialogueManager.Instance.StartDialogue (dialogue);
        gameObject.SetActive (false);
    }
}