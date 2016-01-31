using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {

    private float speed;
    void Start() {
        speed = 1f; 
    }

    void Update() {
        Move();
    }

    void Move() {
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        Debug.Log(Time.deltaTime);
    }
}
