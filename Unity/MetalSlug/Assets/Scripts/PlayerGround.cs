/*************************************
 * Creator : Mohan
 * Brief   : $Description$
 * Date    : 5/30/2016 8:27:11 AM
 * Version : 1.0.0
 *
*************************************/
using System;
using System.Collections.Generic;
using UnityEngine;

public enum AnimState
{
    Idle,
    Walk,
    Down,
    Jump
}


public class PlayerGround : MonoBehaviour
{
    #region Idle状态下的变量

    public SpriteRenderer idleUpRender;
    public Sprite[] idleUpSpriteArray;

    public float speed = 10;
    public float idleUpIntervalTime = 0;

    private int idleUpIndex = 0;
    private int idleDownIndex = 0;
    private int idleUpLenght = 0;
    private int idleDownLenght = 0;
    private float idleUpTime = 0;

    public SpriteRenderer idleDownRender;
    public Sprite[] idleDownSpriteArray;

    #endregion

    #region Walk状态下的变量
    public SpriteRenderer walkUpRenderer;
    public Sprite[] walkUpSpriteArray;
    public float walkUpIntervalTime = 0;
    private int walkUpIndex = 0;
    private int walkUpLenght = 0;
    private float walkUpTimer = 0;

    public SpriteRenderer walkDownRenderer;
    public Sprite[] walkDownSpriteArray;
    public float walkDownIntervalTime = 0;
    private int walkDownIndex = 0;
    private int walkDownLenght = 0;
    private float walkDownTimer = 0;

    #endregion

    public AnimState state = AnimState.Idle;

    void Start()
    {
        idleUpIntervalTime = 1 / speed;
        walkUpIntervalTime = 1 / speed;// walkUpSpeed;
        walkDownIntervalTime = 1 / speed;// walkDownSpeed;

        idleUpLenght = idleUpSpriteArray.Length;
        idleDownLenght = idleDownSpriteArray.Length;
        walkUpLenght = walkUpSpriteArray.Length;
        walkDownLenght = walkDownSpriteArray.Length;
    }

    void Update()
    {
        switch(state)
        {
            case AnimState.Idle:
                PlayIdleAnim();
                break;
            case AnimState.Walk:
                PlayWalkAnim();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Idle状态
    /// </summary>
    void PlayIdleAnim()
    {
        idleUpTime += Time.deltaTime;
        if (idleUpTime >= idleUpIntervalTime)
        {
            idleUpIndex++;
            idleUpIndex %= idleUpLenght;
            //idleUpIndex = idleUpIndex >= idleUpLenght ? 0 : idleUpIndex;//和上面那一句是一样的
            idleUpRender.sprite = idleUpSpriteArray[idleUpIndex];

            idleDownIndex++;
            idleDownIndex %= idleDownLenght;
            idleDownRender.sprite = idleDownSpriteArray[idleDownIndex];

            idleUpTime = 0;
        }
    }

    /// <summary>
    /// Walk状态
    /// </summary>
    void PlayWalkAnim()
    {
        walkUpTimer += Time.deltaTime;
        if (walkUpTimer >= walkUpIntervalTime)
        {
            walkUpIndex++;
            walkUpIndex %= walkUpLenght;
            walkUpRenderer.sprite = walkUpSpriteArray[walkUpIndex];

            walkUpTimer = 0;
        }

        walkDownTimer += Time.deltaTime;
        if (walkDownTimer >= walkDownIntervalTime)
        {
            walkDownIndex++;
            walkDownIndex %= walkDownLenght;
            walkDownRenderer.sprite = walkDownSpriteArray[walkDownIndex];

            walkDownTimer = 0;
        }
    }
}