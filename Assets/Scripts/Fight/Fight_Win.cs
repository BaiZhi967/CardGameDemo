using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fight_Win : FightUnit
{
    public VoidEventSO gameEnd;
    public override void Init()
    {
        Debug.Log("You Win");
        gameEnd = Object.Instantiate(Resources.Load("Events/GameEnd")) as VoidEventSO; 
        
        gameEnd.RaisedEvent();

        FightManager.Instance.StopAllCoroutines();
        UIManager.Instance.GetUI<FightUI>("FightUI").RemoveAllCard();
        UIManager.Instance.Find("FightUI").Close();
        UIManager.Instance.ShowUI<VictoryUI>("VictoryUI");
        
    }

    public override void OnUpdate()
    {

    }
}
