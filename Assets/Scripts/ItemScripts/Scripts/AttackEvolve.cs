using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEvolve : MonoBehaviour, IEvolve
{
    [SerializeField] AttackEvolveSO attackData;
    [SerializeField] int _ID;
    private float attackRange;
    private float attackSpeed;
    private float damage;
    private bool melee;

    public bool isUnlocked { get; set; }
    public int ID { get { return _ID; } set { _ID = value; } }

    private void OnValidate()
    {
        ID = _ID;
    }

    private void Awake()
    {
        isUnlocked = false;

        attackRange = attackData.attackRange;
        attackSpeed = attackData.attackSpeed;
        damage = attackData.damage;
        melee = attackData.melee;
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
