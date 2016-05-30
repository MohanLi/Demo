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

public class PlayerDown : MonoBehaviour
{
    public float speed = 10;

    public SpriteRenderer downUpRenderer;
    public Sprite[] downUpSpriteArray;
    public float downUpIntervalTime = 0;
    private int downUpIndex = 0;
    private int downUpLenght = 0;
    private float downUpTimer = 0;

    public SpriteRenderer downFloorRenderer;
    public Sprite[] downFloorSpriteArray;
    public float downFloorIntervalTime = 0;
    private int downFloorIndex = 0;
    private int downFloorLenght = 0;
    private float downFloorTimer = 0;

    public AnimState state = AnimState.Walk;

    void Start()
    {
        downUpIntervalTime = 1 / speed;
        downUpIntervalTime = 1 / speed;// downUpSpeed;
        downFloorIntervalTime = 1 / speed;// downdownSpeed;

        downUpLenght = downUpSpriteArray.Length;
        downFloorLenght = downFloorSpriteArray.Length;
        downUpLenght = downUpSpriteArray.Length;
        downFloorLenght = downFloorSpriteArray.Length;
    }

    void Update()
    {
        switch (state)
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
    /// Down状态
    /// </summary>
    void PlayWalkAnim()
    {
        downUpTimer += Time.deltaTime;
        if (downUpTimer >= downUpIntervalTime)
        {
            downUpIndex++;
            downUpIndex %= downUpLenght;
            downUpRenderer.sprite = downUpSpriteArray[downUpIndex];

            downUpTimer = 0;
        }

        downFloorTimer += Time.deltaTime;
        if (downFloorTimer >= downFloorIntervalTime)
        {
            downFloorIndex++;
            downFloorIndex %= downFloorLenght;
            downFloorRenderer.sprite = downFloorSpriteArray[downFloorIndex];

            downFloorTimer = 0;
        }
    }

    void PlayIdleAnim()
    {
        //downUpTimer += Time.deltaTime;
        //if (downUpTimer >= downUpIntervalTime)
        //{
        //    downUpIndex++;
        //    downUpIndex %= downUpLenght;
        //    downUpRenderer.sprite = downUpSpriteArray[downUpIndex];

        //    downUpTimer = 0;
        //}

        //downFloorTimer += Time.deltaTime;
        //if (downFloorTimer >= downFloorIntervalTime)
        //{
        //    downFloorIndex++;
        //    downFloorIndex %= downFloorLenght;
        //    downFloorRenderer.sprite = downFloorSpriteArray[downFloorIndex];

        //    downFloorTimer = 0;
        //}
    }
}