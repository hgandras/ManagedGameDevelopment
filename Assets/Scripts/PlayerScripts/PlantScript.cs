using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField] float dropChance;
    [SerializeField] DropItem drop;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            return;
        }
        float rng_num = Random.value;
        if (rng_num < dropChance && GameManager.instance.numLockedEvolves > 0)
        {
            Instantiate(drop, transform.position, Quaternion.identity, transform.parent);
        }
        Destroy(gameObject);
    }
}
