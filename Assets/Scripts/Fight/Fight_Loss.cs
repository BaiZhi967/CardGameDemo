using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_Loss : FightUnit
{
    public override void Init()
    {
        Debug.Log("game over");
        FightManager.Instance.StopAllCoroutines();
        EnemyManager.Instacne.Init();
        UIManager.Instance.CloseAllUI();
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");
        

    }

    public override void OnUpdate()
    {

    }
}
