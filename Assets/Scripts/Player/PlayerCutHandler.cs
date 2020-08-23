using System.Linq;
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
            Collider2D[] hitObjects = Physics2D.OverlapCircleAll (position, 2f, LayerMask.GetMask ("Plants"));
            //Debug.Log ($"objects hit {hitObjects.Length}");
            foreach (Collider2D col in hitObjects) {
                Plant obj = col.gameObject.GetComponent<Plant> ();
                if (obj != null && obj.isGrowing && obj.stage > 0) {
                    obj.DoInteraction ();
                }
            }
        }
    }
}