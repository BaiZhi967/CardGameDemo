using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtAddDefence : MonoBehaviour
{
    public int val;
    
    public void addDefence()
    {
        gameObject.GetComponent<Enemy>().Defend += val;
        gameObject.GetComponent<Enemy>().UpdateDefend();
    }
}
