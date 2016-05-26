/*************************************
 * Creator : Mohan
 * Brief   : $Description$
 * Date    : 5/26/2016 11:45:14 AM
 * Version : 1.0.0
 *
*************************************/
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FightButtonEvent : MonoBehaviour
{
    /// <summary>
    /// 定义攻击委托事件
    /// </summary>
    public delegate void Attack();

    /// <summary>
    /// 定义技能委托事件
    /// </summary>
    public delegate void Skill();

    /// <summary>
    /// 定义跳跃委托事件
    /// </summary>
    public delegate void Jump();

    /// <summary>
    /// 注册攻击事件
    /// </summary>
    public event Attack OnAttack;

    /// <summary>
    /// 注册技能事件
    /// </summary>
    public event Skill OnSkill;

    /// <summary>
    /// 注册跳跃事件
    /// </summary>
    public event Jump OnJump;

    /// <summary>
    /// 攻击按钮
    /// </summary>
    public Button attackButton;

    /// <summary>
    /// 技能按钮
    /// </summary>
    public Button skillButton;

    /// <summary>
    /// 跳跃按钮
    /// </summary>
    public Button jumpButton;

    void Start()
    {
        RegisterButtonEvent();
    }

    /// <summary>
    /// 注册按钮事件
    /// </summary>
    private void RegisterButtonEvent()
    {
        RegisterButtonCallback(attackButton, AttackCallback);
        RegisterButtonCallback(skillButton, SkillCallback);
        RegisterButtonCallback(jumpButton, JumpCallback);
    }

    /// <summary>
    /// 注册按钮回调
    /// </summary>
    /// <param name="button">按钮</param>
    /// <param name="callback">回调函数</param>
    private void RegisterButtonCallback(Button button, UnityAction callback)
    {
        if (null != button && null != callback)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(callback);
        }
    }

    /// <summary>
    /// 点击攻击按钮回调
    /// </summary>
    private void AttackCallback()
    {
        if (null != this.OnAttack)
        {
            this.OnAttack();
        }
    }

    /// <summary>
    /// 点击技能按钮回调
    /// </summary>
    private void SkillCallback()
    {
        if (null != this.OnSkill)
        {
            this.OnSkill();
        }
    }

    /// <summary>
    /// 点击跳跃按钮回调
    /// </summary>
    private void JumpCallback()
    {
        if (null != this.OnJump)
        {
            this.OnJump();
        }
    }
}