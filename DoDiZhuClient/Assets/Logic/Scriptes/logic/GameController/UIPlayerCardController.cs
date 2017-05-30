using UnityEngine;
using System.Collections.Generic;

public class UIPlayerCardController : MonoBehaviour {
    public static UIPlayerCardController Instance;
    //玩家手里牌的sprite GameObject
    private List<GameObject> playerCardsGameObjList = new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public List<GameObject> getPlayerCardSprites()
    {
        return playerCardsGameObjList;
    }
}
