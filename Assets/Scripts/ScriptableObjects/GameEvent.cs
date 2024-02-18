using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="GameEvent")]
public class GameEvent : ScriptableObject
{
    public List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise()
    {
        foreach(GameEventListener listener in listeners)
            listener.OnEventRaised();
    }

    public void Register(GameEventListener listener)
    {
        if(!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void Unregister(GameEventListener listener)
    {
        if(listeners.Contains(listener))
            listeners.Remove(listener);
    }
}
