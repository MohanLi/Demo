using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    public float tumble;

    void Start()
    {
        //insideUnitSphere返回的事三个随机值 x, y, z
        gameObject.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }
}
