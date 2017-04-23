using UnityEngine;
using System.Collections.Generic;

public class RoomManager {

    private static RoomManager instance = new RoomManager();

  

    //最后的三张牌
    private int[] lastCards = new int[3];

    private CardsManager cardsManager = CardsManager.Instance();
    private const int totalPlayerCount = 3;
    //房间中的用户
    private PlayerInfo[] playerArr = new PlayerInfo[totalPlayerCount];
    private PlayerInfo nowPlayerInfo = null;
    public static RoomManager Instance()
    {
        return instance;
    }

    public int[] LastCards {
        get; set;
    }
    /// <summary>
    /// 分发牌
    /// </summary>
   public void AssignCards()
    {

        cardsManager.initCards();
        cardsManager.RefreshCards();
        int[] allCards = cardsManager.getAllCards();
        int cardsCount = allCards.Length - 3;
        int firstPlayer = Random.Range(0, 2);
        for (int i = 0; i < cardsCount; i++)
        {
            PlayerInfo player = playerArr[firstPlayer];
            player.addCard(allCards[i]);
            firstPlayer++;
            if (firstPlayer == totalPlayerCount)
            {
                firstPlayer = 0;
            }
        }
        lastCards[0] = allCards[51];
        lastCards[1] = allCards[52];
        lastCards[2] = allCards[53];
    }

    public void initPlayer()
    {
        
        for(int i = 0;i < totalPlayerCount;i++)
        {
            PlayerInfo playerInfo = new PlayerInfo(i,i);
            playerArr[i] = playerInfo;
        }
        nowPlayerInfo = playerArr[0];
    }

    public PlayerInfo GetNowPlayerInfo()
    {
        return nowPlayerInfo;
    }


   public void SetNextPlayerInfo()
    {
        int pos = nowPlayerInfo.getPlayerPos();
        pos++;
        nowPlayerInfo = playerArr[pos];
    }





}
