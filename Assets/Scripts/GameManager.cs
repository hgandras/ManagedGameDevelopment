using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public float playerHP { get; private set; }
    public float playerMaxHP { get; private set; }
    public int lvl { get; private set; }
    public int lvlProgress { get; private set; }
    public int lvlMaxXP { get; private set; }
    public List<RandomEnemyInfo> procEnemyColors{ get;private set; }
    public int numRandomEnemies { get;private set; }

    //TODO: Add base stats to the player, if no evolves are attached
    
    public List<AttackEvolve> attackEvolves;
    public List<DefenseEvolve> defenseEvolves;
    public List<MovementEvolve> movementEvolves;

    [Header("Events")]
    public GameEvent onXPChange;
    public GameEvent onHPChange;

    private List<GameObject> spawnedEnemies= new List<GameObject>();

    

    public void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void Start()
    {
        instance.playerHP = 100;
        instance.lvl = 0;
        instance.lvlProgress = 0;
        instance.lvlMaxXP = 50;
        instance.playerMaxHP = 100;
        instance.numRandomEnemies = 3;
        instance.procEnemyColors = new List<RandomEnemyInfo>();
        GenerateRandomColors();

    }

    public static void AddXP(int XP)
    {
        instance.lvlProgress += XP;
        if(instance.lvlProgress>instance.lvlMaxXP)
        {
            instance.lvl += 1;
            instance.lvlProgress-=instance.lvlMaxXP;
            instance.lvlMaxXP = (int)(1.5 * instance.lvlMaxXP);
        }
        instance.onXPChange.Raise();
    }

    public static void DamagePlayer(int damage)
    {
        instance.playerHP -= damage;
        instance.onHPChange.Raise();
    }

    public void AddSpawnedEnemy(GameObject enemy)
    {
       if(!spawnedEnemies.Contains(enemy))
        spawnedEnemies.Add(enemy);
    }

    public void RemoveSpawnedEnemy(GameObject enemy)
    {
        if (spawnedEnemies.Contains(enemy))
            spawnedEnemies.Remove(enemy);
    }

    private void GenerateRandomColors()
    {
        for(int i=0; i<numRandomEnemies;i++)
        {
            instance.procEnemyColors.Add(new RandomEnemyInfo());
            Debug.Log(procEnemyColors[i].headColor);
        }
    }



}
