using UnityEngine;

namespace Assets.Interfaces {
    public interface IInputHandler {
        bool EnableDebugging { get; set; }
        Vector2 movement { get; }
        //Vector2 lookDirection { get; }
        void ReadValue ();

    }
}