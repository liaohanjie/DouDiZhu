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
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
       
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


}
