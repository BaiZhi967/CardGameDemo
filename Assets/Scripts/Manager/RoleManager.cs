using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoleManager
{
    public static RoleManager Instance = new RoleManager();
    public List<string> cardList; //ÓµÓÐµÄ¿¨ÅÆid
    public UseACard useCard;

    public void Init()
    {
        useCard = Object.Instantiate(Resources.Load("Events/OnUseCard")) as UseACard; 
        
        useCard.OnEventRaised += OnUseCard;

        cardList = new List<string>();
        for(int i = 0; i < 4; ++i)
        {
            cardList.Add("1001");
            cardList.Add("1003");
            if(i%2==0) cardList.Add("1002");
        }
    }

    public void OnUseCard(CardItem card)
    {
        Debug.Log(card.data["Name"]);
    }
}
