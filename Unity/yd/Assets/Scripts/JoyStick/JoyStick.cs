/**************************************
 * Creator ： Mohan
 * Brief ： 虚拟手柄
 * Date  ： 2016-05-25
 * 
 **************************************/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    /// <summary>
    /// 摇杆最大半径
    /// </summary>
    public float joyStickRadius = 50.0f;

    /// <summary>
    /// 摇杆重置速度
    /// </summary>
    public float joyStickResetSpeed = 5.0f;

    /// <summary>
    /// 当前物体Transform组件
    /// </summary>
    private RectTransform selfTransform;

    /// <summary>
    /// 是否触摸了虚拟摇杆
    /// </summary>
    private bool isTouched = false;

    /// <summary>
    /// 虚拟摇杆默认位置
    /// </summary>
    private Vector2 originPosition;

    /// <summary>
    /// 虚拟摇杆移动方向
    /// </summary>
    private Vector2 touchedAxis;
    public Vector2 TouchedAxis
    {
        get
        {
            // Vector2.magnitude 返回向量长度
            if (touchedAxis.magnitude < joyStickRadius)
            {
                return touchedAxis.normalized / joyStickRadius;
            }
            // normalized（规格化）后，向量保持同样的方向，但长度变为1.0
            return touchedAxis.normalized;
        }
    }

    /// <summary>
    /// 定义开始触摸事件委托
    /// </summary>
    /// <param name="vec"></param>
    public delegate void JoyStickTouchBegin(Vector2 vec);

    /// <summary>
    /// 定义触摸过程事件委托
    /// </summary>
    /// <param name="vec">虚拟摇杆移动方向</param>
    public delegate void JoyStickTouchMove(Vector2 vec);

    /// <summary>
    /// 定义触摸结束事件委托
    /// </summary>
    /// <param name="vec"></param>
    public delegate void JoyStickTouchEnd(Vector2 vec);

    /// <summary>
    /// 注册开始触摸事件
    /// </summary>
    public event JoyStickTouchBegin OnJoyStickTouchBegin;

    /// <summary>
    /// 注册触摸过程事件
    /// </summary>
    public event JoyStickTouchMove OnJoyStickTouchMove;

    /// <summary>
    /// 注册触摸结束事件
    /// </summary>
    public event JoyStickTouchEnd OnJoyStickTouchEnd;

    void Start()
    {
        //初始化你虚拟摇杆默认方向
        selfTransform = this.GetComponent<RectTransform>();
        originPosition = selfTransform.anchoredPosition;
    }

    void Update()
    {
        //当虚拟摇杆移动到最大半径时摇杆无法往外拖动
        //为了确保被控制物体可以继续移动
        //此处手动触发OnJoyStickTouchMove事件
        //if (isTouched)
        if (isTouched && touchedAxis.magnitude >= joyStickRadius / 10)
        {
            if (this.OnJoyStickTouchMove != null)
            {
                this.OnJoyStickTouchMove(TouchedAxis);
            }
        }

        //松开虚拟摇杆后让虚拟摇杆回到默认位置
        if (!isTouched && selfTransform.anchoredPosition.magnitude > originPosition.magnitude)
        {
            selfTransform.anchoredPosition -= TouchedAxis * Time.deltaTime * joyStickResetSpeed;
        }
    }

    /// <summary>
    /// IPointerDownHandler 里面的函数，开始触摸时调用
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        isTouched = true;
        touchedAxis = GetJoyStickAxis(eventData);
        if (this.OnJoyStickTouchBegin != null)
        {
            this.OnJoyStickTouchBegin(TouchedAxis);
        }
    }

    /// <summary>
    /// IDragHandler 里面的函数，拖拽时调用
    /// </summary>
    /// <param name="eventData">Pointer Even tData</param>
    public void OnDrag(PointerEventData eventData)
    {
        touchedAxis = GetJoyStickAxis(eventData);
        if (this.OnJoyStickTouchMove != null)
        {
            this.OnJoyStickTouchMove(TouchedAxis);
        }
    }

    /// <summary>
    /// IPointerUpHandler里面的函数，结束触摸时调用
    /// </summary>
    /// <param name="eventData">Pointer Event Data</param>
    public void OnPointerUp(PointerEventData eventData)
    {
        isTouched = false;
        selfTransform.anchoredPosition = originPosition;
        touchedAxis = Vector2.zero;

        if (this.OnJoyStickTouchEnd != null)
        {
            this.OnJoyStickTouchEnd(TouchedAxis);
        }
    }

    /// <summary>
    /// 获取虚拟摇杆偏移量
    /// </summary>
    /// <param name="eventData">Pointer Event Data</param>
    /// <returns>摇杆偏移量</returns>
    private Vector2 GetJoyStickAxis(PointerEventData eventData)
    {
        //获取手指位置世界坐标
        Vector3 worldPosition;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(selfTransform, eventData.position, eventData.pressEventCamera, out worldPosition))
        {
            selfTransform.position = worldPosition;
        }

        //获取摇杆偏移量
        Vector2 touchAxis = selfTransform.anchoredPosition - originPosition;

        //摇杆偏移量限制
        if (touchAxis.magnitude >= joyStickRadius)
        {
            touchAxis = touchAxis.normalized * joyStickRadius;
            selfTransform.anchoredPosition = touchAxis;
        }

        return touchAxis;
    }
}