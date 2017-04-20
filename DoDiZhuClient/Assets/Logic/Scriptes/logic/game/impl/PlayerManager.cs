using UnityEngine;
using System.Collections.Generic;

public class PlayerManager  {

    private static PlayerManager _instance = new PlayerManager();
    private List<PlayerInfo> playerList = null;
    private int playerCount = 3;
    private int playerId = 0;
    public static PlayerManager getInstance()
    {
        return _instance;
    }

    public void sendPlayerCards(int[] allCards)
    {
        playerList = new List<PlayerInfo>(playerCount);
        for(int i = 0;i < playerCount; i++)
        {
            PlayerInfo player = new PlayerInfo(i,i);
            playerList.Add(player);
        }
        int cardsCount = allCards.Length - 3;
        int firstPlayer = Random.Range(0,2);
        for(int i = 0;i < cardsCount; i++)
        {
            PlayerInfo player = playerList[firstPlayer];
            player.addCard(allCards[i]);
            firstPlayer++;
            if(firstPlayer == playerCount)
            {
                firstPlayer = 0;
            }
        }

  
       
    }

    public PlayerInfo getPlayerInfo(int playerId)
    {
        foreach(PlayerInfo playerInfo in playerList)
        {
            if(playerInfo.PlayerId == playerId)
            {
                return playerInfo;
            }
        }
        return null;
    }

  

    public PlayerInfo getNowPlayerInfo()
    {
        return getPlayerInfo(playerId);
    }

    
}
