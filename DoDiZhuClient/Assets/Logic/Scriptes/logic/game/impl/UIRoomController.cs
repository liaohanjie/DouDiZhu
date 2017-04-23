using UnityEngine;
using System.Collections.Generic;

public class UIRoomController : MonoBehaviour
{
    private CardsManager cardsManager = CardsManager.Instance();
    private RoomManager roomManager = RoomManager.Instance();

    public UIWidget btnContainer;
    public UIWidget playerCardContainer;

    public Camera playerCamera;

    public GameObject leftPokerPos;
    public GameObject rightPokerPos;
    public GameObject centerPokerPos;
    public GameObject downPokerPos;

    private Vector3 origineDownPokerPos;

    //所有牌的Sprite
    private UISprite[] allCardsSprites;

    private UISprite[] playerCardSprites;
    //用户手里的牌的对象
    private List<GameObject> downPlayerCards;
    //最后剩余的三张牌的对象
    private List<GameObject> lastCards;
    


    public UIAtlas gameUiAtlas = null;
    private bool isMoved;

    public UIButton readyGameBtn;
    private const string pokerPre = "poker_";
    private const string defaultCardsName = "game_zhipai";
    int playerIndex = 1;
    int movedIndex = 0;

    private int playerCardsSpritesIndex = 0;
    private const int  SendCardsCount = 51;
    // Use this for initialization
    void Start()
    {

        allCardsSprites = new UISprite[SendCardsCount];
        roomManager.initPlayer();
        downPlayerCards = new List<GameObject>();



    }


    // Update is called once per frame
    void Update()
    {
        if (isMoved)
        {
            sendCards();
        }

    }



    /// <summary>
    /// 发牌
    /// </summary>
    public void InitCardsSprite()
    {

        roomManager.AssignCards();
        int playerCardCount = roomManager.GetNowPlayerInfo().getCards().Count;
        playerCardSprites = new UISprite[playerCardCount];
        int[] allCards = cardsManager.getAllCards();
        
        Vector3 centerPos = centerPokerPos.transform.position;
        int depth = 100;
        for (int i = allCardsSprites.Length - 1; i >= 0; i--)
        {
            UISprite cardSprite = NGUITools.AddSprite(centerPokerPos.gameObject, gameUiAtlas, defaultCardsName);
            cardSprite.transform.position = new Vector3(centerPos.x, centerPos.y, centerPos.z);
            cardSprite.transform.Rotate(new Vector3(0, 0, 90));
            cardSprite.transform.localScale = new Vector3(1, 0.8f, 1);
            cardSprite.depth = depth;
            depth--;
            allCardsSprites[i] = cardSprite;
        }
        setDefaultOtherPlayerCards(leftPokerPos.transform.position);
        setDefaultOtherPlayerCards(rightPokerPos.transform.position);

       
        isMoved = true;
    }

    private void setDefaultOtherPlayerCards(Vector3 toPos)
    {
        UISprite defaultCardsSprite = NGUITools.AddSprite(centerPokerPos.gameObject, gameUiAtlas, defaultCardsName);
        defaultCardsSprite.depth = 101;
        defaultCardsSprite.transform.position = toPos;
        defaultCardsSprite.transform.localScale = new Vector3(1, 0.8f, 1);
        defaultCardsSprite.transform.Rotate(new Vector3(0, 0, 90));
    }




    private void sendCards()
    {

        Vector3 toPos = Vector3.zero;
        if (movedIndex == allCardsSprites.Length)
        {
            isMoved = false;
            showPlayerCards();
            return;
        }

        int index = movedIndex;
        if (playerIndex == 1)
        {
            toPos = downPokerPos.transform.position;
        }
        else if (playerIndex == 2)
        {
            toPos = rightPokerPos.transform.position;
        }
        else
        {
            toPos = leftPokerPos.transform.position;

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
                Vector3 v = downPokerPos.transform.position;
                v =  SetNextPos(v);
                downPokerPos.transform.position = v;
                playerCardSprites[playerCardsSpritesIndex] = allCardsSprites[movedIndex];
                playerCardsSpritesIndex++;
                
            } else
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

    private Vector3 SetNextPos(Vector3 v)
    {
        v.x = v.x + 0.14f;
        return v;
    }

    /// <summary>
    /// 根据牌的索引，创建一个牌的GameObject
    /// </summary>
    /// <param name="cardIndex"></param>
    /// <returns></returns>
    private GameObject AddCardGameObject(int cardIndex,string cardName,int depth)
    {
        GameObject cardSprites = Resources.Load("Card") as GameObject;
        cardSprites = NGUITools.AddChild(playerCardContainer.gameObject, cardSprites);
        UISprite uisrite = cardSprites.GetComponent<UISprite>();
        uisrite.spriteName = cardName;
        cardSprites.transform.Rotate(new Vector3(0, 0, 90));
        cardSprites.transform.localScale = new Vector3(1, 0.6f, 1);
        uisrite.depth = depth;

        MyCardProperty cardProperty = cardSprites.GetComponent<MyCardProperty>();
        cardProperty.CardIndex = cardIndex;

        return cardSprites;
    }
    /// <summary>
    /// 显示玩家的牌
    /// </summary>
    private void showPlayerCards()
    {
        PlayerInfo playerInfo = roomManager.GetNowPlayerInfo();
        List<int> cards = playerInfo.getCards();
        cards.Sort((x,y)=> {
            return y % 100 - x % 100;
        });
        int depth = 10;
        for (int i = 0; i < cards.Count; i++)
        {
            string cardName = pokerPre + cards[i];
          
          
            GameObject cardsGameObject = this.AddCardGameObject(cards[i],cardName,depth);

            downPlayerCards.Add(cardsGameObject);

            UISprite posSprite = playerCardSprites[i];
            Vector3 pos = posSprite.transform.position;
            posSprite.gameObject.SetActive(false);
            cardsGameObject.transform.position = pos;
            depth++;

        }
    }
    /// <summary>
    /// 刷新牌的位置
    /// </summary>
    public void RefreshPlayerCardsPos()
    {
        Vector3 v = origineDownPokerPos ;
       
        foreach(GameObject go in downPlayerCards){
            if(go != null)
            {
                MyCardProperty cardProperty = go.GetComponent<MyCardProperty>();
                cardProperty.setOriginePos(v);
                go.transform.position = v;
                v =  SetNextPos(v);
            }
           
        }
    }


    public void OnReadyGameBtnClick()
    {
        readyGameBtn.gameObject.SetActive(false);
        btnContainer.gameObject.SetActive(true);
      
        InitCardsSprite();
        origineDownPokerPos = downPokerPos.transform.position;
        
    }



    public void PlayerCards()
    {
        List<GameObject> selectedCarads = GameCardsManager.Instance().getSelectCards();
        GameCardsManager gameManager = GameCardsManager.Instance();
        if(selectedCarads.Count > 0)
        {
            PlayerInfo playerinfo = RoomManager.Instance().GetNowPlayerInfo();
            int depth = 9;
            foreach (GameObject cards in selectedCarads)
            {
                cards.transform.position = centerPokerPos.transform.position;

                MyCardProperty cardProperty = cards.GetComponent<MyCardProperty>();
                int removeCard = cardProperty.CardIndex;
                playerinfo.removeCard(removeCard);
                downPlayerCards.Remove(cards);
                cards.GetComponent<UISprite>().depth = depth;
                depth++;
            }
            this.RefreshPlayerCardsPos();
        }

    }




}
