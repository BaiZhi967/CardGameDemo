using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DampDebuff : BaseBuff
{
    public Enemy enemy;
    



    public void Init(Enemy enemy)
    {
        this.enemy = enemy;
        curTime = 999999;
    }

    public void EndDamp()
    {
        Destroy(this);
    }
    
}
