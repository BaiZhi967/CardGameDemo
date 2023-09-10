using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PoisonDebuff : BaseBuff
{
    public Enemy enemy;
    public int damage;

    public VoidEventSO onEnemyTurn;

    public void Init(Enemy enemy, int damage)
    {
        this.enemy = enemy;
        this.damage = damage;
        onEnemyTurn = Object.Instantiate(Resources.Load("Events/OnEnemyTurn")) as VoidEventSO; 
        
        onEnemyTurn.OnEventRaised += OnTrigger;
    }
    public void AddDamage(int damage) {
        this.damage += damage;
    }

    public override void OnTrigger()
    {
        enemy.Hit(damage);
        damage--;
        if(damage <= 0)
        {
            EndBuff();
        }
    }
}
