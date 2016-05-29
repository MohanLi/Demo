using UnityEngine;
using System.Collections;

public class Damper : MonoBehaviour {
    public float speed = 200;
    private bool isRatate = false;
    private float rotate = 0;

	
	// Update is called once per frame
	void Update () {
        if (isRatate && rotate < 90)
        {
            float angle = Time.deltaTime * speed;
            rotate += angle;
            transform.Rotate(Vector3.forward * angle);
        }
	}

    public void StartRotate()
    {
        isRatate = true;
    }
}
