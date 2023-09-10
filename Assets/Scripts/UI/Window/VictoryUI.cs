using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VictoryUI : UIBase
{
    public int card1;
    public int card2;
    private void Awake()
    {
        Register("continue").onClick = OnContinueGame;
        Register("card01").onClick = GetCard1;
        Register("card02").onClick = GetCard2;
        VictoryEvent();
    }

    private void VictoryEvent(int val = 30)
    {
        FightManager.Instance.Coin += val;
        card1 = Random.Range(1003, 1020);
        transform.Find("card01").GetComponent<Image>().sprite = Resources.Load<Sprite>(GameConfigManager.Instance.GetCardById(card1.ToString())["Icon"]);
        card2 = Random.Range(1003, 1020);
        transform.Find("card02").GetComponent<Image>().sprite = Resources.Load<Sprite>(GameConfigManager.Instance.GetCardById(card2.ToString())["Icon"]);
    }


    private void OnContinueGame(GameObject obj, PointerEventData pData)
    {
        Close();

        FightManager.Instance.ChangeType(FightType.Init);
    }

    public void GetCard1(GameObject obj, PointerEventData pData)
    {
        FightCardManager.Instance.cardList.Add(card1.ToString());
        Close();

        FightManager.Instance.ChangeType(FightType.Init);

    }
    public void GetCard2(GameObject obj, PointerEventData pData)
    {
        FightCardManager.Instance.cardList.Add(card2.ToString());
        Close();

        FightManager.Instance.ChangeType(FightType.Init);

    }
}
