using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BaseBuff : MonoBehaviour
{
    public int curTime;

    
    
    public virtual void OnTrigger()
    {
        curTime--;
        if (curTime <= 0)
        {
            EndBuff();
        }
    }

    public virtual void EndBuff()
    {
        Destroy(this);
    }
}
