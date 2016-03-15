using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
    private int mSpeed = 5;

	// Use this for initialization
	void Start () {
        //初始速度的方向（使用本地坐标）
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * mSpeed;
	}
	 
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "FISH") { 
            //代码不应该在这里写，耦合，应该通知创建渔网
            GameObject web = (GameObject)Instantiate(Resources.Load("Webs/web0"));
            web.transform.SetParent(gameObject.transform.parent);
            web.transform.localPosition = gameObject.transform.localPosition;
            
            Destroy(web, 1);
        }

        Destroy(gameObject);
    }
}
