using UnityEngine;
using System.Collections;

public class JiaoDiZhu : MonoBehaviour {
    public static JiaoDiZhu Instance;

    private bool started = false;
    private int pos;
    //叫地主最大用时时间，15秒
    private const int maxUserSecond = 15;
    private int leftSecond = maxUserSecond;
    private float totalTime;

    #region 属性
    public bool Started
    {
        get
        {
            return started;
        }

        set
        {
            started = value;
        }
    }

    private void RandomFirstPos()
    {
       
    }

    #endregion
    void Awake()
    {
        Instance = this;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (started)
        {
            totalTime += Time.deltaTime;
            if(totalTime >= 1)
            {
                totalTime = 0;
                leftSecond--;
            }

            if(leftSecond <= 0)
            {
                //不叫，换下一个开始叫地主
                leftSecond = maxUserSecond;
                nextPos();
            }
        }
	}



    private void nextPos()
    {
        pos++;
        if(pos > 3)
        {
            pos = 1;
        }
      
    }
}
