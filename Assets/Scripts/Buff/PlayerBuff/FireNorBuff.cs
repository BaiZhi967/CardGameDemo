using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireNorBuff : BaseBuff
{
    public int damage;
    public VoidEventSO gameEnd;
    public VoidEventSO onPlayerTurn;
    public void Init(int damage,int curTime)
    {
        this.damage = damage;
        this.curTime = curTime;
        gameEnd = Object.Instantiate(Resources.Load("Events/GameEnd")) as VoidEventSO; 
        
        onPlayerTurn = Object.Instantiate(Resources.Load("Events/OnPlayerTurn")) as VoidEventSO; 
        
        gameEnd.OnEventRaised += EndBuff;
        onPlayerTurn.OnEventRaised += OnTrigger;
    }

    public override void OnTrigger()
    {
        FightManager.Instance.GetPlayerHit(damage);
        base.OnTrigger();
    }

    public void AddTime(int t)
    {
        curTime += t;
    }

}
