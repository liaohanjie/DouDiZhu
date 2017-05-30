using UnityEngine;
using System.Collections;

public class UIPlayerController : MonoBehaviour {

    public GameObject leftHeadPos;
    public GameObject rightHeadPos;
    public GameObject bottomHeadPos;

    public UIButton readyBtn;

    public UIWidget roomContainer;
    public UIAtlas gameUiAtlas;

    private PlayerManager playerManager = PlayerManager.Instance;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /// <summary>
    /// 点击准备
    /// </summary>
    public void ReadyBtnOnClick()
    {
        readyBtn.gameObject.SetActive(false);
        initPlayerInfo();
        InitCardsController.Instance.initCardsSprites();
        InitCardsController.Instance.startSendCards();
    }

    /// <summary>
    /// 初始化登陆用户信息
    /// </summary>
    public void initPlayerInfo()
    {
        playerManager.RandomPlayer();
        PlayerInfo[] playerInfos =playerManager.getPlayerInfos();
        foreach (PlayerInfo playerInfo in playerInfos)
        {
            addPlayerHeadSprite(playerInfo);
        }
    }

    public void addPlayerHeadSprite(PlayerInfo playerInfo)
    {
        int pos = playerInfo.PlayerPos;
        GameLog.debug(playerInfo.PlayerPos.ToString());
        GameObject posGameObj = null;
        UIPlayerInfo uiPlayerInfo = UIPlayerManager.getInstsance().getUIPlayerInfo(playerInfo.PlayerId); ;
        switch (pos)
        {
            case 1:
                posGameObj = bottomHeadPos;

                break;
            case 2:
                posGameObj = rightHeadPos;
                break;
            case 3:
                posGameObj = leftHeadPos;
                break;
        }
        GameObject headGameObject = Resources.Load("HeadSprite") as GameObject;
        headGameObject = NGUITools.AddChild(roomContainer.gameObject, headGameObject);
        UISprite headSprite = headGameObject.GetComponent<UISprite>();
        UILabel nameLabel = headGameObject.transform.Find("NameLabel").GetComponent<UILabel>();
        nameLabel.text = playerInfo.PlayerName;
        headSprite.transform.position = posGameObj.transform.position;
        headSprite.name = playerInfo.Icon;
        uiPlayerInfo.HeadSprite = headSprite;
        headSprite.depth = 102;



    }
}
