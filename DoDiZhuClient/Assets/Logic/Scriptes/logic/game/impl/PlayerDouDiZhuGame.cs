using UnityEngine;
using System.Collections;

public class PlayerDouDiZhuGame : MonoBehaviour {
    private CardsManager cardsManager = CardsManager.Instance();

    public UIWidget centerContainer;
    public UIWidget btnContainer;
    public UIWidget pokerContainer;
    public Camera playerCamera;

    public GameObject leftPokerPos;
    public GameObject rightPokerPos;
    private UISprite[] allCardsSprites;

    public UIAtlas gameUiAtlas = null;
    private bool isMoved;

    public UIButton readyGameBtn;

    int playerIndex = 1;
    int movedIndex = 0;

    // Use this for initialization
    void Start () {
        allCardsSprites = new UISprite[54];
        cardsManager.initCards();
      
    }
	
	// Update is called once per frame
    void Update () {
        if (isMoved)
        {
           sendCards();
        }


    }



    /// <summary>
    /// 发牌
    /// </summary>
     public  void InitCardsSprite()
    {
        string[] allCards = cardsManager.getAllCards();
        Vector3 centerPos =  centerContainer.transform.position;
        for (int i = allCardsSprites.Length -1;i >= 0;i--)
        {
          
            UISprite cardSprite = NGUITools.AddSprite(centerContainer.gameObject,gameUiAtlas,allCards[i]);
            cardSprite.transform.position = new Vector3(centerPos.x + i*0.01f, centerPos.y, centerPos.z);
            cardSprite.transform.Rotate(new Vector3(0,0,90));
            cardSprite.transform.localScale = new Vector3(1, 0.8f, 1);
            cardSprite.depth = 8;
            allCardsSprites[i] = cardSprite;
        }

        isMoved = true;


    }

    private void sendCards()
    {
       
        Vector3 toPos = Vector3.zero;
        if(movedIndex == allCardsSprites.Length)
        {
            isMoved = false;
            return;
        }

             int index = movedIndex;
            if (playerIndex == 1)
            {
                toPos = pokerContainer.transform.position;
            }
            else if (playerIndex == 2)
            {
                toPos = rightPokerPos.transform.position;
            }
            else
            {
                toPos = leftPokerPos.transform.position;
               
            }
            if (allCardsSprites[index].transform.position.x != toPos.x)
            {
                allCardsSprites[index].transform.position = Vector3.MoveTowards(allCardsSprites[index].transform.position, toPos, 3f * Time.deltaTime);

            } else
            {
                 GameLog.debug(playerIndex + "," + (movedIndex + 1));
                  playerIndex++;
                    movedIndex++;
                
                if(playerIndex > 3)
                {
                    playerIndex = 1;
                }
           
            }
    }

   

    

    public void OnReadyGameBtnClick()
    {
        readyGameBtn.gameObject.SetActive(false);
        btnContainer.gameObject.SetActive(true);
        cardsManager.RefreshCards();
        InitCardsSprite();
    }


    /// <summary>
    /// 出牌
    /// </summary>
    /// <param name="index"></param>
    public void PlayCards(int index)
    {

    }
    /// <summary>
    /// 重选
    /// </summary>
    public void ReSelectCards()
    {

    }
    /// <summary>
    /// 不出
    /// </summary>
    public void PassOnce()
    {

    }
    /// <summary>
    /// 提示
    /// </summary>
    public void PlayTips()
    {

    }
}
