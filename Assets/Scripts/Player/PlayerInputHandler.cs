using System;
using Assets.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : IInputHandler {

    private bool enableDebugging;
    private PlayerInput playerInput;
    private InputAction inputAction;

    public Vector2 movement { get; private set; }
    public Vector2 navigate { get; private set; }
    public bool isInteraction { get; private set; }
    public bool isCut { get; private set; }
    public bool EnableDebugging { get => enableDebugging; set => enableDebugging = value; }

    //public Vector2 lookDirection { get; private set; }

    //public event EventHandler OnInput;

    public PlayerInputHandler (PlayerInput input) {
        playerInput = input;
        playerInput.onActionTriggered += Input_OnActionTriggered;
    }

    private void Input_OnActionTriggered (InputAction.CallbackContext context) {
        inputAction = context.action;
        ReadValue ();
        // if (OnInput != null) {
        //     ReadValue ();
        //     OnInput (this, EventArgs.Empty);
        // }
    }

    public void ReadValue () {
        if (inputAction != null) {

            bool isInputBound = false;

            navigate = Vector2.zero;
            isInteraction = false;
            isCut = false;

            switch (inputAction.name) {
                case "Move":
                    movement = inputAction.ReadValue<Vector2> ();
                    isInputBound = true;
                    break;
                case "Navigate":
                    navigate = inputAction.ReadValue<Vector2> ();
                    isInputBound = true;
                    break;
                case "Interact":
                    isInteraction = inputAction.triggered;
                    isInputBound = true;
                    break;
                case "Fire":
                    isCut = inputAction.triggered;
                    isInputBound = true;
                    break;
            }

            if (enableDebugging) {
                Debug.Log ($"Input Fired! Name: {inputAction.name}; Bound: {isInputBound}");
            }
        }

    }
}