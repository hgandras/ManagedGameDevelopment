using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


//TODO: For refactoring later
/// <summary>
/// -Redo the item system, so that there is an Item class, inheriting from a base class, and in its constructor it 
/// accepts a scriptable object containing its data. This way, the data can just simply be read from the item, and other 
/// methods can be attached to it. Also IEvolve might won't be needed. There is probably a better way to handle unlocked items.
/// 
/// -Change IMGui for UIToolkit!!!!
/// </summary>

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

    //Evolves data
    [Header("Evolves")]
    public AttackEvolve attachedAttackEvolve;
    public DefenseEvolve attachedDefenseEvolve;
    public MovementEvolve attachedMovementEvolve;

    public List<AttackEvolve> lockedAttackEvolves;
    public List<DefenseEvolve> lockedDefenseEvolves;
    public List<MovementEvolve> lockedMovementEvolves;

    public List<AttackEvolve> unlockedAttackEvolves;
    public List<DefenseEvolve> unlockedDefenseEvolves;
    public List<MovementEvolve> unlockedMovementEvolves;

    public int numLockedEvolves
    {
        get { return lockedAttackEvolves.Count + lockedDefenseEvolves.Count + lockedMovementEvolves.Count; } 
    }

    public int numUnlockedEvolves
    {
        get { return unlockedAttackEvolves.Count + unlockedDefenseEvolves.Count + unlockedMovementEvolves.Count; }
    }

    //Player events (might be changed)
    [Header("Events")]
    public GameEvent onXPChange;
    public GameEvent onHPChange;

    //Private lists, and things related to handling game objects
    [SerializeField] private GameObject objectsToKeep;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private List<GameObject> spawnedPlants = new List<GameObject>();

    //Properties
    public int numEnemies { get { return spawnedEnemies.Count;} }
    public int numPlants { get { return spawnedPlants.Count;} }


    //Others
    public bool canChangeScene;

    //Controls for changing between scenes
    private Controls actions;
    private InputAction backAction;

    //Unity messages
    private void OnEnable()
    {
        backAction.Enable();
    }

    private void OnDisable()
    {
        backAction.Disable();
    }

    public void Awake()
    {
        actions = new Controls();
        backAction = actions.Gameplay.Back;
        backAction.performed += ChangeToEditor;

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {  
        GenerateRandomColors();
    }

    //Public methods, used for manipulating the gamestate
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

    //This is ugly::((
    public void UnlockItem(IEvolve evolve)
    {
       
        Type type = evolve.GetType();
        if(type.IsAssignableFrom(typeof(AttackEvolve)))
        {
            AttackEvolve atEvolve = evolve as AttackEvolve;
            if (atEvolve != null && lockedAttackEvolves.Contains(atEvolve))
            {
                lockedAttackEvolves.Remove(atEvolve);
                unlockedAttackEvolves.Add(atEvolve);
            }
        }
        else if (type.IsAssignableFrom(typeof(DefenseEvolve)))
        {
            DefenseEvolve atEvolve = evolve as DefenseEvolve;
            if (atEvolve != null && lockedDefenseEvolves.Contains(atEvolve))
            {
                lockedDefenseEvolves.Remove(atEvolve);
                unlockedDefenseEvolves.Add(atEvolve);
            }
        }
        else if (type.IsAssignableFrom(typeof(MovementEvolve)))
        {
            MovementEvolve atEvolve = evolve as MovementEvolve;
            if (atEvolve != null && lockedMovementEvolves.Contains(atEvolve))
            {
                lockedMovementEvolves.Remove(atEvolve);
                unlockedMovementEvolves.Add(atEvolve);
            }
        }
    }

    //Private methods
    private void GenerateRandomColors()
    {
        for(int i=0; i<numRandomEnemies;i++)
        {
            instance.procEnemyColors.Add(new RandomEnemyInfo());
        }
    }

    private void ChangeToEditor(InputAction.CallbackContext callbackContext)
    {
        Scene activeScene = SceneManager.GetActiveScene();
        if (activeScene.name == "Editor" && canChangeScene)
        {
            objectsToKeep.SetActive(true);
            SceneManager.LoadScene("SampleScene");
        }
        else if (activeScene.name == "SampleScene")
        {
            objectsToKeep.SetActive(false);
            SceneManager.LoadScene("Editor");
        }
    }

}
