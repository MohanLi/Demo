/*************************************
 * Author : Mohan
 * Desc : $Description$
 * Date : 5/13/2016 4:16:27 PM
 * Version : 1.0.0
 *
*************************************/
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrameWork
{
    public class GameStart : MonoBehaviour
    {
        void Start()
        {
            UIManager.Instance.OpenUI(EnumUIType.TestOne);
        }
    }
}
