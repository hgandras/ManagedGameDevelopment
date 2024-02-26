using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : ObjectSpawner
{
    protected override IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(3);
        while (canSpawn)
        {
            yield return wait;
            Vector2 spawnPosScreen = new Vector2(Random.value, Random.value);
            Vector2 spawnPos = Camera.main.ViewportToWorldPoint(spawnPosScreen);
            Instantiate(objectsToSpawn[0], spawnPos, Quaternion.identity, transform);
        }
    }
}
