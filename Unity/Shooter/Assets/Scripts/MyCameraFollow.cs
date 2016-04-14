﻿using UnityEngine;
using System.Collections;

public class MyCameraFollow : MonoBehaviour {

    public Transform target;
    public float smooting = 5f;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smooting * Time.deltaTime);
    }
}
