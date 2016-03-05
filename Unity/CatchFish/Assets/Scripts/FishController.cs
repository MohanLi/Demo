using UnityEngine;
using System.Collections;

public class FishController : MonoBehaviour {
    //改变方向的时间
    private float mDirectionTime = 1.5f;
    //当前的时间
    private float mCurrentTime = 0f;
    //鱼游动的速度
    private float mSpeed = 1f;
    //鱼改变方向范围值(-angle, angle)
    private float angle = 10f;

	// Use this for initialization
	void Start () {
        
	}

    //鱼游动
    void MoveFish() {
        transform.Translate(Vector3.right * Time.deltaTime * mSpeed);
    }
    //改变鱼的方向
    void AjustDirection() {
        transform.Rotate(Vector3.back, Random.Range(-angle, angle));
    }

	// Update is called once per frame
    void FixedUpdate() {
        if (mCurrentTime >= mDirectionTime) {
            mCurrentTime = 0f;
            AjustDirection();
        }
        mCurrentTime += Time.deltaTime;
        MoveFish();
       
	}
}
