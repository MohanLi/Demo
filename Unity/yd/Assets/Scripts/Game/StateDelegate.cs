/*************************************
 * Creator : Mohan
 * Brief   : 状态委托
 * Date    : 5/26/2016 4:32:40 PM
 * Version : 1.0.0
 *
*************************************/
using System;
using System.Collections.Generic;
using UnityEngine;

public class StateDelegate : MonoBehaviour
{
    public delegate void PlayerState(string name);
    public event PlayerState OnStateChange;

    /// <summary>
    /// 玩家状态发生改变时调用
    /// </summary>
    /// <param name="name">状态名称</param>
    public void SwitchPlayerState(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Debug.LogError("=====SwitchPlayerState=======");
        }

        if (null != this.OnStateChange)
        {
            this.OnStateChange(name);
        }
    }
}