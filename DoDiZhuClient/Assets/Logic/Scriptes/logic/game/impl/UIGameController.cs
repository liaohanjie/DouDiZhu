using UnityEngine;
using System.Collections.Generic;

public class UIGameController : MonoBehaviour
{
    private CardsManager cardsManager = CardsManager.Instance();


    public UIWidget btnContainer;

    public Camera playerCamera;

    public GameObject leftPokerPos;
    public GameObject rightPokerPos;
    public GameObject centerPokerPos;
    public GameObject downPokerPos;


    private UISprite[] allCardsSprites;
    private UISprite[] downPlayerCardsSprites;
   

    public UIAtlas gameUiAtlas = null;
    private bool isMoved;

    public UIButton readyGameBtn;
    private const string pokerPre = "poker_";
    private const string defaultCardsName = "game_zhipai";
    int playerIndex = 1;
    int movedIndex = 0;

    private int playerCardsSpritesIndex = 0;
    private PlayerManager playerManager = PlayerManager.getInstance();
    // Use this for initialization
    void Start()
    {
     
        allCardsSprites = new UISprite[51];
        downPlayerCardsSprites = new UISprite[17];
        cardsManager.initCards();

       
      
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
        int[] allCards = cardsManager.getAllCards();
        PlayerManager.getInstance().sendPlayerCards(allCards);
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
            float distance = (8f * Time.deltaTime);
            allCardsSprites[index].transform.position = Vector3.MoveTowards(allCardsSprites[index].transform.position, toPos, distance);

        }
        else
        {
          
            if (playerIndex == 1)
            {
                Vector3 v = downPokerPos.transform.position;

                v.x = v.x + 0.16f;
                downPokerPos.transform.position = v;
                downPlayerCardsSprites[playerCardsSpritesIndex] = allCardsSprites[index];
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
    /// <summary>
    /// 显示玩家的牌
    /// </summary>
    private void showPlayerCards()
    {
        PlayerInfo playerInfo = playerManager.getNowPlayerInfo();
        List<int> cards = playerInfo.getCards();
        cards.Sort((x,y)=> {
            return y % 100 - x % 100;
        });
        
        int depth = 9;
        for (int i = 0; i < cards.Count; i++)
        {
            string cardName = pokerPre + cards[i];
            GameLog.debug(cardName);
            UISprite cardSprite = NGUITools.AddSprite(centerPokerPos.gameObject, gameUiAtlas, cardName);
            UISprite posSprite = downPlayerCardsSprites[i];
            Vector3 pos = posSprite.transform.position;
            posSprite.gameObject.SetActive(false);
            cardSprite.transform.position = pos;
            cardSprite.transform.Rotate(new Vector3(0, 0, 90));
            cardSprite.transform.localScale = new Vector3(1, 0.8f, 1);
            cardSprite.depth = depth;
            depth++;
        }
    }




    public void OnReadyGameBtnClick()
    {
        readyGameBtn.gameObject.SetActive(false);
        btnContainer.gameObject.SetActive(true);
        cardsManager.RefreshCards();
        InitCardsSprite();
    }

}
