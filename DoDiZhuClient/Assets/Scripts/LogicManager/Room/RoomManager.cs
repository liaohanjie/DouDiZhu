using System.Collections;
using System.Collections.Generic;

public class RoomManager  {

    private PlayerPlayInfo player1;
    private PlayerPlayInfo player2;
    private PlayerPlayInfo player3;

    private PlayCommonInfo playCommonInfo;

    public void ResetRoom()
    {
        player1 = null;
        player2 = null;
        player3 = null;
        playCommonInfo = null;
    }
    /// <summary>
    /// 向房间中添加用户
    /// </summary>
    /// <param name="player"></param>
    public void AddPlayer(Player player)
    {
        if(player1 == null)
        {
            player1 = new PlayerPlayInfo();
            player1.Player = player;
            player1.Pos = 1;
        } else if(player2 == null)
        {
            player2 = new PlayerPlayInfo();
            player2.Player = player;
            player2.Pos = 2;
        } else if(player3 == null)
        {
            player3 = new PlayerPlayInfo();
            player3.Player = player;
            player3.Pos = 3;
        }

    }
    /// <summary>
    /// 给房间中的用户发牌
    /// </summary>
    public  void SendCard()
    {
       CardsManager cardManager = CardsManager.Instance();
        cardManager.RefreshCards();
        int[] allCards = cardManager.getAllCards();
        int playerIndex = 0;
        int count = 0;
        int i = 51;
        foreach (int cardIndex in allCards)
        {
            if(playerIndex == 1)
            {
                player1.Cards.Add(cardIndex);
            } else if(playerIndex == 2)
            {
                player2.Cards.Add(cardIndex);
            } else if(playerIndex == 3)
            {
                player2.Cards.Add(cardIndex);
                playerIndex = 1;
            }
            playerIndex++;
            count++;
            if (count == i)
            {
                break;
            }
        }
        //最后三张做为地主牌
       for(; i < 54; i++)
        {
            playCommonInfo.DizhuCard.Add(allCards[i]);
        }
       
    }

    /// <summary>
    /// 记录玩家叫的分数
    /// </summary>
    /// <param name="score"></param>
    /// <param name="pos"></param>
   public void RecordCallScore(int score)
    {
        playCommonInfo.Score = score;
    }
    /// <summary>
    /// 记录下地主
    /// </summary>
    /// <param name="pos"></param>
    public void RecordDiZhu(int pos)
    {
       if(pos == 1)
        {
            player1.IsDiZhu = true;
        } else if(pos == 2)
        {
            player2.IsDiZhu = true;
        } else if(pos == 3)
        {
            player3.IsDiZhu = true;
        } else {
            NGUIDebug.Log("不存在的位置类型：" + pos);
        }
    }



}
