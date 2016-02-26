using UnityEngine;
using System.Collections;

public class FruitManager : MonoBehaviour {

    public GameObject[] mFruits;

	// Use this for initialization
	void Start () {
        InvokeRepeating("CreateFruit", 2, 0.5f);
	}

    //随机创建水果
    private void CreateFruit() {
        //水果随机位置
        float posX = Random.Range(-6.5f, 6.5f);
        float posY = -5.75f;
        //x轴方向上的速度
        float xSpeed = 0f; 

        //创建水果
        GameObject fruit = (GameObject)Instantiate(mFruits[Random.Range(0, mFruits.Length)]);
        fruit.transform.position = new Vector3(posX, posY, 0);

        //-6.5至-3往右抛，
        if (posX <= -3f) {
            xSpeed = Random.Range(2f, 4f);
        } else if (posX < 3f) {
            xSpeed = Random.Range(-1f, 1f);
        } else {
            xSpeed = Random.Range(-4f, -2f);
        }
        fruit.GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, 12f);
    }
}
