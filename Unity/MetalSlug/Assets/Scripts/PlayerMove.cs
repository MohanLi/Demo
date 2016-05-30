using UnityEngine;
using System.Collections;

public enum PlayerState
{
    PlayerGround,
    PlayerJump,
    PlayerDown
}

public class PlayerMove : MonoBehaviour
{
    public PlayerJump playerJump;
    public PlayerGround playerGround;
    public PlayerDown playerDown;

    private Rigidbody m_Rigidbody;

    private float m_Speed = 3;
    private float m_JumpSpeed = 4;
    private float m_DownWalkSpeed = 1;

    private PlayerState m_State = PlayerState.PlayerJump;
    private int m_GroundLayerMask;
    private bool m_IsGround = false;
    private bool m_IsButtomKeyClick = false;

    void Start()
    {
        m_GroundLayerMask = LayerMask.GetMask("Ground");
        m_Rigidbody = transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //射线检测
        RaycastHit hitInfo;
        m_IsGround = Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, out hitInfo, 0.5f, m_GroundLayerMask);

        Debug.DrawRay(transform.position + Vector3.up * 0.01f, Vector3.down, Color.white);

        //蹲下
        if (Input.GetKeyDown(KeyCode.S))
        {
            m_IsButtomKeyClick = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            m_IsButtomKeyClick = false;
        }

        //设置状态
        if (!m_IsGround)
        {
            m_State = PlayerState.PlayerJump;
        }
        else if (m_IsButtomKeyClick)
        {
            m_State = PlayerState.PlayerDown;
        }
        else
        {
            m_State = PlayerState.PlayerGround;
        }

        if (m_IsGround && Input.GetButtonDown("Jump"))
        {
            Vector3 vlcity = m_Rigidbody.velocity;
            m_Rigidbody.velocity = new Vector3(vlcity.x, m_JumpSpeed, vlcity.z);
        }

        //根据状态选择不同的动画
        switch(m_State)
        {
            case PlayerState.PlayerGround:
                playerGround.gameObject.SetActive(true);
                playerDown.gameObject.SetActive(false);
                playerJump.gameObject.SetActive(false);
                break;
            case PlayerState.PlayerDown:
                playerGround.gameObject.SetActive(false);
                playerDown.gameObject.SetActive(true);
                playerJump.gameObject.SetActive(false);
                break;
            case PlayerState.PlayerJump:
                playerGround.gameObject.SetActive(false);
                playerDown.gameObject.SetActive(false);
                playerJump.gameObject.SetActive(true);
                break;
        }

        // 根据速度设置朝向
        int dire = 0;
        if (m_Rigidbody.velocity.x > 0.05f)
        {
            dire = -1;
        }
        else if (m_Rigidbody.velocity.x < 0.05f)
        {
            dire = 1;
        }
        else
        {
            dire = 0;
        }
        if (dire != 0)
        {
            playerGround.transform.localScale = new Vector3(dire, 1, 1);
            playerJump.transform.localScale = new Vector3(dire, 1, 1);
            playerDown.transform.localScale = new Vector3(dire, 1, 1);
        }

        //设置idle、walk状态
        if (Mathf.Abs(m_Rigidbody.velocity.x ) > 0.05f)
        {
            playerGround.state = AnimState.Walk;
            playerDown.state = AnimState.Walk;
        }
        else
        {
            playerGround.state = AnimState.Idle;
            playerDown.state = AnimState.Idle;
        }

        //左右移动
        float speed = PlayerState.PlayerDown == m_State ? m_DownWalkSpeed : m_Speed;
        float h = Input.GetAxis("Horizontal");
        Vector3 v = m_Rigidbody.velocity;
        m_Rigidbody.velocity = new Vector3(h * speed, v.y, v.z);
    }
}