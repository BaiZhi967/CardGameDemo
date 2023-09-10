using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Transform canvasTf;
    private List<UIBase> uiList;

    private void Awake()
    {
        Instance = this;
        canvasTf = GameObject.Find("Canvas").transform;
        uiList = new List<UIBase>();
    }


    public UIBase ShowUI<T>(string uiName) where T: UIBase
    {
        UIBase ui = Find(uiName);
        if(ui == null)
        {
            GameObject obj =  Instantiate(Resources.Load("UI/" + uiName), canvasTf) as GameObject;
            obj.name = uiName;
            ui = obj.AddComponent<T>();
            uiList.Add(ui);
        }
        else
        {
            ui.Show();
        }

        return ui;
    }

    public void CloseAllUI()
    {
        for (int i = uiList.Count - 1;i>= 0; --i){
            Destroy(uiList[i].gameObject);
        }
        uiList.Clear();
        
    }

    public void HideUI(string uiName)
    {
        UIBase ui = Find(uiName);
        if (ui != null)
        {
            ui.Hide();
        }
    }

    public void CloseUI(string uiName)
    {
        UIBase ui = Find(uiName);
        if (ui != null)
        {
            uiList.Remove(ui);
            Destroy(ui.gameObject);
            
        }
    }

    public UIBase Find(string uiName)
    {
        for(int i = 0; i < uiList.Count; ++i)
        {
            if(uiList[i].name == uiName)
            {
                return uiList[i];
            }
        }
        return null;
    }

    public T GetUI<T>(string uiName) where T : UIBase
    {
        UIBase ui = Find(uiName);
        if (ui != null)
        {
            return ui.GetComponent<T>();
        }

        return null;
    }


    public GameObject CreateActionIcon()
    {
        GameObject obj = Instantiate(Resources.Load("UI/actionIcon"), canvasTf) as GameObject;
        obj.transform.SetAsFirstSibling();
        return obj;
    }
    public GameObject CreateHpItem()
    {
        GameObject obj = Instantiate(Resources.Load("UI/HpItem"), canvasTf) as GameObject;
        obj.transform.SetAsFirstSibling();
        return obj;
    }
    public void ShowTip(string msg,Color color,System.Action callback = null)
    {
        GameObject obj = Instantiate(Resources.Load("UI/Tips"), canvasTf) as GameObject;
        Text content = obj.transform.Find("bg/Text").GetComponent<Text>();
        content.text = msg;
        content.color = color;
        Tween scale1 = obj.transform.Find("bg").DOScale(1, 0.4f);
        Tween scale2 = obj.transform.Find("bg").DOScale(0, 0.4f);
        Sequence seq = DOTween.Sequence();
        seq.Append(scale1);
        seq.AppendInterval(0.5f);
        seq.Append(scale2);
        
        seq.AppendCallback(delegate ()
        {
            if (callback != null)
            {
                callback();
            }
        });
        MonoBehaviour.Destroy(obj, 2);
    }

    
}
