using Assets.Managers;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Assets.Editors {

    [CustomEditor (typeof (DebugManager))]
    public class DebugManagerEditor : Editor {

        public override void OnInspectorGUI () {
            base.OnInspectorGUI ();
        }
    }
}