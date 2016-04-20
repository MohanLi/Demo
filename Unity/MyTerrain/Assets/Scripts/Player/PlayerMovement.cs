using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 0.05f;
    private JoyStick joyStick;
    private bool isMoving;

    Animation anim;
    Rigidbody playerRigidbody;

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();

        joyStick = GameObject.FindObjectOfType<JoyStick>();
        joyStick.OnJoyStickTouchBegin += OnJoyStickBegin;
        joyStick.OnJoyStickTouchMove += OnJoyStickMove;
        joyStick.OnJoyStickTouchEnd += OnJoyStickEnd;
    }

    void OnJoyStickBegin(Vector2 vec)
    {
        Debug.Log("On Touch Begin");
    }

    double count = 0;
    void OnJoyStickMove(Vector2 vec)
    {
        Debug.Log(count + "-Vector2 vec.x : " + vec.x + " , Vector2 vec.y : " + vec.x);
        Turning(vec);
        Move();
    }

    void OnJoyStickEnd()
    {
        Debug.Log("On Touch End");
        anim.Play("Idle");
    }

    void Turning(Vector2 vec)
    { 
        Quaternion rot = Quaternion.LookRotation(new Vector3(vec.x, 0f, vec.y));
        //transform.rotation = rot;
        playerRigidbody.MoveRotation(rot);
    }

    void Move()
    {
        playerRigidbody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        anim.Play("Run");
    }

    /*****
    int floorMask;
    Vector3 movement;
    Rigidbody playerRigidbody;
    Animator anim;
    Animation animation;
    float camRayLenght = 100f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        animation = GetComponent<Animation>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Turning();
        Move(h, v);
        Animating(h, v);
    }

    void Turning()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        if (Physics.Raycast(ray, out rayHit, camRayLenght, floorMask))
        {
            Vector3 playerToMouse = rayHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion rot = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(rot);
        }
        
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        if (h != 0 || v != 0) 
        {
            playerRigidbody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }
    }

    void Animating(float h, float v)
    {
        bool run = h != 0 || v != 0;
        //anim.SetBool("Run", true);

        if (run)
        {
            animation.Play("Run");
        }
        else
        {
            animation.Play("Idle");
        }
    }
    ******/
}
