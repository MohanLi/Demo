using UnityEngine;
using System.Collections;
using System;

#region Player 状态 ENUM
public enum EnumPlayerState
{
    IDLE,
    ATTACK,
    RUN,
    JUMP,
    SKILL,
    DAMAGE,
    DEADED,
}
#endregion

public class PlayerController : MonoBehaviour
{
    // Player Runing 的速度
    public float speed = 150.0f;
    // Player 最小X值
    public float minX = 0.0f;
    // Player 最大X值
    public float maxX = 42.0f;

    // Player状态
    EnumPlayerState playerState = EnumPlayerState.IDLE;

    Animator playerAnim;
    Rigidbody playerRigidbody;

    void Awake()
    {
        playerAnim = transform.GetComponent<Animator>();
        playerRigidbody = transform.GetComponent<Rigidbody>();

       Debug.Log("======================" + Enum.GetName(typeof(EnumPlayerState), EnumPlayerState.ATTACK));
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Fire1") && IsCanAttack())
        {
            Attack();
        }

        if (IsCanSkill())
        {
            
        }

        if (Input.GetButtonDown("Jump") && IsCanJump())
        {
            Jump();
        }

        if (h != 0 && IsCanRun())
        {
            Run(h);
        }
        else if (h == 0)
        {
            ChangePlayerState("run", false);
        }

        //CheckDamage();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="damageNum"></param>
    void CheckDamage()
    {
        ChangePlayerState("damage", true);
    }

    /// <summary>
    /// Player Running
    /// </summary>
    /// <param name="h"></param>
    void Run(float h)
    {
        ChangePlayerState("run", true);

        int abs = h < 0 ? -1 : 1;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, abs * Mathf.Abs(transform.localScale.z));

        Vector3 pos = new Vector3(transform.position.x + abs * Time.deltaTime * speed, transform.position.y, transform.position.z);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }

    void Jump()
    {
        SetTrigger("jump");
        playerRigidbody.AddForce(new Vector3(0, 350, 0));
    }

    /// <summary>
    /// 是否可跳(只有Run 和 Idle 状态下可以Jump)
    /// </summary>
    /// <returns>true：可跳； false： 不可调</returns>
    bool IsCanJump()
    {
        bool flag = false;

        EnumPlayerState currentState = GetPlayerState();
        if (currentState == EnumPlayerState.IDLE || currentState == EnumPlayerState.RUN)
        {
            flag = true;
        }
        return flag;
    }

    /// <summary>
    /// 是否可以跑动(暂定只有Idle Run 状态下可以跑动)
    /// </summary>
    /// <returns></returns>
    bool IsCanRun()
    {
        bool flag = false;

        EnumPlayerState currentState = GetPlayerState();
        if (currentState == EnumPlayerState.IDLE || currentState == EnumPlayerState.RUN)
        {
            flag = true;
        }

        return flag;
    }

    /// <summary>
    /// 是否能攻击, Idle 、 Run 、Jump 状态下可攻击
    /// </summary>
    /// <returns></returns>
    bool IsCanAttack()
    {
        bool flag = false;

        EnumPlayerState currentState = GetPlayerState();
        if (currentState == EnumPlayerState.IDLE || currentState == EnumPlayerState.RUN || currentState == EnumPlayerState.JUMP)
        {
            flag = true;
        }
        return flag;
    }

    string GetCurrentClipName()
    {
        AnimatorClipInfo[] clipInfo = playerAnim.GetCurrentAnimatorClipInfo(0);
        return clipInfo[0].clip.name;
    }

    bool IsCanSkill()
    {
        return true;
    }

    /// <summary>
    /// 是否已经死亡
    /// </summary>
    /// <returns></returns>
    bool IsDeaded()
    {
        return false;
    }

    /// <summary>
    /// 攻击
    /// </summary>
    void Attack()
    {
        SetTrigger("attack");
    }

    #region Player 状态（获取/设置）
    EnumPlayerState GetPlayerState()
    {
        return this.playerState;
    }

    /// <summary>
    /// 设置 Player 状态（此函数在Animator clip 动画中调用）
    /// </summary>
    /// <param name="state">状态</param>
    public void SetPlayerState(string state)
    {
        Debug.Log(state);
        switch (state.ToLower())
        {
            case "idle":
                this.playerState = EnumPlayerState.IDLE;
                break;
            case "run":
                this.playerState = EnumPlayerState.RUN;
                break;
            case "jump":
                this.playerState = EnumPlayerState.JUMP;
                break;
            case "attack":
                this.playerState = EnumPlayerState.ATTACK;
                break;
            case "damage":
                this.playerState = EnumPlayerState.DAMAGE;
                break;
            default:
                break;
        }
    }
    #endregion

    #region 设置Player state
    void ChangePlayerState(string stateName, bool flag)
    {
        playerAnim.SetBool(stateName, flag);
    }

    void SetTrigger(string name)
    {
        playerAnim.SetTrigger(name);
    }
    #endregion
}
