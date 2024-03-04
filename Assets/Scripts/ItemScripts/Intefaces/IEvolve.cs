using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: THINK ABOUT REFACTORING ITEM SYSTEM!!!!
/// <summary>
/// Used to define how different game objects are attached to the player.
/// </summary>
public interface IEvolve
{
    public string ID { get;}
    /// <summary>
    /// Name of the item
    /// </summary>
    public string Name { get;}
}
