using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Evolves/MovementEvolve")]
public class MovementEvolve : ScriptableObject, IEvolve
{
    public Sprite sprite;
    public float movementSpeedBoost;
    [SerializeField] string _ID;
    [SerializeField] string _Name;

    public string ID { get { return _ID; } private set { _ID = value; } }
    public string Name { get { return _Name; } private set { _Name = value; } }
}
