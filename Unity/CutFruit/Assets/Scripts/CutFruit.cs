using UnityEngine;
using System.Collections;

public class CutFruit : MonoBehaviour {
    public GameObject mFruit1;
    public GameObject mFruit2;
    public GameObject mKnife;
    public GameObject[] mBlots;
    private BoxCollider2D collider;

	// Use this for initialization
	void Start () {
        collider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) { 
            if (collider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition))) {
                CreateFruit();
                CreateKnife();
                CreateBlot();
                DestroyGameObject(gameObject);
            }
        }
	}

    //创建切碎后的水果
    private void CreateFruit() {
        GameObject fruit1 = (GameObject)Instantiate(mFruit1, gameObject.transform.position, Quaternion.AngleAxis(Random.Range(-30, 30), Vector3.back));
        fruit1.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-6, -2), Random.Range(2, 5));

        GameObject fruit2 = (GameObject)Instantiate(mFruit2, gameObject.transform.position, Quaternion.AngleAxis(Random.Range(-30, 30), Vector3.back));
        fruit2.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(2, 6), Random.Range(2, 5));
    }

    //创建刀光
    private void CreateKnife() {
        GameObject knife = (GameObject)Instantiate(mKnife, transform.position, Quaternion.AngleAxis(Random.Range(-90f, 90f), Vector3.back));
        DestroyGameObject(knife, 1);
    }

    //创建污渍
    private void CreateBlot() {
        GameObject blot = (GameObject)Instantiate(mBlots[Random.Range(0, mBlots.Length)]);
        blot.transform.position = transform.position;
        DestroyGameObject(blot, 1);

    }

    //销毁游戏对象
    private void DestroyGameObject(GameObject obj, float time = 0) {
        if (obj != null) {
            Destroy(obj, time);
        }
    }
}
