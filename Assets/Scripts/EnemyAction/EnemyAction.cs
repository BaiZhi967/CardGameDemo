using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public int cost;
    public Dictionary<string, string> data;
    public GameObject enemy;
    
    public void Init(Dictionary<string, string> data, GameObject enemy)
    {
        this.data = data;
        this.enemy = enemy;
    }
    public virtual void TackAction()
    {
        PlayAnimation();
        Debug.Log(enemy.name + " do " + data["Name"]);
    }
    public virtual void PlayAnimation()
    {
        enemy.GetComponent<Animator>()?.Play("attack");
    }
}
