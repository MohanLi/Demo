using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {
    public Transform[] mBackground;
    public float parallaxReductionFactor;
    public float parallaScale;
    public float smooting;

    private Transform mCamera;
    private Vector3 mPrePosition;

	// Use this for initialization
	void Start () {
        mCamera = Camera.main.transform;
        mPrePosition = mCamera.position;
	}
	
	// Update is called once per frame
	void Update () {
        float parallax = (mCamera.position.x - mPrePosition.x) * parallaScale;

        for (int i = 0; i < mBackground.Length; i++) {
            float backgroundTargetPosX = mBackground[i].position.x + (i * parallaxReductionFactor + 1) * parallax;
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, mBackground[i].position.y, mBackground[i].position.z);
            mBackground[i].position = Vector3.Lerp(mBackground[i].position, backgroundTargetPos, smooting * Time.deltaTime);
        }
        mPrePosition = mCamera.position;
	}

    void FixedUpdate() {
       // int unm = Random.Range(1, 3);
       // Vector3 pos = new Vector3(mCamera.position.x +0.01f* Mathf.Pow(-1f, unm), mCamera.position.y, mCamera.position.z);
       // mCamera.position = pos;// Vector3.Lerp(mCamera.position, pos, Time.deltaTime * 0.01f);
        
        /**
        float x = Input.GetAxis("Horizontal");
        mCamera.position = new Vector3(x, mCamera.position.y, mCamera.position.z);
        Debug.Log(mCamera.position);
        **/
    }
}
