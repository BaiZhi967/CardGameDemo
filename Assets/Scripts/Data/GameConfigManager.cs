using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigManager 
{
    public static GameConfigManager Instance = new GameConfigManager();
    private GameConfigData cardData;
    private GameConfigData enemyData;
    private GameConfigData levelData;
    private GameConfigData cardTypeData;
    private GameConfigData enemyActionData;
    private TextAsset textAsset;
    

    public void Init()
    {
        textAsset = Resources.Load<TextAsset>("Data/card");
        cardData = new GameConfigData(textAsset.text);

        textAsset = Resources.Load<TextAsset>("Data/enemy");
        enemyData = new GameConfigData(textAsset.text);

        textAsset = Resources.Load<TextAsset>("Data/level");
        levelData = new GameConfigData(textAsset.text);

        textAsset = Resources.Load<TextAsset>("Data/cardType");
        cardTypeData = new GameConfigData(textAsset.text);

        textAsset = Resources.Load<TextAsset>("Data/enemyAction");
        enemyActionData = new GameConfigData(textAsset.text);
    }

    public List<Dictionary<string,string>> GetCardLines()
    {
        return cardData.GetLines();
    }
    public List<Dictionary<string, string>> GetEnemyLines()
    {
        return enemyData.GetLines();
    }
    public List<Dictionary<string, string>> GetLevelLines()
    {
        return levelData.GetLines();
    }
    public List<Dictionary<string, string>> GetCardTypeLines()
    {
        return cardTypeData.GetLines();
    }
    public List<Dictionary<string, string>> GetEnemyActionLines()
    {
        return enemyActionData.GetLines();
    }
    public Dictionary<string,string> GetCardById(string id)
    {
        return cardData.GetOneById(id);
    }
    public Dictionary<string, string> GetEnemyById(string id)
    {
        return enemyData.GetOneById(id);
    }
    public Dictionary<string, string> GetLevelById(string id)
    {
        return levelData.GetOneById(id);
    }
    public Dictionary<string, string> GetCardTypeById(string id)
    {
        return cardTypeData.GetOneById(id);
    }
    public Dictionary<string, string> GetEnemyActionById(string id)
    {
        return enemyActionData.GetOneById(id);
    }
}
