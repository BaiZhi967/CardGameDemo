using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGetPower : EnemyAction
{
    public override void TackAction()
    {
        base.TackAction();
        string[] val = data["Arg"].Split("/");
        enemy.GetComponent<Enemy>().CurPow += int.Parse(val[0]);
    }
}
