using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerAndAddCard : CardItem
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (TryUse() == true)
        {
            FightManager.Instance.CurPowerCount += int.Parse(vals[0]);
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdataPower();
            int val = int.Parse(vals[1]);
            if (FightCardManager.Instance.HasCard(val) == true)
            {
                UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(val);
                UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardItemPos();
                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2.5f));
                PlayEffect(pos);
                UIManager.Instance.GetUI<FightUI>("FightUI").UpdataUsedCardCount();
                UIManager.Instance.GetUI<FightUI>("FightUI").UpdataCardCount();
            }
            else
            {
                base.OnEndDrag(eventData);
                FightCardManager.Instance.RefreahCard();
                UIManager.Instance.GetUI<FightUI>("FightUI").UpdataUsedCardCount();
                UIManager.Instance.GetUI<FightUI>("FightUI").UpdataCardCount();
                UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(val);
                UIManager.Instance.GetUI<FightUI>("FightUI").UpdataUsedCardCount();
                UIManager.Instance.GetUI<FightUI>("FightUI").UpdataCardCount();
            }
        }
        else
        {
            base.OnEndDrag(eventData);
        }

    }
}
