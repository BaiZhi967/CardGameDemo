using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HurtAttack : MonoBehaviour
{
    public bool canAttack;
    public VoidEventSO onPlayerTurn;

    public void Start()
    {
        onPlayerTurn = Object.Instantiate(Resources.Load("Events/OnPlayerTurn")) as VoidEventSO;
        
        onPlayerTurn.OnEventRaised += TurnInit;
    }

    public void TurnInit()
    {
        canAttack = true;
    }

    public void ReHurt(int val)
    {
        if (!canAttack)
        {
            return;
        }
        FightManager.Instance.GetPlayerHit(val);
    }
}
