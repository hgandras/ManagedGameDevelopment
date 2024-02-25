using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: This structure will probably change, maybe scriptable object data will be enough to describe an item.
public class AttackEvolve : MonoBehaviour, IEvolve
{
    public AttackEvolveSO evolveData;
    [SerializeField] string _ID;
    private float attackRange;
    private float attackSpeed;
    private float damage;
    private bool melee;

    public bool isUnlocked { get; set; }
    public string ID { get { return _ID; } private  set { _ID = value; } }
    public string Name => throw new System.NotImplementedException();

    private void OnValidate()
    {
        ID = _ID;
    }

    private void Awake()
    {
        isUnlocked = false;

        attackRange = evolveData.attackRange;
        attackSpeed = evolveData.attackSpeed;
        damage = evolveData.damage;
        melee = evolveData.melee;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = evolveData.displaySprite;
    }

    public void Action()
    {
        //Shoot particles, if melee do nothing
        throw new System.NotImplementedException();
    }

    public void Attach(GameObject game_object)
    {
        //Called when the item is being attached from the editor. 
        //Changes the visuals of the character, and the current evolve in the 
        //Player script.
        throw new System.NotImplementedException();
    }
}
