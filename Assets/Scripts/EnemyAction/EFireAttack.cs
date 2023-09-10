using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EFireAttack : EnemyAction
{
    public override void TackAction()
    {
        base.TackAction();
        string[] val = data["Arg"].Split("/");
        if (!FightManager.Instance.gameObject.GetComponent<FireNorBuff>())
        {
            FightManager.Instance.gameObject.AddComponent<FireNorBuff>().Init(int.Parse(val[0]),int.Parse(val[1]));
        }
        else
        {
            FightManager.Instance.gameObject.AddComponent<FireNorBuff>().AddTime(
                int.Parse(val[1]));
        }
    }
}
