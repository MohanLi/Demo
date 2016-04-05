using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {
    public Transform[] mBackground;

    private Transform mCamera;
    private Vector3 mPrePosition;

	// Use this for initialization
	void Start () {
        mCamera = Camera.main.transform;
        mPrePosition = mCamera.position;
	}
	
	// Update is called once per frame
	void Update () {
        float posX = mCamera.position.x - mPrePosition.x;
	}
}
