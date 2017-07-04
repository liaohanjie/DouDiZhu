using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player  {

    private long playerId;
    private string playerName;
    private string playerIcon;

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


    public string PlayerIcon
    {
        get
        {
            return playerIcon;
        }

        set
        {
            playerIcon = value;
        }
    }
}
