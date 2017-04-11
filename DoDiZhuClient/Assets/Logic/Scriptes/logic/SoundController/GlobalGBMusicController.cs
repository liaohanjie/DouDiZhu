using UnityEngine;
using System.Collections;

public class GlobalGBMusicController : MonoBehaviour {

    public GameObject globalBGMusic;
    GameObject myBGMusic;
	// Use this for initialization
	void Start () {
        myBGMusic = GameObject.FindGameObjectWithTag("GlobalBgMusic");
        if(myBGMusic == null)
        {
            myBGMusic = (GameObject)Instantiate(globalBGMusic);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
