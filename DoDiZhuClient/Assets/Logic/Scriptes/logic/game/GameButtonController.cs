using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// 出牌管理
/// </summary>
public class GameButtonController : MonoBehaviour{
    /// <summary>
    /// 玩家选择要出的牌
    /// </summary>
    private List<GameObject> seletedCards = new List<GameObject>();
    public static GameButtonController Instance = null;
    public UIWidget selectScordContainer;
    //叫的分数
    private int scord = 0;
    private long dizhuPlayerId = 0;
    void Start()
    {
        Instance = this;
    }
    public void addSeletedCards(GameObject cardsObject)
    {
        seletedCards.Add(cardsObject);
    }

    public void removeCards(GameObject cardsObject)
    {
        seletedCards.Remove(cardsObject);
    }

    public void resetSelectedCards()
    {
        seletedCards.Clear();
    }


    /// <summary>
    /// 点击重选按钮
    /// </summary>
    public void OnReSelectButtonClick()
    {
        int count = seletedCards.Count;
       for(int i = 0;i < count; i++)
        {
            CardInfo cardInfo = seletedCards[i].GetComponent<CardInfo>();
            cardInfo.ResetCardPos();
           
        }
        resetSelectedCards();
    }
    /// <summary>
    /// pass 按钮
    /// </summary>
    public void OnPassButtonClick()
    {

    }
    /// <summary>
    /// 点击出牌
    /// </summary>
    public void OnSendButtonClick()
    {

    }
    /// <summary>
    /// 点击提示按钮
    /// </summary>
    public void OnTipButtonClick()
    {

    }

    public void OnOneScordButtonClick()
    {
        scord = 1;
        selectScordContainer.gameObject.SetActive(false);
        RandomDiDun();
        
    }

    public void OnSecondScordButtonClick()
    {
        scord = 2;
        selectScordContainer.gameObject.SetActive(false);
        RandomDiDun();

    }

    public void OnThreeScordButtonClick()
    {
        scord = 3;
        dizhuPlayerId = PlayerManager.Instance.getPlayerInfoByPos(1).PlayerId;
        selectScordContainer.gameObject.SetActive(false);
        UIRoomController.Instance.showDiZhuCard();
        SendDiZhuCards(dizhuPlayerId);
        UIRoomController.Instance.showButtonContainer();
      
    }
    /// <summary>
    /// 地主确定后，把地主牌发给相应的人
    /// </summary>
    private void SendDiZhuCards(long playerId)
    {
        PlayerInfo playerInfo = PlayerManager.Instance.getPlayerInfo(playerId);
        int playerPos = playerInfo.PlayerPos;
        if(playerPos == 1)
        {

        }
    }

   
  
    /// <summary>
    /// 选择谁第一个叫分
    /// </summary>
    public void SelectTheFirstCallScore()
    {
        int randomFirst = Random.Range(1,3);
      
        if(randomFirst == 1)
        {
            selectScordContainer.gameObject.SetActive(true);

        } else
        {
            RandomDiDun();
        }
       
        if (scord == 0)
        {
            selectScordContainer.gameObject.SetActive(true);
        }
    }
    /// <summary>
    /// 随机找一个地主
    /// </summary>
    private void RandomDiDun()
    {
        //从其它两个玩家中选择一个地主
        int randomFirst = Random.Range(2, 3);
        scord = 3;
        dizhuPlayerId = PlayerManager.Instance.getPlayerInfoByPos(randomFirst).PlayerId;
        UIRoomController.Instance.showDiZhuCard();
    }



}
