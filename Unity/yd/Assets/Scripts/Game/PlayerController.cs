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

namespace MH
{
    public class PlayerController : MonoBehaviour
    {
        Dictionary<string, BaseEnum.PlayerState> stateDict;
        Player player;

        void Start()
        {
            InitStateDict();


            player = transform.gameObject.AddComponent<Player>();
        }

        /// <summary>
        /// 初始化状态集合
        /// </summary>
        void InitStateDict()
        {
            stateDict = new Dictionary<string, BaseEnum.PlayerState>();
            string[] name = Enum.GetNames(typeof(BaseEnum.PlayerState));
            Array state = Enum.GetValues(typeof(BaseEnum.PlayerState));

            for (int i = 0; i < name.Length; i++)
            {
                stateDict.Add(name[i], (BaseEnum.PlayerState)state.GetValue(i));
            }
        }

        public void SwitchPlayerState(string newState)
        {
            player.SetState(stateDict[newState.ToLower()]);
        }
    }
}