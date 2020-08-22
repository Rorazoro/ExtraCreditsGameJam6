using Assets.Interfaces;
using UnityEngine;

[RequireComponent (typeof (CircleCollider2D))]
public class Readable : MonoBehaviour, IInteractable {
    public void DoInteraction () {
        Debug.Log ("You stare at the red dot until it vanishes.");
        gameObject.SetActive (false);
    }
}