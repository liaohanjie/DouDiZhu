

using System.Collections.Generic;

public class PlayCommonInfo {
    //最后三张地主牌
    private List<int> dizhuCard = new List<int>();
    //叫的分数
    private int score;
    //共出现的炸弹次数
    private int boomCount;


    public void ResetInfo()
    {
        dizhuCard.Clear();
        score = 0;
        boomCount = 0;
    }

    public List<int> DizhuCard
    {
        get
        {
            return dizhuCard;
        }

        set
        {
            dizhuCard = value;
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

    public int BoomCount
    {
        get
        {
            return boomCount;
        }

        set
        {
            boomCount = value;
        }
    }
}
