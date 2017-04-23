using UnityEngine;
using System.Collections.Generic;

public class GameCardsManager : MonoBehaviour {

    private static GameCardsManager instance = new GameCardsManager();

    public static GameCardsManager Instance()
    {
        return instance;
    }
    //已出过的牌
    private List<GameObject> hadPlayCards = new List<GameObject>();

    //选择的牌
    private List<GameObject> selectedCards = new List<GameObject>();
   

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SelectCards(GameObject go)
    {
        hadPlayCards.Add(go);
    }

    public void RemoveCardsOfSelect(GameObject go)
    {
        hadPlayCards.Remove(go);
    }

    public void ClearHadPlayCards()
    {
        hadPlayCards.Clear();
    }


    public List<GameObject> getSelectCards()
    {
        return hadPlayCards;
    }

}
