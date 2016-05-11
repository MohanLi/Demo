using UnityEngine;
using System.Collections;
using UIFrameWork;

public class TestOne : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UIManager.Instance.OpenUI (EnumUIType.TestOne);
	}
}
