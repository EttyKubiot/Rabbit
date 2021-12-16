using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event", order = 52)]


public class GameEvent : ScriptableObject
{
    private List<GameEventListeners> listeners = new List<GameEventListeners>();

    public void RegisterListeners(GameEventListeners listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListeners(GameEventListeners listener)
    {
        listeners.Remove(listener);
    }

    public void Raise()
    {

        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised();
        }

    }
}
