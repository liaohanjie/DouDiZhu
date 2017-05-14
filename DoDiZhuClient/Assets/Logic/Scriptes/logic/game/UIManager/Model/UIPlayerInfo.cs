using UnityEngine;
using System.Collections;

public class UIPlayerInfo {
    private long playerId;
    private UISprite headSprite;


  public UIPlayerInfo(long playerId)
    {
        this.playerId = playerId;
    }
    public long PlayerId
    {
        get
        {
            return playerId;
        }

        set
        {
            playerId = value;
        }
    }

    public UISprite HeadSprite
    {
        get
        {
            return headSprite;
        }

        set
        {
            headSprite = value;
        }
    }
}
