using UnityEngine;
using System.Collections;
/// <summary>
/// 叫分判断
/// </summary>
public class ScoreSelectController : MonoBehaviour {

    public static ScoreSelectController Instance;
    public UIWidget selectScordContainer;
    private bool isStarted;

    

    public bool IsStarted
    {
        get
        {
            return isStarted;
        }

        set
        {
            isStarted = value;
        }
    }

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
    /// <summary>
    /// 随机一个机会首先叫分，如果是玩家本人，则显示叫份，如果不是，则直接随机出一个地主。
    /// </summary>
    public void randomCallScore()
    {
        int value = Random.Range(1,100);
        if(value >= 1 && value < 50)
        {
            selectScordContainer.gameObject.SetActive(true);
            InitCardsController.Instance.showDiZhuCard();
        } else 
        {
            randomDiZhu();
        }
    }
    /// <summary>
    /// 随机出一个地主
    /// </summary>
    private void randomDiZhu()
    {
        int pos = 0;
        int value = Random.Range(1,100);
        if (value >= 50 && value <= 100)
        {
            pos = 2;
        }
        else
        {
            pos = 3;
        }
        int score = Random.Range(1, 3);
        PlayerInfo playerInfo = PlayerManager.Instance.getPlayerInfoByPos(pos);
        RoomInfo.Instance().DizhuPlayerId = playerInfo.PlayerId;
        RoomInfo.Instance().Score = score;
        InitCardsController.Instance.showDiZhuCard();
    }

    public void OnOneScordButtonClick()
    {
        RoomInfo.Instance().Score = 1;
        selectScordContainer.gameObject.SetActive(false);
        randomDiZhu();

    }

    public void OnSecondScordButtonClick()
    {
        RoomInfo.Instance().Score = 2;
        selectScordContainer.gameObject.SetActive(false);
        randomDiZhu();
    }

    public void OnThreeScordButtonClick()
    {
        RoomInfo.Instance().Score = 3;
        long  dizhuPlayerId = PlayerManager.Instance.getPlayerInfoByPos(1).PlayerId;
        RoomInfo.Instance().DizhuPlayerId = dizhuPlayerId;
        selectScordContainer.gameObject.SetActive(false);
        UIRoomController.Instance.showButtonContainer();
    }

    public void AfterSureDiZhu(long dizhuPlayerId)
    {
        InitCardsController.Instance.showDiZhuCard();
        //UIPlayerManager.getInstsance().setDiZhuIcon(dizhuPlayerId);
        // UIPlayerManager.getInstsance().setPeasantIcon(dizhuPlayerId);
       
    }


}
