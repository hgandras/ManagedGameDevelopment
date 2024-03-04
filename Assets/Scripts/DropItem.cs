using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When this game object enters the scene, it chooses a random item to be unlocked.
/// When colliding, it adds the unlocked item, and destroys the object.
/// </summary>
public class DropItem : MonoBehaviour
{
    //TODO: Do a buffer for items that are dropped, but not picked up, so technically they are not yet unlocked

    private IEvolve randomEvolve;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        randomEvolve = null;
        Debug.Log(GameManager.instance.numLockedEvolves);
        Debug.Log(GameManager.instance.numUnlockedEvolves);

        //Choose an evolve type with the probability based on the number of unlocked evolves, then 
        //choose a random locked evolve uniformly from the list.
        float normFactor = GameManager.instance.numLockedEvolves;
        if (normFactor == 0)
        {
            Debug.LogWarning("No more evolves! to unlock!!");
            return;
        }
        float probAttack = GameManager.instance.lockedAttackEvolves.Count/normFactor;
        float probDefense = GameManager.instance.lockedDefenseEvolves.Count / normFactor;
        float value  = Random.value;
        int randomIndex;

        if (value < probAttack)
        {
            randomIndex = Random.Range(0, GameManager.instance.lockedAttackEvolves.Count);
            randomEvolve = GameManager.instance.lockedAttackEvolves[randomIndex];
        }
        else if(value>=probAttack && value<=probAttack + probDefense)
        {
            randomIndex = Random.Range(0, GameManager.instance.lockedDefenseEvolves.Count);
            randomEvolve = GameManager.instance.lockedDefenseEvolves[randomIndex];
        }
        else
        {
            randomIndex = Random.Range(0, GameManager.instance.lockedMovementEvolves.Count);
            randomEvolve = GameManager.instance.lockedMovementEvolves[randomIndex];
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (randomEvolve == null)
            return;
        if(collision.tag == "Player")
        {
            Debug.Log(randomEvolve.Name);
            GameManager.instance.UnlockItem(randomEvolve);
            Destroy(gameObject);
        } 
    }

}
