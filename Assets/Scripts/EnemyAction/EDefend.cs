using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDefend : EnemyAction
{
    public override void TackAction()
    {
        
        base.TackAction();
        string[] val = data["Arg"].Split("/");
        enemy.GetComponent<Enemy>().Defend += int.Parse(val[0]);
        enemy.GetComponent<Enemy>().UpdateDefend();

    }
}
