using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;


public abstract class NPCBase : MonoBehaviour
{
    protected float speed;
    protected Vector2 moveDir = Vector2.up;
    protected float maxSpeed = 10;

    protected enum State
    {
        IDLE,
        ALERTED,
        COMBAT,
        FLEEING
    }
    protected State npcState = State.IDLE;
    public AttackEvolve attackEvolve { get; set; }
    public DefenseEvolve defenseEvolve { get; set; }
    public MovementEvolve movementEvolve { get; set; }
    protected Rigidbody2D rb;

    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        //DontDestroyOnLoad(gameObject);
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
    /// Determines how the NPC moves. It is going to determine the behavior of the different NPC's.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    protected virtual void updateMoveDir()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// This is going to be the difference between the NPC's. It determines how it moves between states.
    /// </summary>
    protected virtual void updateState()
    {
        throw new NotImplementedException();
    }
}
