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
    Player player;

    void Start()
    {
        player = transform.gameObject.AddComponent<Player>();
    }

    public void PlayerSwitchState(string newState)
    {
        
    }
}