using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyPlay : MonoBehaviour {

    public UIButton readyBtn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnReadyButtonClick()
    {
        readyBtn.gameObject.SetActive(false);
        PlayerShow.Instance().Ready();
    }
}
