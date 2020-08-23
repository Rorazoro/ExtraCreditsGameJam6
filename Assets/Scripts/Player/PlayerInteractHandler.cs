using Assets.Interfaces;
using UnityEngine;

public class PlayerInteractHandler {

    private readonly IInputHandler inputHandler;

    public GameObject currentInterObj = null;

    public PlayerInteractHandler (IInputHandler inputHandler) {
        this.inputHandler = inputHandler;
    }

    public void Tick () {
        bool interact = inputHandler.isInteraction;
        if (interact && currentInterObj != null) {
            currentInterObj.GetComponent<IInteractable> ().DoInteraction ();
        }
    }

    public void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("Interactable")) {
            currentInterObj = other.gameObject;
        }
    }

    public void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag ("Interactable")) {
            if (other.gameObject == currentInterObj) {
                currentInterObj = null;
            }
        }
    }
}