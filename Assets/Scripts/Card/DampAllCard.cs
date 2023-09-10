using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DampAllCard : CardItem
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        if (TryUse() == true)
        {
            
            AudioManager.Instance.PlayEffect("Effect/sword");

            for (int i = 0; i < EnemyManager.Instacne.enemyList.Count; ++i)
            {
                Enemy hitEnemy = EnemyManager.Instacne.enemyList[i];
                if (!hitEnemy.gameObject.GetComponent<DampDebuff>())
                {
                    hitEnemy.gameObject.AddComponent<DampDebuff>()
                        .Init(hitEnemy);

                }
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
