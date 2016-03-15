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
    //HP
    private int mHP = 3;

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

    //void OnCollisionEnter2D(Collision2D coll) {
    //    if (coll.gameObject.tag == "WEB") {
    //        mHP--;
    //    }
    //    if (mHP <= 0) {
    //        Destroy(gameObject);
    //        //通知更新分数
    //    }
    //    Debug.Log(coll.gameObject.tag + "=================" + mHP);
    //}
    
    //没有物理碰撞
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "WEB")
        {
            mHP--;
        }
        if (mHP <= 0)
        {
            Destroy(gameObject);
            //通知更新分数
        }
    }
}
