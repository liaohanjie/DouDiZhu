using UnityEngine;
using System.Collections.Generic;

public class UIRoomController : MonoBehaviour {

    public static UIRoomController Instance;
    public GameObject leftHeadPos;
    public GameObject rightHeadPos;
    public GameObject bottomHeadPos;
    public GameObject centerPokerPos;
    public GameObject playerCardsPos;
    

    public UIWidget roomContainer;
    public UIWidget buttonContainer;
    public UIAtlas gameUiAtlas;
    public UIAtlas publicAtlas;
    public UIButton readyButton;
    public Camera playerCamera;
    private UISprite[] allCardsSprites = new UISprite[54];
    private List<UISprite> localPlayerDefaultCardsSprites = new List<UISprite>();

    
    //玩家手里牌的sprite GameObject
    private List<GameObject> playerCardsGameObjList = new List<GameObject>();
    private const  string defaultCardName = "game_zhipai";
    private const string pokerPre = "poker_";
    private int movedIndex = 0;
    private bool isMoved = false;
    private int playerIndex = 1;
    private int playerCardsSpritesIndex = 0;


    private UISprite[] dizhuCardsSprites;

    // Use this for initialization
    void Start () {
        Instance = this;
        PlayerManager.Instance.RandomPlayer();
        initPlayerInfo();
        dizhuCardsSprites = new UISprite[3];
	}
	
	// Update is called once per frame
	void Update () {
        if (isMoved)
        {
            sendCardsAnimation();
        }
	}

    public UIAtlas getPublicAtlas()
    {
        return publicAtlas;
    }
    /// <summary>
    /// 初始化登陆用户信息
    /// </summary>
    public void initPlayerInfo()
    {
        PlayerInfo[] playerInfos = PlayerManager.Instance.getPlayerInfos();
        foreach(PlayerInfo playerInfo in playerInfos)
        {
            addPlayerHeadSprite(playerInfo);
        }
    }

    public void addPlayerHeadSprite(PlayerInfo playerInfo)
    {
        int pos = playerInfo.PlayerPos;
        GameLog.debug(playerInfo.PlayerPos.ToString());
        GameObject posGameObj = null;
        UIPlayerInfo uiPlayerInfo = UIPlayerManager.getInstsance().getUIPlayerInfo(playerInfo.PlayerId); ;
        switch (pos)
        {
            case 1:
                posGameObj = bottomHeadPos;
               
                break;
            case 2:
                posGameObj = rightHeadPos;
                break;
            case 3:
                posGameObj = leftHeadPos;
                break;
        }
        GameObject headGameObject = Resources.Load("HeadSprite") as GameObject;
        headGameObject = NGUITools.AddChild(roomContainer.gameObject,headGameObject);
        UISprite headSprite = headGameObject.GetComponent<UISprite>();
        UILabel nameLabel = headGameObject.transform.Find("NameLabel").GetComponent<UILabel>();
        nameLabel.text = playerInfo.PlayerName;
        headSprite.transform.position = posGameObj.transform.position;
        headSprite.name = playerInfo.Icon;
        uiPlayerInfo.HeadSprite = headSprite;
        headSprite.depth = 102;

       

    }
    public void initCardsSprites()
    {
       
        
        int[] allCards = CardsManager.Instance().getAllCards();

        Vector3 centerPos = centerPokerPos.transform.position;
        int depth = 100;
        for (int i = 0; i < allCardsSprites.Length ; i++)
        {
            UISprite cardSprite = NGUITools.AddSprite(centerPokerPos.gameObject, gameUiAtlas, defaultCardName);
            cardSprite.transform.position = new Vector3(centerPos.x + i * 0.015f, centerPos.y, centerPos.z);
            cardSprite.transform.Rotate(new Vector3(0, 0, 90));
            cardSprite.transform.localScale = new Vector3(1, 0.8f, 1);
            cardSprite.depth = depth;
            depth--;
            allCardsSprites[i] = cardSprite;
        }
        Vector3 leftVec = getLeftCardsPos();
        setDefaultOtherPlayerCards(leftVec);

        Vector3 rightVec = getRightCardsPos();
        setDefaultOtherPlayerCards(rightVec);


    }

