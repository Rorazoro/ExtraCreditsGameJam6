using System;
using Assets.Interfaces;
using UnityEngine;

public class EntityMotor
{
    private readonly IInputHandler inputHandler;
    private readonly Rigidbody2D rb;
    private readonly float speed;

    public EntityMotor(IInputHandler inputHandler, Rigidbody2D rb, float speed) {
        this.inputHandler = inputHandler;
        this.rb = rb;
        this.speed = speed;
    }

    public void Tick()
    {
        // if (!Mathf.Approximately(movement.x, 0.0f) || !Mathf.Approximately(movement.y, 0.0f))
        // {
        //     lookDirection.Set(movement.x, movement.y);
        // }

        rb.MovePosition(rb.position + inputHandler.movement * speed * Time.fixedDeltaTime);
    }
}