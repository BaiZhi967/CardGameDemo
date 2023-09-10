using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum ActionType
{
    None,Defend,Attack,
}

/// <summary>
/// 敌人脚本
/// </summary>
public class Enemy : MonoBehaviour
{

    public Dictionary<string, string> data;
    public ActionType type;
    public GameObject hpItemObj;
    public GameObject actionObj;

    


    public List<string> actions;

    [Header("UI")]
    public Transform attackTf;
    public Transform defendTf;
    public Text defendTxt;
    public Text hpTex;
    public Image hpImg;

    [Header("数值")]
    public int Defend;
    public int Attack;
    public int MaxHp;
    public int CurHp;
    public int CurPow;
    public int MaxPow;

    SkinnedMeshRenderer _meshRenderer;
    public Animator ani;


    public void Init(Dictionary<string,string> data)
    {
        this.data = data;
        actions = new List<string>();
        InitAction();

    }

    private void Start()
    {
        _meshRenderer = transform.GetComponentInChildren<SkinnedMeshRenderer>();
       

        type = ActionType.None;
        hpItemObj = UIManager.Instance.CreateHpItem();
        actionObj = UIManager.Instance.CreateActionIcon();

        attackTf = actionObj.transform.Find("attack");
        defendTf = actionObj.transform.Find("defend");

        defendTxt = hpItemObj.transform.Find("fangyu/Text").GetComponent<Text>();
        hpTex = hpItemObj.transform.Find("moneyTxt").GetComponent<Text>();
        hpImg = hpItemObj.transform.Find("fill").GetComponent<Image>();

        hpItemObj.transform.position = Camera.main.WorldToScreenPoint(transform.position+Vector3.down*0.2f);
        actionObj.transform.position = Camera.main.WorldToScreenPoint(transform.Find("head").position);

        ani = transform.GetComponent<Animator>();

        SetRandomAction();

        //初始化
        Attack = int.Parse(data["Attack"]);
        CurHp = int.Parse(data["Hp"]);
        MaxHp = CurHp;
        Defend = int.Parse(data["Defend"]);
        MaxPow = int.Parse(data["Pow"]);
        CurPow = MaxPow;
        UpdateHp();
        UpdateDefend();

        
    }

    public void SetRandomAction()
    {
        int ran = Random.Range(0, 3);
        if(CurPow == -1)
        {
            CurPow = 0;
        }
        else
        {
            CurPow = MaxPow;
        }
        
        type = (ActionType)ran;
        
    }


    public void UpdateHp()
    {
        hpTex.text = CurHp + "/" + MaxHp;
        hpImg.fillAmount = (float)CurHp / (float)MaxHp;
    }

    public void UpdateDefend()
    {
        defendTxt.text = Defend.ToString();
    }

    public void OnSelect()
    {
       // _meshRenderer.material.SetColor("_OtlColoer",Color.red);
    }
    public void OnUnSelect()
    {
       // _meshRenderer.material.SetColor("_OtlColoer", Color.black);
    }
    public void Hit(int val)
    {
        if (gameObject.GetComponent<HurtAddDefence>())
        {
            gameObject.GetComponent<HurtAddDefence>().addDefence();
            UpdateDefend();
        }

        if (Defend >= val)
        {
            Defend -= val;
            ani.Play("hit", 0, 0);
        }
        else
        {
            val = val - Defend;
            Defend = 0;
            CurHp -= val;
            if (CurHp <= 0)
            {
                CurHp = 0;
                //ani.Play("die");
                EnemyManager.Instacne.DeleteEnemy(this);
                MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();

                // 遍历每个脚本并删除
                foreach (MonoBehaviour script in scripts)
                {
                    Destroy(script);
                }

                Destroy(gameObject);
                Destroy(actionObj);
                Destroy(hpItemObj);
            }
            else
            {
                ani.Play("hit", 0, 0);
            }
        }
        UpdateDefend();
        UpdateHp();
    }

    public void HideAction()
    {
        attackTf.gameObject.SetActive(false);
        defendTf.gameObject.SetActive(false);
    }

    public IEnumerator DoAction()
    {
        HideAction();
        //ani.Play("attack");
        yield return new WaitForSeconds(0.5f);
        int doCount = 0;
        while (doCount <= 15 || actions.Count > 0)
        {
            
            string actionId = actions[0];
            
            Dictionary<string, string> data = GameConfigManager.Instance.GetEnemyActionById(actionId);
            int pow = int.Parse(data["Pow"]);
            if (pow > CurPow)
            {
                break;
            }
            actions.RemoveAt(0);
            if (data["Range"].Equals("0"))
            {
                actions.Add(actionId);
            }
            EnemyAction item = this.gameObject.AddComponent(System.Type.GetType(data["Script"])) as EnemyAction;
            
            item.Init(data, this.gameObject);
            item.TackAction();
            //yield return new WaitForSeconds(10);
            doCount++;
            CurPow -= pow;
            
            Destroy(item);
            yield return new WaitForSeconds(0.5f);
            
        }


        yield return new WaitForSeconds(1);
        //ani.Play("idle");
    }

    public void InitAction()
    {
        string[] actionList = data["EnemyAciton"].Split("/");
        for (int i = 0; i < actionList.Length; ++i)
        {
            //Debug.Log("Enemy:" + gameObject.name + "Add num" + i + " Action id " + actionList[i]);
            actions.Add(actionList[i]);
        }
    }
   
}
