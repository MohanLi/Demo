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

public class GameController : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
      
    }
}