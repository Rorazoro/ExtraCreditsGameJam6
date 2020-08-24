using System.Linq;
using Assets.Interfaces;
using UnityEngine;

public class PlayerCutHandler {
    private readonly IInputHandler inputHandler;

    public PlayerCutHandler (IInputHandler inputHandler) {
        this.inputHandler = inputHandler;

    }

    public void Tick (Transform transform) {
        bool cut = inputHandler.isCut;

        if (cut) {
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll (transform.position, 0.2f, LayerMask.GetMask ("Plants"));
            Vector3 characterToCollider;
            float dot;
            foreach (Collider2D col in hitObjects) {
                characterToCollider = (col.transform.position - transform.position).normalized;
                dot = Vector3.Dot (characterToCollider, transform.forward);
                if (dot >= Mathf.Cos (55)) {
                    Plant obj = col.gameObject.GetComponent<Plant> ();
                    if (obj != null && obj.isGrowing && obj.stage > 0) {
                        obj.DoInteraction ();
                    }
                }

            }
        }
    }
}