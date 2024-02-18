using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generates random information about the NPC's.
/// </summary>
public class RandomEnemyInfo 
{
    
    public Color headColor;
    public Color bodyColor;
    public string tag;

    public RandomEnemyInfo()
    {
        headColor = new Color(Random.value, Random.value, Random.value);
        bodyColor = new Color(Random.value, Random.value, Random.value);
    }

    public RandomEnemyInfo(int seed)
    {
        Random.InitState(seed);
        headColor = new Color(Random.value, Random.value, Random.value);
        bodyColor = new Color(Random.value, Random.value, Random.value);
    }
    
}
