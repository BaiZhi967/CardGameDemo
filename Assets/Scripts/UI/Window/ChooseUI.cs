using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public enum CUIBoxPos
{
    Left,Mid,Right
}
public class ChooseUI : UIBase
{
    public string[] val = new string[3];
    public string[] type = new string[3];
    private GameConfigData tmp;
    Dictionary<string, string> data;
    int index = 1;
    public void Init(string levelName)
    {
        TextAsset ta = Resources.Load<TextAsset>("Data/" + levelName);
        tmp = new GameConfigData(ta.text);
        Debug.Log(tmp.GetCount());
        data = tmp.GetOneById(index.ToString());
        SetChoose(CUIBoxPos.Left, data);
        index++;
        data = tmp.GetOneById(index.ToString());
        SetChoose(CUIBoxPos.Mid, data);
        index++;
        data = tmp.GetOneById(index.ToString());
        SetChoose(CUIBoxPos.Right, data);
        index++;
    }

    private void Awake()
    {
        Register("BoxL/EnterBtn").onClick = onEnterGameBtnL;
        Register("BoxM/EnterBtn").onClick = onEnterGameBtnM;
        Register("BoxR/EnterBtn").onClick = onEnterGameBtnR;

    }

    public void SetChoose(CUIBoxPos cbp, Dictionary<string, string> data)
    {
        string btmName = "";
        int index = 0;
        switch (cbp)
        {
            case CUIBoxPos.Left:
                btmName = "BoxL/";
                index = 0;
                break;
            case CUIBoxPos.Mid:
                btmName = "BoxM/";
                index = 1;
                break;
            case CUIBoxPos.Right:
                btmName = "BoxR/";
                index = 2;
                break;
        }
        //int ty = int.Parse(data["Type"]);
        this.type[index] = data["Type"];
        this.val[index] = data["Val"];
        if (this.type[index].Equals("0"))
        {
            
            transform.Find(btmName + "ExitBtn").gameObject.SetActive(false);
            transform.Find(btmName + "Name").gameObject.GetComponent<Text>().text = data["Name"];
            transform.Find(btmName + "Des").gameObject.GetComponent<Text>().text = data["Des"];
            transform.Find(btmName + "EnterBtn/EnterText").gameObject.GetComponent<Text>().text = data["Btn"];

        }
        else
        {
            transform.Find(btmName + "ExitBtn").gameObject.SetActive(true);
            transform.Find(btmName + "Name").gameObject.GetComponent<Text>().text = data["Name"];
            transform.Find(btmName + "Des").gameObject.GetComponent<Text>().text = data["Des"];
            transform.Find(btmName + "EnterBtn/EnterText").gameObject.GetComponent<Text>().text = data["Btn"];
        }
    }


    private void onEnterGameBtnL(GameObject obj, PointerEventData pData)
    {
        
        if (type[0].Equals("0"))
        {
            EnemyManager.Instacne.LoadRes(val[0]);

            UIManager.Instance.ShowUI<FightUI>("FightUI");

            FightManager.Instance.ChangeType(FightType.Player);
            transform.Find("BoxL").gameObject.SetActive(false);
            if (index <= tmp.GetCount())
            {
                SetChoose(CUIBoxPos.Left, tmp.GetOneById(index.ToString()));
                index++;
                transform.Find("BoxL").gameObject.SetActive(true);
            }
            Hide();
        }
        else if (type[0].Equals("1"))
        {
            FightManager.Instance.CurHp = Mathf.Min(FightManager.Instance.MaxHp, FightManager.Instance.CurHp + int.Parse(val[0]));
            transform.Find("BoxL").gameObject.SetActive(false);
            if (index <= tmp.GetCount())
            {
                SetChoose(CUIBoxPos.Left, tmp.GetOneById(index.ToString()));
                index++;
                transform.Find("BoxL").gameObject.SetActive(true);
            }
        }

    }
    private void onEnterGameBtnM(GameObject obj, PointerEventData pData)
    {
        
        if (type[1].Equals("0"))
        {
            EnemyManager.Instacne.LoadRes(val[1]);

            UIManager.Instance.ShowUI<FightUI>("FightUI");

            FightManager.Instance.ChangeType(FightType.Player);
            transform.Find("BoxM").gameObject.SetActive(false);
            if (index <= tmp.GetCount())
            {
                SetChoose(CUIBoxPos.Mid, tmp.GetOneById(index.ToString()));
                index++;
                transform.Find("BoxM").gameObject.SetActive(true);
            }
            Hide();
        }
        else if (type[1].Equals("1"))
        {
            FightManager.Instance.CurHp = Mathf.Min(FightManager.Instance.MaxHp, FightManager.Instance.CurHp + int.Parse(val[1]));
            transform.Find("BoxM").gameObject.SetActive(false);
            if (index <= tmp.GetCount())
            {
                SetChoose(CUIBoxPos.Mid, tmp.GetOneById(index.ToString()));
                index++;
                transform.Find("BoxM").gameObject.SetActive(true);
            }
        }


    }
    private void onEnterGameBtnR(GameObject obj, PointerEventData pData)
    {
        if (type[2].Equals("0"))
        {
            EnemyManager.Instacne.LoadRes(val[2]);

            UIManager.Instance.ShowUI<FightUI>("FightUI");

            FightManager.Instance.ChangeType(FightType.Player);
            transform.Find("BoxR").gameObject.SetActive(false);
            if (index <= tmp.GetCount())
            {
                SetChoose(CUIBoxPos.Right, tmp.GetOneById(index.ToString()));
                index++;
                transform.Find("BoxR").gameObject.SetActive(true);
            }
            Hide();
        }else if (type[2].Equals("1"))
        {
            FightManager.Instance.CurHp = Mathf.Min(FightManager.Instance.MaxHp, FightManager.Instance.CurHp + int.Parse(val[2]));
            transform.Find("BoxR").gameObject.SetActive(false);
            if (index <= tmp.GetCount())
            {
                SetChoose(CUIBoxPos.Right, tmp.GetOneById(index.ToString()));
                index++;
                transform.Find("BoxR").gameObject.SetActive(true);
            }
        }

    }


}
