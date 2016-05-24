using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnBecameInvisible()
    {
        Debug.Log("OnBecameInvisible name : " + gameObject.name);
    }

    void OnBecameVisible()
    {
        Debug.Log("==================OnBecameVisible name : " + gameObject.name);
    }
}
