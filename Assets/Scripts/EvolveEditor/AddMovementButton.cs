using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddMovementButton : MonoBehaviour
{
    [SerializeField] IEvolve evolve;
    [SerializeField] Player player;
    
    char evolveType;
    int evolveID;

    private void Awake()
    {
        evolveType = evolve.ID[0];
        evolveID = int.Parse(evolve.ID.Substring(1));
    }

    public void OnClick()
    {
        
        GameObject evolve = transform.Find(evolveType.ToString()).gameObject;
        SpriteRenderer spriteRenderer = evolve.GetComponent<SpriteRenderer>();
        //spriteRenderer.sprite = 
        //player.AddItemToPlayer(evolveType, evolveID);
    }
}
