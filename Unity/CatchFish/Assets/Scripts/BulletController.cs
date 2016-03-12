using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
    private int mSpeed = 5;

	// Use this for initialization
	void Start () {
        //初始速度的方向（使用本地坐标）
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * mSpeed;
	}
	 
	// Update is called once per frame
	void FixedUpdate () {
        
	}

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "FISH") { 
            
        }

        Destroy(gameObject);
    }
}
