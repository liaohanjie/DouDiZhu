using UnityEngine;
using System.Collections.Generic;
using System.Collections;
/// <summary>
/// 初始化牌，并发给每个玩家
/// </summary>
public class InitCardsController : MonoBehaviour
{
    public static InitCardsController Instance;
    public GameObject leftHeadPos;
    public GameObject rightHeadPos;
    public GameObject centerPokerPos;
    public GameObject playerCardsPos;

    public UIWidget roomContainer;

    public UIAtlas gameUiAtlas;

    public UIPanel cardZheTangPanel;

    private UISprite[] allCardsSprites = new UISprite[54];
    private List<UISprite> localPlayerDefaultCardsSprites = new List<UISprite>();
    private const string defaultCardName = "game_zhipai";
    private const string pokerPre = "poker_";
    //发牌索引，标记牌发到哪个玩家了。
    private int sendCardIndex = 1;
    //牌的索引，标记当前发到哪张牌了。
    private int cardIndex = 0;
    private int cardDepth = 10;

    //记录最后三张地主牌
    private UISprite[] dizhuCardsSprites;


    private static bool started = false;

    void Awake()
    {
        Instance = this;
        dizhuCardsSprites = new UISprite[3];
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            sendCardsAnimation();
        }
    }

    public void initCardsSprites()
    {
        CardsManager.Instance().SendCards();
        int[] allCards = CardsManager.Instance().getAllCards();

        Vector3 centerPos = centerPokerPos.transform.position;
        int depth = 100;
        for (int i = 0; i < allCardsSprites.Length; i++)
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
        Vector3 pos = Vector3.zero;

        if (sendCardIndex == 1)
        {
            Vector3 v = playerCardsPos.transform.position;
            v = SetNextPos(v);
            playerCardsPos.transform.position = v;
            pos = playerCardsPos.transform.position;
        }
        else if (sendCardIndex == 2)
        {
            pos =getRightCardsPos();

        }
        else if (sendCardIndex == 3)
        {
            pos = getLeftCardsPos();
        } 

        TweenPosition tweenPos = TweenPosition.Begin(allCardsSprites[cardIndex].gameObject, 0.08f, pos, true);
       
        tweenPos.PlayForward();
        tweenPos.SetOnFinished(changeStatus);
        started = false;

    }
    /// <summary>
    /// 每次给玩家发完牌，牌的坐标右偏一点
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    private Vector3 SetNextPos(Vector3 v)
    {
        v.x = v.x + 0.12f;
        return v;
    }
    public void changeStatus()
    {
        allCardsSprites[cardIndex].depth = cardDepth;
        cardDepth++;
        if (cardIndex == allCardsSprites.Length - 3)
        {
            started = false;
            aferSendComplete();
            return;
        }
        if(sendCardIndex != 1)
        {
            //如果不是玩家的牌，让sprite失效
            allCardsSprites[cardIndex].gameObject.SetActive(false);
        } else
        {
            localPlayerDefaultCardsSprites.Add(allCardsSprites[cardIndex]);
        }
      
        if (sendCardIndex == 3)
        {
            sendCardIndex = 0;
        }
        sendCardIndex++;
        cardIndex++;
        started = true;
    }

    public  void startSendCards()
    {
        started = true;
    }
    /// <summary>
    /// 当发牌完成之后要做的事情
    /// </summary>
    public void aferSendComplete()
    {
        movedLastCards();
        showPlayerCards();
        ScoreSelectController.Instance.randomCallScore();
    }
    /// <summary>
    /// 移动最后三张牌到中间
    /// </summary>
    private void movedLastCards()
    {
        Vector3 vec = centerPokerPos.transform.position;
        vec.x = vec.x - 0.4f;

        for (int i = allCardsSprites.Length - 3; i < allCardsSprites.Length; i++)
        {
            vec.x = vec.x + i * 0.005f;
            allCardsSprites[i].transform.position = vec;
        }
    }

    /// <summary>
    /// 显示地主片
    /// </summary>
    public void showDiZhuCard()
    {
        int[] cards = CardsManager.Instance().getDiZhuCard();
        int depth = 10;
        for (int i = 0; i < cards.Length; i++)
        {
            string cardName = pokerPre + cards[i];


            GameObject cardsGameObject = this.AddCardGameObject(cards[i], cardName, depth);
            UISprite posSprite = allCardsSprites[allCardsSprites.Length - 1 - i];
            Vector3 pos = posSprite.transform.position;
            posSprite.gameObject.SetActive(false);
            cardsGameObject.transform.position = pos;
            depth++;
            dizhuCardsSprites[i] = cardsGameObject.GetComponent<UISprite>();
            Destroy(dizhuCardsSprites[i].GetComponent<UIButton>());
        }
        StartCoroutine(moveDiZhuCards());
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

            UIPlayerCardController.Instance.getPlayerCardSprites().Add(cardsGameObject);

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
    /// <summary>
    /// 移动地主的最后三张牌
    /// </summary>
    IEnumerator moveDiZhuCards()
    {
        MoveDizhuCard.Instance.SetDizhuCardsSprites(dizhuCardsSprites);

        yield return new WaitForSeconds(0.5f);
    }
}
