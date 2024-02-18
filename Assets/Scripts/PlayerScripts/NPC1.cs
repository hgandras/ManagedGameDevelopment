using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPC1 : NPCBase
{
    [SerializeField] float MAX_MOVE_TIME = 15;
    [SerializeField] float defaultSpeed = 5;
    [SerializeField] float alertMoveSpeed = 11;
    float timeElapsed = 0f;
    float randomMoveTime = 0f;
    RaycastHit2D hit;
    
    protected override void updateMoveDir()
    {
        switch(npcState)
        {
            case State.ALERTED:
                moveDir = hit.collider.transform.position - transform.position;
                speed = alertMoveSpeed;
                break;
            case State.IDLE:
                speed = defaultSpeed;   
                if (timeElapsed >= randomMoveTime)
                {
                    timeElapsed = 0;
                    randomMoveTime = Random.value * MAX_MOVE_TIME;
                    moveDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                }
                else
                    timeElapsed += Time.fixedDeltaTime;
                break;
        }
    }

    protected override void triggerAction(Collider2D collision)
    {
        GameManager.instance.RemoveSpawnedEnemy(gameObject);
        Destroy(gameObject);
    }

    protected override void updateState()
    {
        Vector3 offset = new Vector3(moveDir.x, moveDir.y, 0);
        hit = Physics2D.Raycast(transform.position + offset, moveDir);
        if (hit.collider != null && hit.collider.tag == "Player")
            npcState = State.ALERTED;
        else
            npcState = State.IDLE;
    }

    protected override void collisionAction(Collision2D collision)
    {
        return;
    }
}
