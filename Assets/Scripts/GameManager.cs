using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Instance
    public static GameManager instance { get; private set; }

    //Player stats
    [Header("General player stats")]
    public float playerHP;
    public float playerMaxHP;
    public int lvl;
    [Tooltip("Player's current progress through the level")]
    public int lvlProgress;
    [Tooltip("XP to be collected to complete the level")]
    public int lvlMaxXP;
    [Tooltip("Number of different enemies generated")]
    public int numRandomEnemies;
    public List<RandomEnemyInfo> procEnemyColors = new List<RandomEnemyInfo>();


    //TODO: Add base stats to the player, if no evolves are attached
    [Header("Evolves")]
    public AttackEvolve attachedAttackEvolve;
    public DefenseEvolve attachedDefenseEvolve;
    public MovementEvolve attachedMovementEvolve;

    public List<AttackEvolve> attackEvolves;
    public List<DefenseEvolve> defenseEvolves;
    public List<MovementEvolve> movementEvolves;

    [Header("Events")]
    public GameEvent onXPChange;
    public GameEvent onHPChange;

    //Private lists
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private List<GameObject> spawnedPlants = new List<GameObject>();

    //Properties
    public int numEnemies { get { return spawnedEnemies.Count;} }
    public int numPlants { get { return spawnedPlants.Count;} }
    
    public void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        
    }

    private void Start()
    {
        
        instance.lvl = 0;
        instance.lvlProgress = 0;
        instance.lvlMaxXP = 50;
        instance.playerMaxHP = 100;
        instance.numRandomEnemies = 3;
        GenerateRandomColors();
        Debug.Log("Start run");
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

    public void AddSpawnedPlant(GameObject plant)
    {
        if(!spawnedPlants.Contains(plant))
            spawnedPlants.Add(plant);
    }

    public void RemoveSpawnedEnemy(GameObject enemy)
    {
        if (spawnedEnemies.Contains(enemy))
            spawnedEnemies.Remove(enemy);
    }

    public void RemoveSpawnedPlant(GameObject plant)
    {
        if (spawnedPlants.Contains(plant))
            spawnedPlants.Remove(plant);
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
