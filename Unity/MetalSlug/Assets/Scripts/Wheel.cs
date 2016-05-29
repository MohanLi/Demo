using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {

    private bool stop = false;
    private float speed = 500;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!stop)
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * speed);
        }
	}

    public void StopWheel()
    {
        stop = true;
    }

    public void StartWheel()
    {
        stop = false;
    }
}
