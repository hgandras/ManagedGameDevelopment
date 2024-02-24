using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;


public abstract class CharacterBase : MonoBehaviour
{
    protected float speed;
    protected Vector2 moveDir = Vector2.up;
    protected float maxSpeed = 10;

    public AttackEvolve attackEvolve { get; set; }
    public DefenseEvolve defenseEvolve { get; set; }
    public MovementEvolve movementEvolve { get; set; }

    protected Rigidbody2D rb;


    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionAction(collision);
    }

    protected virtual void collisionAction(Collision2D collision)
    {
        throw new NotImplementedException();
    }

    protected virtual void triggerAction(Collider2D collision) 
    {
        throw new NotImplementedException();
    }

    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        updateState();
        //Update move direction, and normalize
        updateMoveDir();

        moveDir.Normalize();
        rb.AddForce(moveDir*2);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity,maxSpeed);

        float angle = (float)((Mathf.Atan2(moveDir.y, moveDir.x) / Math.PI) * 180f)-90f;
        rb.MoveRotation(angle);
    }

    /// <summary>
    /// Returns the direction the player should move based on the input
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    protected virtual void updateMoveDir()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Based on conditions, it changes the state of the AI or the player
    /// </summary>
    protected virtual void updateState()
    {
        throw new NotImplementedException();
    }
}
