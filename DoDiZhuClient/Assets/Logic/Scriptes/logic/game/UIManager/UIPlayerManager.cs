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

    /// <summary>
    /// 当确定地主之后，给地主添加地主icon标记。
    /// </summary>
    /// <param name="playerId"></param>
    public void setDiZhuIcon(long playerId)
    {
        UIPlayerInfo playerInfo = getUIPlayerInfo(playerId);
        UISprite headSprite = playerInfo.HeadSprite;
        Transform iconPosObj = headSprite.transform.Find("IconPos").transform;
        UISprite iconSprite = NGUITools.AddSprite(headSprite.gameObject, UIRoomController.Instance.getPublicAtlas(), "jiesuan_dizhu");
        iconSprite.transform.localScale = new Vector3(0.8f, 1f, 1);
        iconSprite.transform.position = iconPosObj.position;
    }
    /// <summary>
    /// 设置农民标记的头像
    /// </summary>
    /// <param name="dizhuPlayerId"></param>
    public void setPeasantIcon(long dizhuPlayerId)
    {
        foreach(KeyValuePair<long, UIPlayerInfo> kv in uiPlayerDic)
        {
            if(kv.Key != dizhuPlayerId)
            {
                UIPlayerInfo playerInfo = kv.Value;
                UISprite headSprite = playerInfo.HeadSprite;
                Transform iconPosObj = headSprite.transform.Find("IconPos").transform;
                UISprite iconSprite = NGUITools.AddSprite(headSprite.gameObject, UIRoomController.Instance.getPublicAtlas(), "jiesuan_nongmin");
                iconSprite.transform.localScale = new Vector3(0.8f, 1f, 1);
                iconSprite.transform.position = iconPosObj.position;
            }
        }
    }
}
