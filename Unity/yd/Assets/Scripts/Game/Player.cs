/*************************************
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
    private Animator playerAnim;
    private Rigidbody playerRigidbody;

    // 攻击范围
    private float attackRange;
    // 当前状态 默认Idle
    private BaseState.PlayerState playerState = BaseState.PlayerState.IDLE;
    // 朝向
    private BaseState.PlayerOrientation playerOrientation = BaseState.PlayerOrientation.RIGTH;

    #endregion

    #region 生命值HP
    // 生命值
    private float hitPoints = 999.0f;
    public float HitPoints
    {
        get
        {
            return hitPoints;
        }
        private set
        {
            hitPoints = value < 0 ? 0 : value;
        }
    }
    #endregion

    #region 系统函数 Start
    void Start()
    {
        playerRigidbody = transform.GetComponent<Rigidbody>();
        playerAnim = transform.GetComponent<Animator>();

        if (null == playerAnim)
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
    private void PlayAnimator(BaseState.PlayerState stateName, bool flag = true)
    {
        string name = GetName(typeof(BaseState.PlayerState), stateName);
        playerAnim.SetBool(name, flag);
    }

    private void PlayAnimatorByTrigger(BaseState.PlayerState stateName)
    {
        string name = GetName(typeof(BaseState.PlayerState), stateName);
        playerAnim.SetTrigger(name);
    }

    /// <summary>
    /// 停止某一动画Clip
    /// </summary>
    /// <param name="name"></param>
    public void StopClipByName(BaseState.PlayerState stateName)
    {
        string name = GetName(typeof(BaseState.PlayerState), stateName);
        playerAnim.SetBool(name, false);
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
        PlayAnimator(BaseState.PlayerState.IDLE);
    }

    /// <summary>
    /// 攻击 （攻击方式可能有多种，此处只考虑一种的情况）
    /// </summary>
    public void Attack()
    {
        PlayAnimator(BaseState.PlayerState.ATTACK);
    }

    /// <summary>
    /// 奔跑
    /// </summary>
    public void Run()
    {
        PlayAnimator(BaseState.PlayerState.RUN);
    }

    /// <summary>
    /// 跳跃
    /// </summary>
    public void Jump(Vector3 force)
    {
        PlayAnimator(BaseState.PlayerState.JUMP);
        playerRigidbody.AddForce(force);
    }

    /// <summary>
    /// 技能（技能可能分为很多种，此处先考虑只有一种技能的轻快）
    /// </summary>
    public void Skill()
    {
        PlayAnimator(BaseState.PlayerState.SKILL);
    }

    /// <summary>
    /// 受击
    /// </summary>
    public void Damage()
    {
        PlayAnimator(BaseState.PlayerState.DAMAGE);
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void Dead()
    {
        PlayAnimator(BaseState.PlayerState.DEATH);
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
    public BaseState.PlayerState GetPlayerState()
    {
        return playerState;
    }

    /// <summary>
    /// 设置当前状态
    /// </summary>
    /// <param name="state"></param>
    public void SetPlayerState(BaseState.PlayerState state)
    {
        if (playerState != state)
        {
            playerState = state;
        }
    }
    #endregion

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
        return attackRange;
    }

    #region set/get 角色朝向

    /// <summary>
    /// 设置角色朝向
    /// </summary>
    /// <param name="orientation">朝向</param>
    public void SetPlayerOrientation(BaseState.PlayerOrientation orientation)
    {
        if (playerOrientation != orientation)
        {
            playerOrientation = orientation;
        }
    }

    /// <summary>
    /// 获取角色朝向
    /// </summary>
    /// <returns></returns>
    public BaseState.PlayerOrientation GetPlayerOrientation()
    {
        return playerOrientation;
    }

    #endregion
}