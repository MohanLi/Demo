using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BirdFly : MonoBehaviour {
	public float speed;
    public int nextLevel;

	// Use this for initialization
	void Start () {
		//speed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.up * speed * Time.deltaTime);
		} else if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.down * speed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		} else if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		}
	}

	//碰撞检测
	void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "help") { //救了伙伴
            SceneManager.LoadScene(nextLevel);

        } else if (coll.gameObject.tag == "wall") { //碰到墙壁
            transform.position = new Vector3(-8, 3, 0);
            transform.Rotate(new Vector3(1, 1, 1));
        }
	}
}

