using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    Vector3 offSet;
    Transform player;
    float speed = 10f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offSet = transform.position - player.position;
    }

    void FixedUpdate()
    {
        transform.position  = Vector3.Lerp(transform.position, player.position + offSet, speed * Time.deltaTime);
    }
}
