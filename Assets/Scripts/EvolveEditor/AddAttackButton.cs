using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddAttackButton : MonoBehaviour
{
    [SerializeField] AttackEvolve evolve;
    [SerializeField] Player player;
    
    char evolveType;
    int evolveID;
    const string attackEvolveName = "AttackEvolve";

    private void Awake()
    {
        evolveType = evolve.ID[0];
        evolveID = int.Parse(evolve.ID.Substring(1));
    }

    public void OnClick()
    {
        GameObject evolveComponent = player.transform.Find(attackEvolveName).gameObject;
        SpriteRenderer spriteRenderer = evolveComponent.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = evolve.evolveData.displaySprite;
        //Debug.Log(GameManager.instance);
        GameManager.instance.attachedAttackEvolve = evolve;
    }
}
