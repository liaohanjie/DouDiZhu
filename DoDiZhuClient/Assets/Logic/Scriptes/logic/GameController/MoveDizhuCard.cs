using UnityEngine;
using System.Collections;

public class MoveDizhuCard : MonoBehaviour {

    public static MoveDizhuCard Instance;
    //最上面显示的地主牌的三个位置
    public GameObject[] dizhuCardPos;
    public void Awake()
    {
        Instance = this;
    }
    public void SetDizhuCardsSprites(UISprite[] dizhuCardsSprites)
    { 
        for(int i= 0;i < 3; i++)
        {
           TweenPosition tweenPos= TweenPosition.Begin(dizhuCardsSprites[i].gameObject, 0.5f, dizhuCardPos[i].transform.position,true);
            tweenPos.PlayForward();
           TweenScale tweenScale = TweenScale.Begin(dizhuCardsSprites[i].gameObject, 0.5f, new Vector3(0.5f, 0.5f, 0.5f));
            tweenScale.PlayForward();
        }
       
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       
	}
}
