using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 界面基类
/// </summary>
public class UIBase : MonoBehaviour
{
    
    public UIEventTrigger Register(string name) {
        
        Transform tf =  transform.Find(name);
        return UIEventTrigger.Get(tf.gameObject);
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
    public virtual void Close()
    {
        UIManager.Instance.CloseUI(gameObject.name);
    }
}
