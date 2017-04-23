using UnityEngine;
using System.Collections.Generic;

public class PlayerInfo  {
    private long playerId;
    //玩家的位置
    private int playerPos;
    //玩家有里的牌
    private List<int> playerCards;
   

    public int CurrentPlayCardIndex
    {
        get;set;
    }
    public long PlayerId {
        get {
            return playerId;
        }
        set {
            this.playerId = value;
        }
    }

    public PlayerInfo(long playerId,int playerPos)
    {
        this.playerPos = playerPos;
        this.playerId = playerId;
        playerCards = new List<int>();
    }

    public void addCard(int cards)
    {
        playerCards.Add(cards);
    }

    public void removeCard(int cardIndex)
    {
        playerCards.Remove(cardIndex);
    }

    public int getCardsCount()
    {
        return playerCards.Count;
    }

    public List<int> getCards()
    {
        return playerCards;
    }

    public int getPlayerPos()
    {
        return playerPos;
    }
    

}
