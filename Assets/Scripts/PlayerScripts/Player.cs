using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Holds functionalities of the player. Derives from the ChracterBase class, which holds common methods for the player, and the NPCs.
/// </summary>
public class Player : CharacterBase
{
    private Controls actions;
    private InputAction moveAction;

    private void Awake()
    {
        actions = new Controls();
    }

    private void OnEnable()
    {
        moveAction = actions.Gameplay.Move;
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    protected override void triggerAction(Collider2D collision)
    {
        //GameManager.AddXP(5);
        
    }

    protected override void updateMoveDir()
    {
        moveDir = moveAction.ReadValue<Vector2>();
    }

    protected override void updateState()
    {
        return;
    }

    protected override void collisionAction(Collision2D collision)
    {

        if (collision.transform.tag == "Enemy")
        {
            GameManager.DamagePlayer(5);
            Debug.Log(GameManager.instance.playerHP);
        }
    }

    public void AddItemToPlayer(char evolveType, int evolveID)
    {
        switch (evolveType)
        {
            case 'A':
                attackEvolve = GameManager.instance.attackEvolves[evolveID];
                break;
            case 'D':
                defenseEvolve = GameManager.instance.defenseEvolves[evolveID];
                break;
            case 'M':
                movementEvolve = GameManager.instance.movementEvolves[evolveID];
                break;
            default:
                Debug.LogWarning("Wrong button ID format");
                return;
        }

        Debug.Log("Player attack evolve:" + attackEvolve);
        Debug.Log("Player defense evolve:" + defenseEvolve);
        Debug.Log("Player movement evolve:" + movementEvolve);

        //Here attach the evolve to the player visually, and update the player's stats.
    }
}

