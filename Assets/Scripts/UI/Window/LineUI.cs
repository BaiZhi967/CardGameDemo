using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LineUI : UIBase
{
    

    public void SetStartPos(Vector2 pos)
    {
        transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = pos;
    }
    public void SetEndPos(Vector2 pos)
    {
        transform.GetChild(transform.childCount -1).GetComponent<RectTransform>().anchoredPosition = pos;

        Vector3 startPos = transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition;
        Vector3 endPos = pos;
        Vector3 midPos = Vector3.zero;
        midPos.y = (startPos.y + endPos.y) / 2;
        midPos.x = startPos.x;
        Vector3 dir = (endPos - startPos).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.GetChild(transform.childCount - 1).eulerAngles = new Vector3(0, 0, angle);

        for(int i = transform.childCount - 1; i >= 0; i--)
        {
            transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = GetBezier(startPos, midPos, endPos, i / (float)transform.childCount);
            if (i != transform.childCount - 1)
            {
                dir = (transform.GetChild(i + 1).GetComponent<RectTransform>().anchoredPosition - transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition).normalized;
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.GetChild(i).eulerAngles = new Vector3(0, 0, angle-90);
            }
        }

    }

    public Vector3 GetBezier(Vector3 start,Vector3 mid,Vector3 end,float t)
    {
        return (1f - t) * (1f - t) * start + 2f * t * (1f - t) * mid + t * t * end;
    }
}
