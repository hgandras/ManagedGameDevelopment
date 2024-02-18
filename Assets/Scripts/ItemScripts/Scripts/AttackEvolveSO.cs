using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Evolves/AttackEvolve")]
public class AttackEvolveSO : ScriptableObject
{
    public float attackRange;
    public float attackSpeed;
    public bool melee;
    public float damage;
    public Sprite displaySprite;
}
