using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlueSumCard : CardItem
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (TryUse() == true)
        {
            int val = int.Parse(vals[0]);
            AudioManager.Instance.PlayEffect("Effect/sword");

            for (int i = 0; i < EnemyManager.Instacne.enemyList.Count; ++i)
            {
                Enemy hitEnemy = EnemyManager.Instacne.enemyList[i];
                if (hitEnemy.Defend + hitEnemy.CurHp > val)
                {
                    if (!hitEnemy.gameObject.GetComponent<FireDebuff>())
                    {
                        hitEnemy.gameObject.AddComponent<FireDebuff>()
                            .Init(hitEnemy, int.Parse(vals[1]), int.Parse(vals[2]));

                    }
                }
                EnemyManager.Instacne.enemyList[i].Hit(val);

                
            }
            //useCard?.OnEventRaised(this);
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
