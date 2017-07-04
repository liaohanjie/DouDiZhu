using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlayInfo {

    private Player player;
    private List<int> cards;
    private int pos;
    private bool isDiZhu;
    //上次出的牌
    private int prePlayCard;

    public Player Player
    {
        get
        {
            return player;
        }

        set
        {
            player = value;
        }
    }

    public List<int> Cards
    {
        get
        {
            return cards;
        }

        set
        {
            cards = value;
        }
    }

    public int Pos
    {
        get
        {
            return pos;
        }

        set
        {
            pos = value;
        }
    }

    public bool IsDiZhu
    {
        get
        {
            return isDiZhu;
        }

        set
        {
            isDiZhu = value;
        }
    }

    public int PrePlayCard
    {
        get
        {
            return prePlayCard;
        }

        set
        {
            prePlayCard = value;
        }
    }
}
