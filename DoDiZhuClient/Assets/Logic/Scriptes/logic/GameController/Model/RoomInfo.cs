using UnityEngine;
using System.Collections;

public class RoomInfo {

    private static RoomInfo instance = new RoomInfo();

    private const int playerCount = 3;
    private const int dizhuCardCount = 3;
    //房间号id
    private long roomId;
    //此房间中的玩家
    private PlayerInfo[] playerInfos;
    //本局叫的分数
    private int score;
    //最后三张地主牌
    private int[] dizhuCards;
    //地主的playerId
    private long dizhuPlayerId;

    public static RoomInfo Instance()
    {
        return instance;
    }
    public long RoomId
    {
        get
        {
            return roomId;
        }

        set
        {
            roomId = value;
        }
    }

    public PlayerInfo[] PlayerInfos
    {
        get
        {
            if(playerInfos == null)
            {
                playerInfos = new PlayerInfo[playerCount];
            }
            return playerInfos;
        }

        set
        {
            playerInfos = value;
        }
    }

    public static int PlayerCount
    {
        get
        {
            return playerCount;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    public int[] DizhuCards
    {
        get
        {
            if(dizhuCards == null)
            {
                dizhuCards = new int[dizhuCardCount];
            }
            return dizhuCards;
        }

        set
        {
            dizhuCards = value;
        }
    }

    public long DizhuPlayerId
    {
        get
        {
            return dizhuPlayerId;
        }

        set
        {
            dizhuPlayerId = value;
        }
    }

    public static int DizhuCardCount
    {
        get
        {
            return dizhuCardCount;
        }
    }
}
