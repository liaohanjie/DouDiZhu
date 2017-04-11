using UnityEngine;
using System.Collections;

public class StartController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string str = "aaaaaaa";
        byte[] bytes = StringUtil.getBytes(str);
        string result  = Md5Util.md5ToString(bytes);
        GameLog.debug("MD5之后：" + result);
        GameLog.debug("长度：" + result.Length);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
