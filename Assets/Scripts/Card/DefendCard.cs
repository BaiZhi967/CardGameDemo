using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DefendCard : CardItem
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
            //useCard?.OnEventRaised(this);
        }
        else
        {
            base.OnEndDrag(eventData);
        }
    }
}
