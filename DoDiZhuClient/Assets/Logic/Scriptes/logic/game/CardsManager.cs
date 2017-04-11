using UnityEngine;
using System.Collections.Generic;

public class CardsManager  {
    private static CardsManager _instance = new CardsManager();
    private string[] allCards = null;
    public static CardsManager Instance()
    {
        return _instance;
    }

    public void initCards()
    {
        string preStr = "poker_";
        allCards = new string[54];
        allCards[0] = preStr + 0;
        allCards[1] = preStr + 1;
        int index = 2;
        for (int i = 1;i< 5; i++)
        {
            for(int j = 1;j < 14; j++)
            {
                allCards[index] =  preStr + ( i * 100 + j);
            }
        }
    }
    /// <summary>
    /// 洗牌,随机一百次，每次随机两个索引数，并交换它们对应的值的位置
    /// </summary>
    public void RefreshCards()
    {
        for(int i = 0;i < 100; i++)
        {
            int first = Random.Range(0,53);
            int second = Random.Range(0,53);

            if(first != second)
            {
                string temp = allCards[first];
                allCards[first] = allCards[second];
                allCards[second] = temp;
            }
        }
    }

    public string[] getAllCards()
    {
        return allCards;
    }


	
}
