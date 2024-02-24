using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEvolve : MonoBehaviour, IEvolve
{
    public MovementEvolveSO evolveData;
    [SerializeField] string _ID;
    public string ID { get { return _ID; } private set { _ID = value; } }
    public bool isUnlocked { get; set; }

    public string Name => throw new System.NotImplementedException();

    private void Awake()
    {
        isUnlocked = false;
    }

    public void Action()
    {
        //Do dashes/teleport or anyting that comes to my mind and 
        //is related to movement.
        throw new System.NotImplementedException();
    }

    public void Attach(GameObject game_object)
    {
        throw new System.NotImplementedException();
    }
}
