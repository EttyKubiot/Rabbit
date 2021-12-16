using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameEventListeners : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private UnityEvent response;

    private void OnEnable()
    {
        gameEvent.RegisterListeners(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListeners(this);
    }

    public void OnEventRaised()
    {
        response.Invoke();
    }
}
