using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEditor;

public class CardItem : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Dictionary<string, string> data;
    public UseACard useCard;
    public string[] vals;
    public UseACard useCardEvent;

    public void Init(Dictionary<string,string> data)
    {
        this.data = data;
        useCard = Object.Instantiate(Resources.Load("Events/OnUseCard")) as UseACard; 
        
    }
    private int index;

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.3f, 0.25f);
        //transform.position  = new Vector3(transform.position.x, transform.position.y+45, transform.position.z);
        index = transform.GetSiblingIndex();
        transform.SetAsLastSibling();
        transform.Find("bg").GetComponent<Image>().material.SetColor("_lineColor", Color.yellow);
        transform.Find("bg").GetComponent<Image>().material.SetFloat("_lineWidth", 10);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1, 0.25f);
        //transform.position = new Vector3(transform.position.x, transform.position.y - 45, transform.position.z);

        transform.SetSiblingIndex(index);
        transform.Find("bg").GetComponent<Image>().material.SetColor("_lineColor", Color.black);
        transform.Find("bg").GetComponent<Image>().material.SetFloat("_lineWidth", 1);
    }

    private void Start()
    {
        vals = data["Arg"].Split("/");
        transform.Find("bg").GetComponent<Image>().sprite = Resources.Load<Sprite>(data["BgIcon"]);
        transform.Find("bg/icon").GetComponent<Image>().sprite = Resources.Load<Sprite>(data["Icon"]);
        transform.Find("bg/msgTxt").GetComponent<Text>().text = string.Format(data["Des"],vals);
        transform.Find("bg/nameTxt").GetComponent<Text>().text = data["Name"];
        transform.Find("bg/useTxt").GetComponent<Text>().text = data["Expend"];
        transform.Find("bg/Text").GetComponent<Text>().text = GameConfigManager.Instance.GetCardTypeById(data["Type"])["Name"];

        transform.Find("bg").GetComponent<Image>().material = Instantiate(Resources.Load<Material>("Mats/outline"));

        useCardEvent = Object.Instantiate(Resources.Load("Events/OnUseCard")) as UseACard; 
       



    }

    Vector2 initPos;

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        initPos = transform.GetComponent<RectTransform>().anchoredPosition;
        AudioManager.Instance.PlayEffect("Cards/draw");
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(),eventData.position,eventData.pressEventCamera,out pos)){
            transform.GetComponent<RectTransform>().anchoredPosition = pos;
        }
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        transform.GetComponent<RectTransform>().anchoredPosition = initPos;
        transform.SetSiblingIndex(index);
    }


    public virtual bool TryUse()
    {
        int cost = int.Parse(data["Expend"]);
        if (cost > FightManager.Instance.CurPowerCount)
        {
            AudioManager.Instance.PlayEffect("Effect/lose");

            UIManager.Instance.ShowTip("·ÑÓÃ²»×ã",Color.red);

            return false;
        }
        else
        {
            FightManager.Instance.CurPowerCount -= cost;
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdataPower();
            UIManager.Instance.GetUI<FightUI>("FightUI").RemoveCard(this);
            return true;

        }
    }

    public void PlayEffect(Vector3 pos)
    {
        GameObject effectObj = Instantiate(Resources.Load(data["Effects"])) as GameObject;
        effectObj.transform.position = pos;
        Destroy(effectObj, 2);

    }
    

}
