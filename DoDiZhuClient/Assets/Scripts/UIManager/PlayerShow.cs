using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 在房间中显示玩家用户
/// </summary>
public class PlayerShow : MonoBehaviour {
    private bool isReady;
    private static PlayerShow _instance = null;
    public GameObject playerPos1;
    public GameObject playerPos2;
    public GameObject playerPos3;
    public UIWidget roomWidget;

    private GameObject[] playerHeads;

    public static PlayerShow Instance()
    {
        return _instance;
    }
    private void Awake()
    {
        _instance = this;
        playerHeads = new GameObject[3];
    }
    public void Ready()
    {
        isReady = true;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isReady)
        {
            ShowPlayer();
            isReady = false;
        }
	}

    void ShowPlayer()
    {
       RoomManager roomManager = RoomManager.Instance();
        roomManager.InitPlayer();
        int i = 0;
        playerHeads[i++]  = ShowPlayer(roomManager.Player1, playerPos1);
        playerHeads[i++] = ShowPlayer(roomManager.Player2, playerPos2);
        playerHeads[i++] = ShowPlayer(roomManager.Player3, playerPos3);
    }

    private GameObject ShowPlayer(PlayerPlayInfo playerInfo,GameObject playerPos)
    {
        GameObject headWidget = Resources.Load("PlayerHead") as GameObject;
        headWidget = NGUITools.AddChild(roomWidget.gameObject,headWidget);
        UISprite headIconSprite = headWidget.transform.Find("HeadIcon").GetComponent<UISprite>();
        headIconSprite.name = playerInfo.Player.PlayerIcon;
        UILabel playerNameLabel = headWidget.transform.Find("PlayerName").GetComponent<UILabel>();
        playerNameLabel.text = playerInfo.Player.PlayerName;
        headWidget.transform.position = playerPos.transform.position;
        return headWidget;
    }


}
