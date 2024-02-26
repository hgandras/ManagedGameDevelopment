using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseEvolve : MonoBehaviour, IEvolve
{
    public DefenseEvolveSO evolveData;
    [SerializeField] string _ID;
    [Tooltip("Item's in-game name")]
    public string _Name;
    public string ID { get { return _ID; } private set { _ID = value; } }
    public bool isUnlocked { get; set; }
    public string Name { get { return _Name; } private set { _Name = value; } }

    private void OnValidate()
    {
        Name = _Name;
        ID = _ID;
    }

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
