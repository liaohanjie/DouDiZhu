using UnityEngine;
using System.Collections;

public class PlayerManager {

    public static PlayerManager Instance = new PlayerManager();
    private PlayerInfo[] playerInfos = new PlayerInfo[3];
    private PlayerInfo localPlayer = new PlayerInfo();
    private PlayerManager() { }
    public void RandomPlayer()
    {
        for(int i = 0;i < playerInfos.Length; i++)
        {
            PlayerInfo playerInfo = new PlayerInfo();
            playerInfo.PlayerName = "玩家-" + (i+ 1);
            playerInfo.PlayerId = (i + 1);
            playerInfo.Icon = "gameHead";
            AddPlayerInfo(playerInfo);
        }
    }

    public void AddPlayerInfo(PlayerInfo playerInfo)
    {
        for(int i = 0;i < playerInfos.Length; i++)
        {
            if(playerInfos[i] == null)
            {
                playerInfos[i] = playerInfo;
                playerInfos[i].PlayerPos = i + 1;
                break;
            }
        }
    }

    public PlayerInfo getPlayerInfo(long playerId)
    {
        foreach(PlayerInfo playerInfo in playerInfos)
        {
            if(playerInfo != null && playerInfo.PlayerId == playerId)
            {
                return playerInfo;
            }
        }
        return null;
    }

    public PlayerInfo getPlayerInfoByPos(int pos)
    {
        return playerInfos[pos - 1];
    }
    
    public PlayerInfo[] getPlayerInfos()
    {
        return playerInfos;
    }  


}


