using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    [SerializeField] float dropChance;
    [SerializeField] DropItem drop;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        float rng_num = Random.value;
        if (rng_num < dropChance)
        {
            Instantiate(drop,transform.position,Quaternion.identity,transform.parent);
        }
        Destroy(gameObject);
    }
}
