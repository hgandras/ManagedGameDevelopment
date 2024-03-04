using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Evolves/AttackEvolve")]
public class AttackEvolve : ScriptableObject , IEvolve
{
    public float attackRange;
    public float attackSpeed;
    public bool melee;
    public float damage;
    public Sprite displaySprite;
    //Temporary, just to differentiate items represented by the 2D primitives
    public Color spriteColor;
    [SerializeField] string _ID;
    [SerializeField] string _Name;

    public string ID { get { return _ID; } private set { _ID = value; } }
    public string Name { get { return _Name; } private set { _Name = value; } }
}