    private Vector3 getLeftCardsPos()
    {
        Vector3 leftVec = leftHeadPos.transform.position;
        leftVec.x = leftVec.x + 0.3f;
        return leftVec;
    }
    private Vector3 getRightCardsPos()
    {
        Vector3 rightVec = rightHeadPos.transform.position;
        rightVec.x = rightVec.x - 0.3f;
        return rightVec;
    }
    /// <summary>
    /// 设置玩家默认的牌面
    /// </summary>
    /// <param name="toPos"></param>
    private void setDefaultOtherPlayerCards(Vector3 toPos)
    {
        UISprite defaultCardsSprite = NGUITools.AddSprite(centerPokerPos.gameObject, gameUiAtlas, defaultCardName);
        defaultCardsSprite.depth = 101;
        defaultCardsSprite.transform.position = toPos;
        defaultCardsSprite.transform.localScale = new Vector3(1, 0.8f, 1);
        defaultCardsSprite.transform.Rotate(new Vector3(0, 0, 90));
    }
    /// <summary>
    /// 
    /// 发牌动画
    /// </summary>
    private void sendCardsAnimation()
    {

        Vector3 toPos = Vector3.zero;
        if (movedIndex == allCardsSprites.Length - 3)
        {
            //发牌动画结束后要做的事情
            isMoved = false;
            MovedLastCards();
            showPlayerCards();
         
            return;
        }

        int index = movedIndex;
        if (playerIndex == 1)
        {
            toPos = playerCardsPos.transform.position;
        }
        else if (playerIndex == 2)
        {
            toPos = getRightCardsPos();
        }
        else
        {
            toPos = getLeftCardsPos();

        }
        Vector3 pos1 = playerCamera.WorldToScreenPoint(allCardsSprites[index].transform.position);
        Vector3 pos2 = playerCamera.WorldToScreenPoint(toPos);
        float pos1X = pos1.x;
        float pos1Y = pos1.y;
        float pos2X = pos2.x;
        float pos2Y = pos2.y;
        if (pos1X != pos2X && pos1Y != pos2Y)
        {
            float distance = (16f * Time.deltaTime);
            allCardsSprites[index].transform.position = Vector3.MoveTowards(allCardsSprites[index].transform.position, toPos, distance);

        }
        else
        {
            if (playerIndex == 1)
            {
                Vector3 v = playerCardsPos.transform.position;
                v = SetNextPos(v);
                playerCardsPos.transform.position = v;
                localPlayerDefaultCardsSprites.Add( allCardsSprites[movedIndex]);
                playerCardsSpritesIndex++;
                allCardsSprites[movedIndex].depth = playerCardsSpritesIndex;

            }
            else
            {
                allCardsSprites[index].gameObject.SetActive(false);
            }
            playerIndex++;
            movedIndex++;

            if (playerIndex > 3)
            {
                playerIndex = 1;
            }

        }
    }
    /// <summary>
    /// 移动最后三张牌到中间
    /// </summary>
    private void MovedLastCards()
    {
        Vector3 vec = centerPokerPos.transform.position;
        vec.x = vec.x - 0.4f;

        for (int i = allCardsSprites.Length  - 3; i < allCardsSprites.Length; i++)
        {
            vec.x = vec.x + i * 0.005f;
            allCardsSprites[i].transform.position = vec;
        }
    }
    private Vector3 SetNextPos(Vector3 v)
    {
        v.x = v.x + 0.14f;
        return v;
    }
    /// <summary>
    /// 点击准备按钮
    /// </summary>
    public void OnReadButtonClick()
    {
        CardsManager.Instance().SendCards();
        initCardsSprites();
        isMoved = true;
        readyButton.gameObject.SetActive(false);
      
    }
    public void showButtonContainer()
    {
        buttonContainer.gameObject.SetActive(true);
    }
    /// <summary>
    /// 显示玩家的牌
    /// </summary>
    private void showPlayerCards()
    {
        PlayerInfo playerInfo = PlayerManager.Instance.getPlayerInfo(1); ;
        List<int> cards = playerInfo.getCards();
        cards.Sort((x, y) => {
            return y % 100 - x % 100;
        });
        int depth = 10;
        for (int i = 0; i < cards.Count; i++)
        {
            string cardName = pokerPre + cards[i];


            GameObject cardsGameObject = this.AddCardGameObject(cards[i], cardName, depth);

            playerCardsGameObjList.Add(cardsGameObject);

            UISprite posSprite = localPlayerDefaultCardsSprites[i];
            Vector3 pos = posSprite.transform.position;
            posSprite.gameObject.SetActive(false);
            cardsGameObject.transform.position = pos;
            depth++;

        }
    }
    /// <summary>
    /// 根据牌的索引，创建一个牌的GameObject
    /// </summary>
    /// <param name="cardIndex"></param>
    /// <returns></returns>
    private GameObject AddCardGameObject(int cardIndex, string cardName, int depth)
    {
        GameObject cardSprites = Resources.Load("Card") as GameObject;
        cardSprites = NGUITools.AddChild(roomContainer.gameObject, cardSprites);
        UISprite uisrite = cardSprites.GetComponent<UISprite>();
        uisrite.spriteName = cardName;
        cardSprites.transform.Rotate(new Vector3(0, 0, 90));
        cardSprites.transform.localScale = new Vector3(1, 0.6f, 1);
        uisrite.depth = depth;

        CardInfo cardProperty = cardSprites.GetComponent<CardInfo>();
        cardProperty.CardIndex = cardIndex;

        return cardSprites;
    }

    public void setPlayerTips(long playerId,string tipsContent)
    {
        UIPlayerInfo uiPlayerInfo = UIPlayerManager.getInstsance().getUIPlayerInfo(playerId);
        UISprite headSprite = uiPlayerInfo.HeadSprite;
        UILabel tipLabel = headSprite.transform.Find("TipsLabel").GetComponent<UILabel>();
        tipLabel.text = tipsContent;
    }
    /// <summary>
    /// 显示地主片
    /// </summary>
    public void showDiZhuCard()
    {
        int[] cards = CardsManager.Instance().getDiZhuCard();
        int depth = 2;
        for (int i = 0; i < cards.Length; i++)
        {
            string cardName = pokerPre + cards[i];


            GameObject cardsGameObject = this.AddCardGameObject(cards[i], cardName, depth);

            playerCardsGameObjList.Add(cardsGameObject);

            UISprite posSprite = allCardsSprites[allCardsSprites.Length - 1 -i];
            Vector3 pos = posSprite.transform.position;
            posSprite.gameObject.SetActive(false);
            cardsGameObject.transform.position = pos;
            depth++;
            dizhuCardsSprites[i] = cardsGameObject.GetComponent<UISprite>();

        }
    }
    /// <summary>
    /// 移动地主牌
    /// </summary>
    public void MoveDizhuCardsSprites()
    {
        MoveDizhuCard.Instance.SetDizhuCardsSprites(dizhuCardsSprites);
    }
}
