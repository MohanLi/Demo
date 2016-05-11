using UnityEngine;
using System.Collections;

public class RunTest : MonoBehaviour
{
    public Transform targetObject;

    // Use this for initialization
    void Start()
    {
        if (targetObject != null)
        {
            transform.GetComponent<NavMeshAgent>().destination = targetObject.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
