using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField] List<GameObject> objectsToSpawn;
    [SerializeField] float spawnInterval=2f;
    [SerializeField] bool canSpawn = true;

    private void Start()
    {
        StartCoroutine(Spawner());
        StartCoroutine(PlantSpawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait= new WaitForSeconds(spawnInterval);

        while(canSpawn)
        {
            yield return wait;
            Vector2 spawnPosScreen = new Vector2(Random.value, Random.value);
            Vector2 spawnPos = Camera.main.ViewportToWorldPoint(spawnPosScreen);
            
            GameObject spawnedObject = Instantiate(objectsToSpawn[0],spawnPos,Quaternion.identity,this.transform);

            SpriteRenderer[] sr = spawnedObject.GetComponentsInChildren<SpriteRenderer>();
            int randomEnemy = Random.Range(0, GameManager.instance.numRandomEnemies);
            sr[0].color = GameManager.instance.procEnemyColors[randomEnemy].headColor;
            sr[1].color = GameManager.instance.procEnemyColors[randomEnemy].bodyColor;

            GameManager.instance.AddSpawnedEnemy(spawnedObject);
        }
    }

    private IEnumerator PlantSpawner()
    {
        WaitForSeconds wait = new WaitForSeconds(3);
        while(canSpawn) 
        {
            yield return wait;
            Vector2 spawnPosScreen = new Vector2(Random.value, Random.value);
            Vector2 spawnPos = Camera.main.ViewportToWorldPoint(spawnPosScreen);

            GameObject spawnedObject = Instantiate(objectsToSpawn[1], spawnPos, Quaternion.identity, this.transform);
            
        }

    }
}
