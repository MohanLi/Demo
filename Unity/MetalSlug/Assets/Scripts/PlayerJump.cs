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

public class PlayerJump : MonoBehaviour
{
    public float speed = 10;

    public SpriteRenderer jumpUpRenderer;
    public Sprite[] jumpUpSpriteArray;
    public float jumpUpIntervalTime = 0;
    private int jumpUpIndex = 0;
    private int jumpUpLenght = 0;
    private float jumpUpTimer = 0;

    public SpriteRenderer jumpFloorRenderer;
    public Sprite[] jumpFloorSpriteArray;
    public float jumpFloorIntervalTime = 0;
    private int jumpFloorIndex = 0;
    private int jumpFloorLenght = 0;
    private float jumpFloorTimer = 0;

    public AnimState state = AnimState.Jump;

    void Start()
    {
        jumpUpIntervalTime = 1 / speed;
        jumpUpIntervalTime = 1 / speed;// jumpUpSpeed;
        jumpFloorIntervalTime = 1 / speed;// jumpjumpSpeed;

        jumpUpLenght = jumpUpSpriteArray.Length;
        jumpFloorLenght = jumpFloorSpriteArray.Length;
        jumpUpLenght = jumpUpSpriteArray.Length;
        jumpFloorLenght = jumpFloorSpriteArray.Length;
    }

    void Update()
    {
        switch (state)
        {
            case AnimState.Jump:
                PlayJumpAnim();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Down状态
    /// </summary>
    void PlayJumpAnim()
    {
        jumpUpTimer += Time.deltaTime;
        if (jumpUpTimer >= jumpUpIntervalTime)
        {
            jumpUpIndex++;
            jumpUpIndex %= jumpUpLenght;
            jumpUpRenderer.sprite = jumpUpSpriteArray[jumpUpIndex];

            jumpUpTimer = 0;
        }

        jumpFloorTimer += Time.deltaTime;
        if (jumpFloorTimer >= jumpFloorIntervalTime)
        {
            jumpFloorIndex++;
            jumpFloorIndex %= jumpFloorLenght;
            jumpFloorRenderer.sprite = jumpFloorSpriteArray[jumpFloorIndex];

            jumpFloorTimer = 0;
        }
    }
}