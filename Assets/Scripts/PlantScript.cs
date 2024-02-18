using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    [SerializeField] float dropChance; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float rng_num=Random.value;
        if (rng_num < dropChance)
            DropItem();
        Destroy(this);
    }

    /// <summary>
    /// Selects one of the unlocked items 
    /// </summary>
    private void DropItem()
    {

    }
}
