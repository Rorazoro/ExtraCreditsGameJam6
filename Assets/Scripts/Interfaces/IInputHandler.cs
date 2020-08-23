using UnityEngine;

namespace Assets.Interfaces {
    public interface IInputHandler {
        bool EnableDebugging { get; set; }
        Vector2 movement { get; }
        bool isInteraction { get; }
        bool isCut { get; }
        void ReadValue ();

    }
}