using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Evolves/MovementEvolve")]
public class MovementEvolveSO : ScriptableObject
{
    [SerializeField] Sprite sprite;
    [SerializeField] float movementSpeedBoost;
}
