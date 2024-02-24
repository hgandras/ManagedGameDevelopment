using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Holds functionalities of the player. Derives from the ChracterBase class, which holds common methods for the player, and the NPCs.
/// </summary>
public class Player : MonoBehaviour
{
    protected float speed;
    protected Vector2 moveDir = Vector2.up;
    protected float maxSpeed = 10;

    public AttackEvolve attackEvolve { get; set; }
    public DefenseEvolve defenseEvolve { get; set; }
    public MovementEvolve movementEvolve { get; set; }

    private Rigidbody2D rb;
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



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(rb);
        //Debug.Log("Start called");
         GameObject attackEvolve = transform.Find("AttackEvolve").gameObject;
         /*GameObject defenseEvolve = transform.Find("DefenseEvolve").gameObject;
         GameObject movementEvolve = transform.Find("MovementEvolve").gameObject;*/

         SpriteRenderer aERenderer = attackEvolve.GetComponent<SpriteRenderer>();
        /*SpriteRenderer dERenderer = defenseEvolve.GetComponent<SpriteRenderer>();
        SpriteRenderer mERenderer = movementEvolve.GetComponent<SpriteRenderer>();*/

        Debug.Log(GameManager.instance.attachedAttackEvolve.evolveData.displaySprite);
         aERenderer.sprite = GameManager.instance.attachedAttackEvolve.evolveData.displaySprite;
         //dERenderer.sprite = GameManager.instance.attachedDefenseEvolve.evolveData.*/
    }

    void FixedUpdate()
    {        
        //Update move direction, and normalize
        updateMoveDir();

        moveDir.Normalize();
        //Debug.Log(rb);
        rb.AddForce(moveDir * 2);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);

        float angle = (float)((Mathf.Atan2(moveDir.y, moveDir.x) / Mathf.PI) * 180f) - 90f;
        rb.MoveRotation(angle);
    }


    private void updateMoveDir()
    {
        moveDir = moveAction.ReadValue<Vector2>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            GameManager.DamagePlayer(5);
            Debug.Log(GameManager.instance.playerHP);
        }
    }

    public void AddItemToPlayer(char evolveType, int evolveID)
    {
        switch(evolveType)
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

