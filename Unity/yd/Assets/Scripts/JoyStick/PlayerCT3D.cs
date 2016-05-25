/*************************************
 * Creator : Mohan
 * Brief   : 测试虚拟摇杆 3D 2D
 * Date    : 5/25/2016 3:29:07 PM
 * Version : 1.0.0
 *
*************************************/
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCT3D : MonoBehaviour
{
    public float speed = 10f;
    private JoyStick m_JoyStick;
    private Animator m_Animator;

    void Start()
    {
        m_JoyStick = GameObject.FindObjectOfType<JoyStick>();
        m_JoyStick.OnJoyStickTouchBegin += OnJoyStickBegin;
        m_JoyStick.OnJoyStickTouchMove += OnJoyStickMove;
        m_JoyStick.OnJoyStickTouchEnd += OnJoyStickEnd;

        m_Animator = transform.GetComponent<Animator>();
    }

    void OnJoyStickBegin(Vector2 vec)
    {
        Debug.Log("===========OnJoyStickBegin===========");
    }
    void OnJoyStickMove(Vector2 vec)
    {
        // 设置角色朝向（3D）
        //Quaternion qt3D = Quaternion.LookRotation(new Vector3(vec.x, 0, vec.y));
        //transform.rotation = qt3D;

        //设置角色朝向（2D）
        Quaternion qt2D = Quaternion.LookRotation(new Vector3(vec.x, 0, 0));
        transform.rotation = qt2D;

        //移动角色并播放奔跑动画
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //m_Animator.CrossFade("Run", 0.0f);
    }
    void OnJoyStickEnd(Vector2 vec)
    {
       // m_Animator.CrossFade("Idle", 0.0f);
        Debug.Log("===========OnJoyStickEnd===========");
    }

    /// <summary>
    /// 此方法无卵用，主要是Player状态改变时调用而已
    /// </summary>
    /// <param name="str"></param>
    public void SetPlayerState(string str)
    {

    }
}