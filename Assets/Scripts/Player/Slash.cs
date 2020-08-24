using UnityEngine;
using UnityEngine.InputSystem;

public class Slash : MonoBehaviour {
    // Point you want to have sword rotate around
    public Transform parent;
    // how far you want the sword to be from point
    public float range = 0.5f;
    void Start () {
        // if the sword is child object, this is the transform of the character (or shoulder)
        parent = transform.parent.transform;
        Cursor.visible = false;
    }
    void Update () {
        // Get the direction between the shoulder and mouse (aka the target position)
        Vector3 shoulderToMouseDir =
            Camera.main.ScreenToWorldPoint (Mouse.current.position.ReadValue ()) - parent.position;
        shoulderToMouseDir.z = 0; // zero z axis since we are using 2d
        // we normalize the new direction so you can make it the arm's length
        // then we add it to the shoulder's position
        transform.position = parent.position + (range * shoulderToMouseDir.normalized);

        float angle = Mathf.Atan2 (shoulderToMouseDir.y, shoulderToMouseDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
    }
}