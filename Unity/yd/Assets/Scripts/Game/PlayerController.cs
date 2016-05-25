/*************************************
 * Creator : Mohan
 * Brief   : $Description$
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
    private JoyStick m_JoyStick;

    void Start()
    {
        InitStateDict();
        m_player = player.AddComponent<Player>();

        m_JoyStick = GameObject.FindObjectOfType<JoyStick>();
        m_JoyStick.OnJoyStickTouchBegin += OnTouchBegin;
        m_JoyStick.OnJoyStickTouchMove += OnTouchMove;
        m_JoyStick.OnJoyStickTouchEnd += OnTouchEnd;
    }

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
            m_stateDict.Add(name[i], (BaseEnum.PlayerState)state.GetValue(i));
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

    public void OnTouchBegin(Vector2 vec)
    {

    }

    public void OnTouchMove(Vector2 vec)
    {
        m_player.Run();
        m_player.SetRotation(new Vector3(vec.x, 0, 0));
    }

    public void OnTouchEnd(Vector2 vec)
    {
        m_player.Idle();
    }

    public void SetPlayerState(string state)
    {

    }
}
