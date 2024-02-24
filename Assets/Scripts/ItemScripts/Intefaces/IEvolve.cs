using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to define how different game objects are attached to the player.
/// </summary>
public interface IEvolve
{
    public bool isUnlocked { get; set; }
    /// <summary>
    /// Id is a letter (A,D,M), and a number.
    /// </summary>
    public string ID { get;}
    /// <summary>
    /// Name of the item
    /// </summary>
    public string Name { get;}
    /// <summary>
    /// Attaches the evolve to the game_object
    /// </summary>
    /// <param name="gameObject"></param>
    public void Attach(GameObject game_object);

    /// <summary>
    /// Action, that is going to be based on the type of the evolve
    /// </summary>
    public void Action();
}
