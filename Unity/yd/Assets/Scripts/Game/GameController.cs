/*************************************
 * Creator : Mohan
 * Brief   : $Description$
 * Date    : 5/21/2016 7:03:30 AM
 * Version : 1.0.0
 *
*************************************/
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MH
{
    public class GameController : MonoBehaviour
    {
        private Player player;

        void Start()
        {
            InitPlayer();
        }

        void InitPlayer()
        {
            //player = GameObject.Find("Player").GetComponent<Player>();
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            player = go.GetComponent<Player>();
            if (null == player)
            {
                player = go.AddComponent<Player>();
            }
        }

        void Update()
        {
            CheckPlayerMove();
        }

        void CheckPlayerMove()
        {
            float h = Input.GetAxis("Horizontal");
        }
    }
}