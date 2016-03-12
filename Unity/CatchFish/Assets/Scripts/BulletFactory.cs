using UnityEngine;
using System.Collections;

public class BulletFactory : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButtonDown(0)) {
            CreateBullet();
        }
	}

    private void CreateBullet() {
        Transform tf = DataManager.GetInstance().GetTransform();
        GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullets/bullet_0"));
        bullet.transform.position = tf.position;
        bullet.transform.rotation = tf.rotation;

        
        //为子弹添加组件
        bullet.AddComponent<DestroyObject>();
        bullet.AddComponent<BulletController>();
    }
}
