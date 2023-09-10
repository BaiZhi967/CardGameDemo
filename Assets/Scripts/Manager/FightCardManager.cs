using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCardManager
{
    public static FightCardManager Instance = new FightCardManager();

    public List<string> cardList;//ÅÆ¶Ñ
    public List<string> usedCardList;//ÆúÅÆ¶Ñ

    public void Init()
    {
        cardList = new List<string>();
        usedCardList = new List<string>();


        //Ï´ÅÆ
        List<string> tmpList = new List<string>();
        tmpList.AddRange(RoleManager.Instance.cardList);
        while (tmpList.Count > 0)
        {
            int tmpIndex = Random.Range(0, tmpList.Count);
            cardList.Add(tmpList[tmpIndex]);
            tmpList.RemoveAt(tmpIndex);
        }

        Debug.Log(cardList.Count);
    }

    public void RefreahCard()
    {
        List<string> tmpList = new List<string>();
        tmpList.AddRange(usedCardList);
        tmpList.AddRange(cardList);
        cardList.Clear();
        usedCardList.Clear();
        while (tmpList.Count > 0)
        {
            int tmpIndex = Random.Range(0, tmpList.Count);
            cardList.Add(tmpList[tmpIndex]);
            tmpList.RemoveAt(tmpIndex);
        }
        UIManager.Instance.GetUI<FightUI>("FightUI").UpdataUsedCardCount();
        UIManager.Instance.GetUI<FightUI>("FightUI").UpdataCardCount();
    }


    public bool HasCard(int val = 0)
    {
        return cardList.Count > val;
    }

    public string DrawCard()
    {
        if (!HasCard())
            RefreahCard();

        string id = cardList[cardList.Count - 1];
        cardList.RemoveAt(cardList.Count - 1);
        return id;
    }
}
