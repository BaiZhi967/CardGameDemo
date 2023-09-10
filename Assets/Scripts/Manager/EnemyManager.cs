using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 敌人管理
/// </summary>
public class EnemyManager
{
    public static EnemyManager Instacne = new EnemyManager();



    public List<Enemy> enemyList;

    public void Init()
    {
        for(int i = 0; i < enemyList.Count; ++i)
        {
            enemyList[i].Hit(99999999);
        }
        enemyList.Clear();
    }

    /// <summary>
    /// 加载敌人资源
    /// </summary>
    /// <param name="id">关卡ID</param>
    public void LoadRes(string id)
    {
        enemyList = new List<Enemy>();

        //关卡表
        Dictionary<string, string> levelData = GameConfigManager.Instance.GetLevelById(id);

        //敌人id
        string[] enemyIds = levelData["EnemyIds"].Split('=');

        //敌人位置
        string[] enemyPos = levelData["Pos"].Split('=');

        for(int i = 0; i < enemyIds.Length; ++i)
        {
            string enemyId = enemyIds[i];
            string[] posArr = enemyPos[i].Split(',');
            

            Vector3 pos = new Vector3(float.Parse(posArr[0]), float.Parse(posArr[1]), float.Parse(posArr[2]));

            Dictionary<string, string> enemyData = GameConfigManager.Instance.GetEnemyById(enemyId);

            GameObject obj = Object.Instantiate(Resources.Load(enemyData["Model"])) as GameObject;

            Enemy enemy = obj.AddComponent<Enemy>();
            enemy.Init(enemyData);
            enemyList.Add(enemy);

            obj.transform.position = pos;


        }

    }

    public void DeleteEnemy(Enemy enemy)
    {
        enemyList.Remove(enemy);
        if (enemyList.Count <= 0)
        {
            FightManager.Instance.ChangeType(FightType.Win);

        }
    }

    public IEnumerator DoAllEnemyAction()
    {
        for(int i = 0; i < enemyList.Count; ++i)
        {
            yield return FightManager.Instance.StartCoroutine(enemyList[i].DoAction());
        }
        for (int i = 0; i < enemyList.Count; ++i)
        {
            enemyList[i].SetRandomAction();
        }
        FightManager.Instance.ChangeType(FightType.Player);
    }

}
