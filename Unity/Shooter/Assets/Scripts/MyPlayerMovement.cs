using UnityEngine;
using System.Collections;

public class MyPlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movment;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLenght = 100f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

	
	// Update is called once per frame
	void FixedUpdate () 
    {
        float h = Input.GetAxisRaw("Horizontal"); // -1, 0 , 1
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
	}

    void Move(float h, float v)
    {
        movment.Set(h, 0f, v);
        movment = movment.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movment);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLenght, floorMask))
        {
            //矢量，设置方向
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
