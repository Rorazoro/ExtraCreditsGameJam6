using Assets.Interfaces;
using UnityEngine;

public class PlayerAnimator
{
    private readonly IInputHandler inputHandler;
    private readonly Animator animator;
    private readonly float speed;

    public PlayerAnimator(IInputHandler inputHandler, Animator animator) {
        this.inputHandler = inputHandler;
        this.animator = animator;
    }

    public void Tick()
    {
        // if (!Mathf.Approximately(movement.x, 0.0f) || !Mathf.Approximately(movement.y, 0.0f))
        // {
        //     lookDirection.Set(movement.x, movement.y);
        // }

        animator.SetFloat("MoveX", inputHandler.movement.x);
        animator.SetFloat("MoveY", inputHandler.movement.y);
        animator.SetFloat("Speed", inputHandler.movement.sqrMagnitude);
    }
}