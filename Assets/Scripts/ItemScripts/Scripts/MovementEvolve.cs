using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEvolve : MonoBehaviour, IEvolve
{
    [SerializeField] MovementEvolveSO evolveData;

    public bool isUnlocked { get; set; }
    public int ID { get;}
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
