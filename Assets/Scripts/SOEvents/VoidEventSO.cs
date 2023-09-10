using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Event/VoidEventSO")]
public class VoidEventSO : ScriptableObject
{
    public UnityEngine.Events.UnityAction OnEventRaised;

    public void RaisedEvent()
    {
        OnEventRaised?.Invoke();
    }
}
