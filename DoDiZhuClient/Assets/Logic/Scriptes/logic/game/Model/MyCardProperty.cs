using UnityEngine;
using System.Collections;

public class MyCardProperty : MonoBehaviour {
    private int cardIndex;
    private bool isOut = false;
    private Vector3 originePos;

    public int CardIndex {
        get;set;
    }
	// Use this for initialization
	void Start () {
        originePos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCardPress()
    {
        if (!isOut)
        {
            Vector3 outPos = originePos;
            outPos.y = outPos.y + 0.04f;
            gameObject.transform.position = outPos;
            isOut = true;
            GameCardsManager.Instance().SelectCards(this.gameObject);
        } else
        {
            gameObject.transform.position = originePos;
            GameCardsManager.Instance().RemoveCardsOfSelect(this.gameObject);
            isOut = false;
        }
    }

    public void setOriginePos(Vector3 newPos)
    {
        this.originePos = newPos;
    }

    
}
