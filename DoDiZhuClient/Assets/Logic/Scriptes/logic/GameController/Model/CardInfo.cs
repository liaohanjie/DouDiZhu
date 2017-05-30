using UnityEngine;
using System.Collections;

public class CardInfo : MonoBehaviour {

    private int cardIndex;
    private Vector3 originVec;
    //是否选中这张牌
    private bool seleted =false;


    void Start()
    {
        originVec = this.transform.position;
    }

    public int CardIndex
    {
        get
        {
            return cardIndex;
        }

        set
        {
            cardIndex = value;
        }
    }

    public void OnCardClick()
    {
        if (!seleted)
        {
            Vector3 pos = originVec; ;
            pos.y = originVec.y + 0.05f;

            this.transform.position = pos;
            seleted = true;
            GameButtonController.Instance.addSeletedCards(this.gameObject);
        } else
        {
            this.transform.position = originVec;
            seleted = false;
            GameButtonController.Instance.removeCards(this.gameObject);
        }
       
    }

    public void ResetCardPos()
    {
        this.transform.position = originVec;
    }
   
}
