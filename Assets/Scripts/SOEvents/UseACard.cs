using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Event/UseACardEventSO")]
public class UseACard : ScriptableObject
{
    public UnityEngine.Events.UnityAction<CardItem> OnEventRaised;

    public void RaisedEvent(CardItem cardItem)
    {
        OnEventRaised?.Invoke(cardItem);
    }
}
