/*************************************
 * Creator : Mohan
 * Brief   : 角色控制器
 * Date    : 5/21/2016 11:01:55 AM
 * Version : 1.0.0
 *
*************************************/
using System;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public GameObject player;

    private Dictionary<string, BaseEnum.PlayerState> m_stateDict;
    private Player m_player;

    /// <summary>
    /// 虚拟摇杆代理事件
    /// </summary>
    private JoyStick m_JoyStick;

    /// <summary>
    /// 攻击等按钮代理事件
    /// </summary>
    private FightButtonEvent m_ButtonEvent;

    /// <summary>
    /// 状态代理事件
    /// </summary>
    private StateDelegate m_PlayerState;

    void Start()
    {
        InitStateDict();
        player.AddComponent<StateDelegate>();
        m_player = player.AddComponent<Player>();
        
        InitDelegateEvent();
    }

    #region 注册代理委托事件

    /// <summary>
    /// 初始化代委托理事件
    /// </summary>
    private void InitDelegateEvent()
    {
        m_JoyStick = GameObject.FindObjectOfType<JoyStick>();
        m_JoyStick.OnJoyStickTouchBegin += OnTouchBegin;
        m_JoyStick.OnJoyStickTouchMove += OnTouchMove;
        m_JoyStick.OnJoyStickTouchEnd += OnTouchEnd;

        m_ButtonEvent = GameObject.FindObjectOfType<FightButtonEvent>();
        m_ButtonEvent.OnAttack += OnAttack;
        m_ButtonEvent.OnJump += OnJump;
        m_ButtonEvent.OnSkill += OnSkill;

        m_PlayerState = GameObject.FindObjectOfType<StateDelegate>();
        m_PlayerState.OnStateChange += SwitchPlayerState;
    }

    #endregion

    #region 初始化状态

    /// <summary>
    /// 初始化状态集合
    /// </summary>
    void InitStateDict()
    {
        m_stateDict = new Dictionary<string, BaseEnum.PlayerState>();
        string[] name = Enum.GetNames(typeof(BaseEnum.PlayerState));
        Array state = Enum.GetValues(typeof(BaseEnum.PlayerState));

        for (int i = 0; i < name.Length; i++)
        {
            m_stateDict.Add(name[i].ToLower(), (BaseEnum.PlayerState)state.GetValue(i));
        }
    }

    #endregion

    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="newState">新的状态</param>
    public void SwitchPlayerState(string newState)
    {
        BaseEnum.PlayerState state = m_stateDict[newState.ToLower()];
        if (null != state)
        {
            m_player.SetState(state);
        }
    }

    #region 事件委托回调（执行某个状态）

    public void OnTouchBegin(Vector2 vec)
    {

    }

    public void OnTouchMove(Vector2 vec)
    {
        if (IsCanRun())
        {
            m_player.SetRotation(new Vector3(vec.x, 0, 0));
            m_player.Run();
            m_player.Move();
        }
    }

    public void OnTouchEnd(Vector2 vec)
    {
        m_player.Idle();
    }

    /// <summary>
    /// 攻击
    /// </summary>
    private void OnAttack()
    {
        if (IsCanAttack())
        {
            m_player.Attack();
        }
    }

    /// <summary>
    /// 技能攻击
    /// </summary>
    private void OnSkill()
    {
        if (IsCanSkill())
        {
            m_player.Skill();
        }
    }

    /// <summary>
    /// 跳跃
    /// </summary>
    private void OnJump()
    {
        if (IsCanJump())
        {
            m_player.Jump(Vector3.up * 200);
        }
    }

    /// <summary>
    /// 受击
    /// </summary>
    /// <param name="damage">受击强度</param>
    private void OnDamage(float damage)
    {
        m_player.ReduceHitPoints(damage);
        m_player.Damage();

        if (IsDeath())
        {
            m_player.Dead();
        }
    }

    #endregion

    #region 是否能执行某个动作

    /// <summary>
    /// 是否能跑动（受击、放技能、攻击、跳跃、死亡状态下不能跑动）
    /// </summary>
    /// <returns>false ： 否  true ： 是</returns>
    private bool IsCanRun()
    {
        BaseEnum.PlayerState curState = m_player.GetState();
        if (curState == BaseEnum.PlayerState.DAMAGE || curState == BaseEnum.PlayerState.SKILL ||
            curState == BaseEnum.PlayerState.ATTACK || curState == BaseEnum.PlayerState.JUMP ||
            curState == BaseEnum.PlayerState.DEATH)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// 是否能跳跃，不能连跳（受击、放技能、攻击、死亡、跳跃状态下不能跳跃）
    /// </summary>
    /// <returns>false ： 否  true ： 是</returns>
    private bool IsCanJump()
    {
        BaseEnum.PlayerState curState = m_player.GetState();
        if (curState == BaseEnum.PlayerState.DAMAGE || curState == BaseEnum.PlayerState.SKILL ||
            curState == BaseEnum.PlayerState.ATTACK || curState == BaseEnum.PlayerState.DEATH ||
            curState == BaseEnum.PlayerState.JUMP)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// 是否能攻击（受击、放技能、攻击、死亡等状态下不能攻击）
    /// </summary>
    /// <returns>false : 否  true : 是</returns>
    private bool IsCanAttack()
    {
        BaseEnum.PlayerState curState = m_player.GetState();
        if (curState == BaseEnum.PlayerState.DAMAGE || curState == BaseEnum.PlayerState.SKILL ||
            curState == BaseEnum.PlayerState.ATTACK || curState == BaseEnum.PlayerState.DEATH)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// 是否能放技能 （受击、放技能、攻击、死亡、跳跃等状态下不能放技能）
    /// </summary>
    /// <returns>false : 否  true : 是</returns>
    private bool IsCanSkill()
    {
        BaseEnum.PlayerState curState = m_player.GetState();
        if (curState == BaseEnum.PlayerState.DAMAGE || curState == BaseEnum.PlayerState.SKILL ||
            curState == BaseEnum.PlayerState.ATTACK || curState == BaseEnum.PlayerState.DEATH ||
            curState == BaseEnum.PlayerState.JUMP)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// 是否已经死亡
    /// </summary>
    /// <returns>false ： 否  true ： 是</returns>
    private bool IsDeath()
    {
        return m_player.GetHitPoints() <= 0;
    }

    #endregion
}
