using Assets.Interfaces;
using UnityEngine;

public class PlayerCutHandler {
    private readonly IInputHandler inputHandler;

    public PlayerCutHandler (IInputHandler inputHandler) {
        this.inputHandler = inputHandler;

    }

    public void Tick (Vector3 position) {
        bool cut = inputHandler.isCut;

        if (cut) {
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll (position, 1f);
            foreach (Collider2D col in hitObjects) {
                Plant obj = col.gameObject.GetComponent<Plant> ();
                if (obj != null) {
                    obj.DoInteraction ();
                }
            }
        }
    }
}