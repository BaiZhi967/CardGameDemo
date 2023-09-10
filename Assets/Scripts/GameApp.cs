using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ÓÎÏ·Èë¿Ú
public class GameApp : MonoBehaviour
{
    
    void Start()
    {
        GameConfigManager.Instance.Init();
        AudioManager.Instance.Init();
        RoleManager.Instance.Init();
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");

        FightCardManager.Instance.Init();
        
        AudioManager.Instance.PlayBGM("bgm1");
        //string name = GameConfigManager.Instance.GetCardById("1001")["Name"];
        //Debug.Log(name);
        //TestFuntion();
    }

    public void TestFuntion()
    {
        string str1 = "{0},xxx{1}";
        string str2 = "55/566";
        Debug.Log(string.Format(str1, str2.Split("/")));
    }
   
}
