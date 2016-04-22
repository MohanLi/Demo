/**
 * Description : UGUI虚拟摇杆
 * Creator : Mohan
 * Date : 2016-04-20
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    /// <summary>
    /// 摇杆最大半径
    /// 以像素为单位
    /// </summary>
    public float joyStickRadius = 45f;

    /// <summary>
    /// 摇杆重置位置速度
    /// </summary>
    public float joyStickResetSpeed = 5.0f;

    /// <summary>
    /// 当前物体的Transform组件
    /// </summary>
    private RectTransform selfTransform;

    /// <summary>
    /// 是否触摸虚拟摇杆
    /// </summary>
    private bool isTouched = false;

    /// <summary>
    /// 摇杆默认位置
    /// </summary>
    private Vector2 originPosition;

    /// <summary>
    /// 摇杆移动方向
    /// </summary>
    private Vector2 touchedAxis;
    public Vector2 TouchedAxis
    {
        get
        {
            if (touchedAxis.magnitude < joyStickRadius)
            {
                return touchedAxis.normalized / joyStickRadius;
            }
            return touchedAxis.normalized;
        }
    }

    /// <summary>
    /// 定义触摸开始事件委托
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
    public delegate void JoyStickTouchEnd();


    /// <summary>
    /// 注册触摸开始事件
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
        selfTransform = GetComponent<RectTransform>();
        originPosition = selfTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouched = true;
        touchedAxis = GetJoyStickAxis(eventData);

        if (this.OnJoyStickTouchBegin != null)
        {
            this.OnJoyStickTouchBegin(TouchedAxis);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouched = false;
        selfTransform.anchoredPosition = originPosition;
        touchedAxis = Vector2.zero;

        if (this.OnJoyStickTouchEnd != null)
        {
            this.OnJoyStickTouchEnd();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        touchedAxis = GetJoyStickAxis(eventData);

        if (this.OnJoyStickTouchMove != null)
        {
            this.OnJoyStickTouchMove(TouchedAxis);
        }
    }
    double count = 0;
    void Update()
    {
        count += 1;
        //当虚拟摇杆移动到最大半径时摇杆无法拖动
        //为了确保被控制物体可以继续移动
        //触发OnJoyStickTouchMove事件
        if (isTouched)//&& touchedAxis.magnitude >= joyStickRadius
        {
            if (this.OnJoyStickTouchMove != null)
            {
                this.OnJoyStickTouchMove(TouchedAxis);
            }
        }

        //松开虚拟摇杆后让虚拟摇杆恢复到默认位置
        if (selfTransform.anchoredPosition.magnitude > originPosition.magnitude)
        {
            selfTransform.anchoredPosition -= TouchedAxis * Time.deltaTime * joyStickResetSpeed;
        }
    }

    private Vector2 GetJoyStickAxis(PointerEventData eventData)
    {
        //获取手指位置的世界坐标
        Vector3 worldPosition;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(selfTransform, 
            eventData.position, eventData.pressEventCamera, out worldPosition))
        {
            selfTransform.position = worldPosition;
        }

        //获取摇杆偏移量
        Vector2 touchAxis = selfTransform.anchoredPosition - originPosition;
        
        //摇杆偏移量显示
        if (touchAxis.magnitude >= joyStickRadius)
        {
            touchAxis = touchAxis.normalized * joyStickRadius;
            selfTransform.anchoredPosition = touchAxis;
        }

        return touchAxis;
    }
}
