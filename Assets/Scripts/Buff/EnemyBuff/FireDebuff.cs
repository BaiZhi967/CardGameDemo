using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireDebuff : BaseBuff
{
    public Enemy enemy;
    public int damage;

    public VoidEventSO onEnemyTurn;

    public void Init(Enemy enemy,int damage,int curTime)
    {
        this.enemy = enemy;
        this.damage = damage;
        this.curTime = curTime;
        onEnemyTurn = Object.Instantiate(Resources.Load("Events/OnEnemyTurn")) as VoidEventSO;
        
        onEnemyTurn.OnEventRaised += OnTrigger;
    }

    public override void OnTrigger()
    {
        enemy.Hit(damage);
        base.OnTrigger();
    }
}
