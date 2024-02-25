using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName= "ScriptableObjects/Evolves/DefenseEvolve")]
public class DefenseEvolveSO : ScriptableObject
{
    public Sprite sprite;
    public float dmgReduction;
    //Temporary, just to differentiate items represented by the 2D primitives
    public Color spriteColor;
}
