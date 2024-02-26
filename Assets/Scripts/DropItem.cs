using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    private void Awake()
    {

        //Choose an evolve type with the probability based on the number of unlocked evolves, then 
        //choose a random locked evolve uniformly from the list.
        int normFactor = GameManager.instance.numLockedEvolves;
        float probAttack = GameManager.instance.lockedAttackEvolves.Count/normFactor;
        float probDefense = GameManager.instance.lockedDefenseEvolves.Count / normFactor;
        float value  = Random.value;
        int randomIndex;
        IEvolve randomEvolve;
        if (value <= probAttack)
        {
            randomIndex = Random.Range(0, GameManager.instance.lockedAttackEvolves.Count);
            randomEvolve = GameManager.instance.lockedAttackEvolves[randomIndex];
        }
        else if(value>probAttack && value <=probDefense)
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
}
