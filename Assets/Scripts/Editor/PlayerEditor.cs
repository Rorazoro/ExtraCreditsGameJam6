using Assets.Entities;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (Player))]
public class PlayerEditor : Editor {

    private bool enableInputDebugLog;

    public override void OnInspectorGUI () {
        base.OnInspectorGUI ();

        // Player player = (Player) target;
        // enableInputDebugLog = EditorGUILayout.Toggle ("Enable Input Debug Log", enableInputDebugLog);
        // player.ToggleInputDebugLog (enableInputDebugLog);

    }
}