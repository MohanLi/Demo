using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;

    void Start() 
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * speed;   
    }
}
