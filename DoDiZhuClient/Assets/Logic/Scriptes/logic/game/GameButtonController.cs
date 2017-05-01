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
    }

    public void OnSecondScordButtonClick()
    {
        scord = 2;
    }

    public void OnThreeScordButtonClick()
    {
        scord = 3;
    }

    public void SelectDiZhu()
    {
        int randomFirst = Random.Range(1,3);
      
        if(randomFirst == 1)
        {
            selectScordContainer.gameObject.SetActive(true);
        } else
        {
            for(int i = 2;i <= 3; i++)
            {
                int randomScord = Random.Range(1,3);
               
                if(randomScord == 3)
                {
                    scord = 3;
                    dizhuPlayerId = PlayerManager.Instance.getPlayerInfoByPos(i).PlayerId;
                    GameLog.debug("自动选择地主：" + dizhuPlayerId);
                }
            }
        }
        if(scord == 0)
        {
            selectScordContainer.gameObject.SetActive(true);
        }
    }

}
