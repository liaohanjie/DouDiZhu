using UnityEngine;
using System.Collections.Generic;

public class PlayerInfo  {
    private long playerId;
   
    private string playerName;
    private string icon;

    //玩家有里的牌
    private List<int> playerCards = new List<int>();
    //玩家的位置
    private int playerPos;
    //已出过的牌
    private List<GameObject> hadPlayCards = new List<GameObject>();

    //选择的牌
    private List<GameObject> selectedCards = new List<GameObject>();
    //是否准备
    private bool isReady = false;

    public void Ready()
    {
        isReady = true;
    }

    public bool IsReady()
    {
        return isReady;
    }
    public void addCard(int cards)
    {
        playerCards.Add(cards);
    }

    public void removeCard(int cardIndex)
    {
        playerCards.Remove(cardIndex);
    }
    /// <summary>
    /// 获取用户手中牌的个数
    /// </summary>
    /// <returns></returns>
    public int getCardsCount()
    {
        return playerCards.Count;
    }
    /// <summary>
    /// 获取用户手中所有的牌
    /// </summary>
    /// <returns></returns>
    public List<int> getCards()
    {
        return playerCards;
    }
    /// <summary>
    /// 获取用户的位置
    /// </summary>
    /// <returns></returns>
    public int PlayerPos
    {
        get { return playerPos; }
        set { playerPos = value; }
    }
    /// <summary>
    /// 选择一张牌
    /// </summary>
    /// <param name="go"></param>
    public void SelectCards(GameObject go)
    {
        hadPlayCards.Add(go);
    }

    public void RemoveCardsOfSelect(GameObject go)
    {
        hadPlayCards.Remove(go);
    }

    public void ClearHadPlayCards()
    {
        hadPlayCards.Clear();
    }


    public List<GameObject> getSelectCards()
    {
        return hadPlayCards;
    }
    /// <summary>
    /// 清理已选择的牌
    /// </summary>
    public void ResetSelectedCards()
    {
        selectedCards.Clear();
    }

    public long PlayerId {
        get {
            return playerId;
        }
        set {
            this.playerId = value;
        }
    }

    public string PlayerName
    {
        get
        {
            return playerName;
        }

        set
        {
            playerName = value;
        }
    }

    public string Icon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
        }
    }
}
