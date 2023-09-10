using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fight_PlayerTurn : FightUnit
{
    public VoidEventSO onPlayerTurn;
    public override void Init()
    {
        onPlayerTurn =  Object.Instantiate(Resources.Load("Events/OnPlayerTurn")) as VoidEventSO;
        
        onPlayerTurn.RaisedEvent();
        Debug.Log("Player Time");
        UIManager.Instance.ShowTip("Player Turn", Color.green, delegate ()
        {

            FightManager.Instance.CurPowerCount = FightManager.Instance.MaxPowerCount;
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdataPower();

            if (FightCardManager.Instance.HasCard(4) == false)
            {
                FightCardManager.Instance.RefreahCard();
                UIManager.Instance.GetUI<FightUI>("FightUI").UpdataUsedCardCount();
            }

            Debug.Log("Draw");
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(4);
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardItemPos();
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdataCardCount();

        });
    }
    public override void OnUpdate()
    {

    }
    
}
