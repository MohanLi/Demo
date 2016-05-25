﻿/*************************************
 * Creator : Mohan
 * Brief   : $Description$
 * Date    : 5/20/2016 3:42:11 PM
 * Version : 1.0.0
 *
*************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    #region 成员函数定义
    private Animator m_PlayerAnim;
    private Rigidbody m_PlayerRigidbody;

    //奔跑速度
    private float m_RunSpeed = 3.0f;
    // 攻击范围
    private float m_AttackRange;
    // 当前状态 默认Idle
    private BaseEnum.PlayerState m_PlayerState = BaseEnum.PlayerState.IDLE;
    // 朝向
    private BaseEnum.PlayerOrientation m_PlayerOrientation = BaseEnum.PlayerOrientation.RIGTH;

    #endregion

    #region 生命值HP
    // 生命值
    private float m_PitPoints = 999.0f;
    public float HitPoints
    {
        get
        {
            return m_PitPoints;
        }
        private set
        {
            m_PitPoints = value < 0 ? 0 : value;
        }
    }
    #endregion

    #region 系统函数 Start
    void Start()
    {
        m_PlayerRigidbody = transform.GetComponent<Rigidbody>();
        m_PlayerAnim = transform.GetComponent<Animator>();

        if (null == m_PlayerAnim)
        {
            Debug.LogError("Can Not Get The Player Animator!!!!");
        }
    }
    #endregion

    #region 停止/播放动画 StopClipByName PlayAnimator PlayAnimatorByTrigger
    /// <summary>
    /// 播放动画Clip
    /// </summary>
    /// <param name="stateName">要播放的Clip名称</param>
    /// <param name="flag">true:播放 false:停止</param>
    private void PlayAnimator(BaseEnum.PlayerState stateName)//, bool flag = true
    {
        if (stateName == GetState()) return;

        //===================写法有待改进=====================
        StopClipByName(GetState());
        string name = GetName(typeof(BaseEnum.PlayerState), stateName);
        SetState(stateName);
        //===================写法有待改进=====================

        m_PlayerAnim.SetBool(name, true);
    }

    private void PlayAnimatorByTrigger(BaseEnum.PlayerState stateName)
    {
        string name = GetName(typeof(BaseEnum.PlayerState), stateName);
        m_PlayerAnim.SetTrigger(name);
    }

    /// <summary>
    /// 停止某一动画Clip
    /// </summary>
    /// <param name="name"></param>
    public void StopClipByName(BaseEnum.PlayerState stateName)
    {
        string name = GetName(typeof(BaseEnum.PlayerState), stateName);
        m_PlayerAnim.SetBool(name, false);
    }

    /// <summary>
    /// enum to string
    /// </summary>
    /// <param name="enumType">要转换的类型</param>
    /// <param name="value">需要转换的值</param>
    /// <returns></returns>
    private string GetName(Type enumType, object value)
    {
        return Enum.GetName(enumType, value).ToLower();
    }

    #endregion

    #region Player 行为动画

    /// <summary>
    /// Idle
    /// </summary>
    public void Idle()
    {
        PlayAnimator(BaseEnum.PlayerState.IDLE);
    }

    /// <summary>
    /// 攻击 （攻击方式可能有多种，此处只考虑一种的情况）
    /// </summary>
    public void Attack()
    {
        PlayAnimator(BaseEnum.PlayerState.ATTACK);
    }

    /// <summary>
    /// 奔跑
    /// </summary>
    public void Run()
    {
        PlayAnimator(BaseEnum.PlayerState.RUN);
        transform.Translate(Vector3.forward * m_RunSpeed * Time.deltaTime);
    }

    /// <summary>
    /// 跳跃
    /// </summary>
    public void Jump(Vector3 force)
    {
        PlayAnimator(BaseEnum.PlayerState.JUMP);
        m_PlayerRigidbody.AddForce(force);
    }

    /// <summary>
    /// 技能（技能可能分为很多种，此处先考虑只有一种技能的轻快）
    /// </summary>
    public void Skill()
    {
        PlayAnimator(BaseEnum.PlayerState.SKILL);
    }

    /// <summary>
    /// 受击
    /// </summary>
    public void Damage()
    {
        PlayAnimator(BaseEnum.PlayerState.DAMAGE);
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void Dead()
    {
        PlayAnimator(BaseEnum.PlayerState.DEATH);
    }
    #endregion

    #region 受击减少HP
    /// <summary>
    /// 受击后HP减少
    /// </summary>
    /// <param name="reduceHP">较少的HP</param>
    public void ReduceHitPoints(float reduceHP)
    {
        HitPoints -= reduceHP;
    }
    #endregion

    #region set|get Player 状态
    /// <summary>
    /// 获取当前状态
    /// </summary>
    /// <returns>返回当前状态</returns>
    public BaseEnum.PlayerState GetState()
    {
        return m_PlayerState;
    }

    /// <summary>
    /// 设置当前状态
    /// </summary>
    /// <param name="state"></param>
    public void SetState(BaseEnum.PlayerState state)
    {
        if (m_PlayerState != state)
        {
            m_PlayerState = state;
        }
    }
    #endregion

    #region GetPosition()  GetAttackRange()

    /// <summary>
    /// 获取位置
    /// </summary>
    /// <returns></returns>
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    /// <summary>
    /// 获取攻击范围
    /// </summary>
    /// <returns></returns>
    public float GetAttackRange()
    {
        return m_AttackRange;
    }

    #endregion

    /// <summary>
    /// 控制角色旋转（朝向）
    /// </summary>
    /// <param name="vect"></param>
    public void SetRotation(Vector3 vect)
    {
        Quaternion qt = Quaternion.LookRotation(vect);
        transform.rotation = qt;

        if (vect.x > 0)
        {
            SetOrientation(BaseEnum.PlayerOrientation.RIGTH);
        }
        else if (vect.x < 0)
        {
            SetOrientation(BaseEnum.PlayerOrientation.LEFT);
        }
    }

    #region Set|Get 角色朝向

    /// <summary>
    /// 设置角色朝向
    /// </summary>
    /// <param name="orientation">朝向</param>
    private void SetOrientation(BaseEnum.PlayerOrientation orientation)
    {
        if (m_PlayerOrientation != orientation)
        {
            m_PlayerOrientation = orientation;
        }
    }

    /// <summary>
    /// 获取角色朝向
    /// </summary>
    /// <returns></returns>
    public BaseEnum.PlayerOrientation GetOrientation()
    {
        return m_PlayerOrientation;
    }

    #endregion
}
