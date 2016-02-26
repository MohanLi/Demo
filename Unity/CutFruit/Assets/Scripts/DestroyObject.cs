using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    //游戏对象超出视野范围内后，销毁
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
