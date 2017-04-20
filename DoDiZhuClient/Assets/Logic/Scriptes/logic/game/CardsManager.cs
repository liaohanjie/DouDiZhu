﻿using UnityEngine;
using System.Collections.Generic;

public class CardsManager  {
    private static CardsManager _instance = new CardsManager();
    private int[] allCards = null;
    private int totalCardsCount = 54;
    public static CardsManager Instance()
    {
        return _instance;
    }

    public void initCards()
    {
  
        allCards = new int[totalCardsCount];
        //大小王
        allCards[0] =  16;
        allCards[1] =  17;
        int index = 2;
        for (int i = 1;i< 5; i++)
        {
            for(int j = 3;j < 16; j++)
            {
                int cardsIndex = i * 100 + j;
                allCards[index] =  cardsIndex;
                index++;
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
                int temp = allCards[first];
                allCards[first] = allCards[second];
                allCards[second] = temp;
            }
        }
    }

    public int[] getAllCards()
    {
        return allCards;
    }


	
}
