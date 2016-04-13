using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [HideInInspector]
    public Transform player;

    private Animation anim;

    void Awake()
    {
        anim = GetComponent<Animation>();
        player = transform;
    }

	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.Play("Run");
            player.position += Vector3.forward * Time.deltaTime * 2;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.Play("Run");
            player.position += Vector3.right * Time.deltaTime * 2;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.Play("Run");
            player.position += Vector3.left * Time.deltaTime * 2;
        }
        else 
        {
            anim.Play("Idle");
        }
	}

    void FixedUpdate()
    { 
        
    }
}
