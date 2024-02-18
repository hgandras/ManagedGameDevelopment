using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddEvolveButton : MonoBehaviour
{
    [SerializeField] string buttonID;
    [SerializeField] GameEvent playerItemChanged;

    char evolveType;
    int evolveID;

    private void Awake()
    {
        evolveType = buttonID[0];
        evolveID = int.Parse(buttonID.Substring(1));
    }

    public void OnClick(Player player)
    {
        player.AddItemToPlayer(evolveType, evolveID);
    }
}
