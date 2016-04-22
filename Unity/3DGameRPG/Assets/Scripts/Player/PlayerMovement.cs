/***
 * Description : 角色控制（左、右、跳、蹲等等,暂时只考虑使用于2D场景）
 * Creator : Mohan
 * Date : 2016-04-21
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour{
    public float speed = 1f;


    private bool ismoving = false;

    private Rigidbody playerRigidbody;
    private Animation playerAnimation;

    void Awake()
    {
        JoyStick joyStick = GameObject.FindObjectOfType<JoyStick>();
        joyStick.OnJoyStickTouchBegin += OnJoyStickBegin;
        joyStick.OnJoyStickTouchMove += OnJoyStickMove;
        joyStick.OnJoyStickTouchEnd += OnJoyStickEnd;
    }

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animation>();
    }

    void OnJoyStickBegin(Vector2 vec)
    {

    }

    void OnJoyStickMove(Vector2 vec)
    {
        if (vec.x > 0 && vec.x > vec.y)
        {
            MoveRight();
        }
        else if (vec.x < 0 && vec.y > vec.x)
        {
            MoveLeft();
        }
        else if (vec.y > 0 && vec.y > vec.x)
        {
            Jump();
        }
        else
        {
            PickUp();
        }
    }

    void OnJoyStickEnd()
    {
        playerAnimation.CrossFade("Idle");
    }


    void MoveLeft()
    {
        playerAnimation.CrossFade("Run00");

        //旋转方向
        //transform.rotation = Quaternion.Euler(new Vector3(0f, -90f, 0f));
        playerRigidbody.MoveRotation(Quaternion.Euler(new Vector3(0f, -90f, 0f)));

        //playerAnimation.wrapMode = WrapMode.Loop;
        Vector3 targetPos = Vector3.left.normalized * Time.deltaTime * speed;
        playerRigidbody.MovePosition(targetPos + transform.position);
    }

    void MoveRight()
    {
        playerAnimation.CrossFade("Run00");

        //旋转方向
        //transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0f));
        playerRigidbody.MoveRotation(Quaternion.Euler(new Vector3(0f, 90f, 0f)));

        //playerAnimation.wrapMode = WrapMode.Loop;
        Vector3 targetPos = Vector3.right.normalized * Time.deltaTime * speed;
        playerRigidbody.MovePosition(targetPos + transform.position);
    }

    void Jump()
    {
        playerAnimation.CrossFade("Jump");
    }

    void PickUp()
    {
        playerAnimation.CrossFade("PickUp");
    }
}
