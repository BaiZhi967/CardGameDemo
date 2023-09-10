using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PerceptionCard : CardItem
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (TryUse() == true)
        {
            int val = int.Parse(vals[0]);
            AudioManager.Instance.PlayEffect("Effect/sword");
            FightManager.Instance.CurHp = Mathf.Min(FightManager.Instance.MaxHp, FightManager.Instance.CurHp + EnemyManager.Instacne.enemyList.Count * int.Parse(vals[1]));
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateHP();
            for (int i = 0; i < EnemyManager.Instacne.enemyList.Count; ++i)
            {
                EnemyManager.Instacne.enemyList[i].Hit(val);
            }
            
            Vector3 pos = Camera.main.transform.position;
            pos.y = 0;
            PlayEffect(pos);
        }
        else
        {
            base.OnEndDrag(eventData);
        }
    }
}
