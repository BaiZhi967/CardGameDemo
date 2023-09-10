using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fight_EnemyTurn : FightUnit
{
    public VoidEventSO onEnemyTurn;

    public override void Init()
    {
        onEnemyTurn = Object.Instantiate(Resources.Load("Events/OnEnemyTurn")) as VoidEventSO; 
        
        onEnemyTurn.RaisedEvent();
        UIManager.Instance.GetUI<FightUI>("FightUI").RemoveAllCard();
        UIManager.Instance.ShowTip("Enemy Turn", Color.red, delegate ()
        {
            Debug.Log("π÷ŒÔ––∂Ø");
            FightManager.Instance.StartCoroutine(EnemyManager.Instacne.DoAllEnemyAction());
        });
    }

    public override void OnUpdate()
    {
        
    }
}
