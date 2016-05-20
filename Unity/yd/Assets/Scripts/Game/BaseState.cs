/*************************************
 * Creator : Mohan
 * Brief   : $Description$
 * Date    : 5/20/2016 3:43:30 PM
 * Version : 1.0.0
 *
*************************************/
using System;
using System.Collections.Generic;

public class BaseState
{
    public enum PlayerState
    {
        IDLE,
        ATTACK,
        RUN,
        JUMP,
        SKILL,
        DAMAGE,
        DEATH,
    }
}