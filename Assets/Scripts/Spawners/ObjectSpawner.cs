using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectSpawner : MonoBehaviour
{

    [SerializeField] protected List<GameObject> objectsToSpawn;
    [SerializeField] protected float spawnInterval=2f;
    [SerializeField] protected bool canSpawn = true;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(Spawner());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    protected abstract IEnumerator Spawner();

    

    
}
