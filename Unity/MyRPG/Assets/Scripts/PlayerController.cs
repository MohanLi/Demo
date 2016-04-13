using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    [HideInInspector]
    public bool facingRight = true;   //控制角色朝向
    [HideInInspector]
    public bool jump = false;   //判断角色是否跳起
    public float jumpForce = 1000f;

    public float moveForce = 150;   //添加的刚体力的大小
    public float maxSpeed = 3f; //最大速度

    private bool grounded = false;  //判断角色是否在ground层
    private Transform groundCheck;

    public AudioClip[] jumpClips;

    private Animator anim;

    void Awake()
    {
        groundCheck =  transform.Find("groundCheck");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        //Debug.DrawLine(transform.position, groundCheck.position, Color.red, 1f);

        if (Input.GetButtonDown("Jump") && grounded) 
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");    //获取水平方向输入值[-1, 1]

        anim.SetFloat("Speed", Mathf.Abs(h));

        //设置角色转向
        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }

        Rigidbody2D rgbody2d = GetComponent<Rigidbody2D>();
        //设置角色行进速度
        if (h * rgbody2d.velocity.x < maxSpeed) 
        {
            rgbody2d.AddForce(Vector2.right * moveForce * h);
        }

        if (Mathf.Abs(rgbody2d.velocity.x) > maxSpeed)
        {
            rgbody2d.velocity = new Vector2(Mathf.Sign(rgbody2d.velocity.x) * maxSpeed, rgbody2d.velocity.y);
        }

        //设置角色跳跃
        if (jump)
        {
            anim.SetTrigger("Jump");

            int random = Random.Range(0, jumpClips.Length);
            AudioSource.PlayClipAtPoint(jumpClips[random], transform.position);

            jump = false;
            rgbody2d.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = gameObject.transform.localScale;
        theScale.x *= -1;
        gameObject.transform.localScale = theScale;
    }
}
