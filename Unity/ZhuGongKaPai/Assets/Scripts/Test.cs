using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LoadLoginUI();
	}
	
    void LoadLoginUI()
    {
		/**
        GameObject obj = ResourceMsg.GetInstance().CreateGameObject("Game/UI/SceneLogin");
        obj.AddComponent<SceneLogin>();

        Destroy(this);
**/
		GameObject obj = SceneMgr.Instance.SwitchScene("Game/UI/SceneLogin");
		obj.AddComponent<SceneLogin>();
    }
}
