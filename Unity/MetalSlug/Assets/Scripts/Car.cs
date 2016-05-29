using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

    public Vector3 targetPos;
    public Vector3 endTargetPos = new Vector3(7, 0, 0);
    public float smoothing = 2.0f;
    private AudioSource m_audio;

    private bool isStopWheel = false;

    public Damper damper;
    public Wheel[] wheels;

	// Use this for initialization
	void Start () {
        m_audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothing);

        if (!isStopWheel && Vector3.Distance(transform.position, targetPos) < 0.8f)
        {
            isStopWheel = true;
            m_audio.Play();
            ReadyArrive();
        }
	}

    void ReadyArrive()
    {
        foreach (Wheel wheel in wheels)
        {
            wheel.StopWheel();
        }
        //放下挡板
        damper.StartRotate();
        //放下主角

        //车开走
        Invoke("GoOut", 1f);
    }

    void GoOut()
    {
        foreach (Wheel wheel in wheels)
        {
            wheel.StartWheel();
        }
        targetPos = endTargetPos;

        Destroy(this.gameObject, 1);
    }
}
