using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DefendAndDrawCard : CardItem
{

    public override void OnEndDrag(PointerEventData eventData)
    {
        if (TryUse() == true)
        {
            int val = int.Parse(vals[0]);
            AudioManager.Instance.PlayEffect("Effect/healspell");

            FightManager.Instance.DefenseCount += val;
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdataDefense();
            Vector3 pos = Camera.main.transform.position;
            pos.y = 0;
            PlayEffect(pos);
            val = int.Parse(vals[1]);
            if (FightCardManager.Instance.HasCard() == true)
            {
                UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(val);
                UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardItemPos();
                pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2.5f));
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
            }
            //useCard?.OnEventRaised(this);
        }
        else
        {
            base.OnEndDrag(eventData);
        }
    }
}
