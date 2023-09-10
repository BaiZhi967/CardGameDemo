using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAttack : EnemyAction
{
    public override void TackAction()
    {
        base.TackAction();
        FightManager.Instance.GetPlayerHit(int.Parse(data["Arg"]));
    }
}
