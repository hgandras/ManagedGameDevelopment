using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseEvolve : MonoBehaviour, IEvolve
{
    [SerializeField] DefenseEvolveSO evolveData;
    public bool isUnlocked {get;set;}
    public int ID { get; }
    private void Awake()
    {
        isUnlocked = false;
    }
    public void Action()
    {
        //Can be mechanics like pushing enemies away
        throw new System.NotImplementedException();
    }

    public void Attach(GameObject game_object)
    {
        throw new System.NotImplementedException();
    }
}
