using UnityEngine;
using System.Collections;

public class SwanMove : MonoBehaviour 
{
    private float moveSpeed = 4;

    void Start()
    {
        transform.position = new Vector3(22, 3, 0);
    }

    void Update()
    {
        if (transform.position.x > -22)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(22, 3, 0);
        }
    }
}
