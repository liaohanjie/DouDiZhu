using UnityEngine;
using System.Collections.Generic;

public class UIPlayerManager  {

    private static UIPlayerManager instance = new UIPlayerManager();



    private Dictionary<long, UIPlayerInfo> uiPlayerDic = new Dictionary<long, UIPlayerInfo>();

    private UIPlayerManager() { }

    public static UIPlayerManager getInstsance()
    {
        return instance;
    }

    public void addUIPlayerInfo(UIPlayerInfo uiPlayerInfo)
    {
        uiPlayerDic.Add(uiPlayerInfo.PlayerId, uiPlayerInfo);

    }

    public UIPlayerInfo getUIPlayerInfo(long playerId)
    {
        UIPlayerInfo playerInfo =  null;
        uiPlayerDic.TryGetValue(playerId, out playerInfo);
        if(playerInfo == null)
        {
            playerInfo = new UIPlayerInfo(playerId);
            uiPlayerDic.Add(playerId, playerInfo);
        }
        return playerInfo;
    }
}
