using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public float speed = 30f;
    public Rigidbody2D rocket;
    private PlayerController playerController;
    private Animator anim;

    void Awake()
    {
        anim = transform.root.GetComponent<Animator>();
        playerController = transform.root.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Shoot");
            GetComponent<AudioSource>().Play();

            if (playerController.facingRight)
            {
                Rigidbody2D rocketInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                rocketInstance.velocity = new Vector2(speed, 0f);
            }
            else
            {
                Rigidbody2D rocketInstance = (Rigidbody2D)Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
                rocketInstance.velocity = new Vector2(-speed, 0f);
            }
        }
	}
}
