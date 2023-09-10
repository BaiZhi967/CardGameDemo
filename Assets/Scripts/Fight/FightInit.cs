using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
public class FightInit : FightUnit
{
    public override void Init()
    {
        
        AudioManager.Instance.PlayBGM("battle");
        UIManager.Instance.ShowUI<ChooseUI>("ChooseUI").Show();




    }

    public override void OnUpdate()
    {

    }
}
