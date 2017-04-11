using UnityEngine;

public class GlobalBGMusic : MonoBehaviour {

	void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
