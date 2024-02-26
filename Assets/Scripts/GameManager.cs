using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    //Evolves data
    [Header("Evolves")]
    public AttackEvolve attachedAttackEvolve;
    public DefenseEvolve attachedDefenseEvolve;
    public MovementEvolve attachedMovementEvolve;

    public List<AttackEvolve> attackEvolves;
    public List<DefenseEvolve> defenseEvolves;
    public List<MovementEvolve> movementEvolves;

    public List<AttackEvolve> lockedAttackEvolves 
    {
        get 
        {
            var lockedEvolves = attackEvolves.Where(x => !x.isUnlocked);
            if(lockedEvolves!=null)
                return lockedEvolves.ToList();
            return null;
        }
    }
    public List<DefenseEvolve> lockedDefenseEvolves
    {
        get
        {
            var lockedEvolves = defenseEvolves.Where(x => !x.isUnlocked);
            if (lockedEvolves != null)
                return lockedEvolves.ToList();
            return null;
        }
    }

    public List<MovementEvolve> lockedMovementEvolves
    {
        get
        {
            var lockedEvolves = movementEvolves.Where(x => !x.isUnlocked);
            if (lockedEvolves != null)
                return lockedEvolves.ToList();
            return null;
        }
    }
    public List<AttackEvolve> unlockedAttackEvolves
    {
        get
        {
            var lockedEvolves = attackEvolves.Where(x => x.isUnlocked);
            if (lockedEvolves != null)
                return lockedEvolves.ToList();
            return null;
        }
    }
    public List<DefenseEvolve> unlockedDefenseEvolves
    {
        get
        {
            var lockedEvolves = defenseEvolves.Where(x => x.isUnlocked);
            if (lockedEvolves != null)
                return lockedEvolves.ToList();
            return null;
        }
    }

    public List<MovementEvolve> unlockedMovementEvolves
    {
        get
        {
            var lockedEvolves = movementEvolves.Where(x => x.isUnlocked);
            if (lockedEvolves != null)
                return lockedEvolves.ToList();
            return null;
        }
    }

    public int numUnlockedEvolves
    {
        get { return unlockedAttackEvolves.Count + unlockedDefenseEvolves.Count + unlockedMovementEvolves.Count; } 
    }

    public int numLockedEvolves
    {
        get { return lockedAttackEvolves.Count + lockedDefenseEvolves.Count + lockedMovementEvolves.Count; }
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
        Debug.Log("Awake called");
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
