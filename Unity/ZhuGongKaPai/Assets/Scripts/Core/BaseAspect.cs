/**
 * Creator : Mohan
 * Description ： 屏幕 适配
 * Date : 2016-04-26
 */

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UICamera))]
public class BaseAspect : MonoBehaviour 
{
    //初始宽度
    float standardWidth = 1136f;
    //初始高度
    float standardHeight = 640f;
    //当前设备宽度
    float deviceWidth = 0f;
    //当前设备高度
    float deviceHeight = 0f;

    //屏幕矫正比例
    public float adjustor = 0f;

    void Awake()
    {

        //获取屏幕宽高
        deviceWidth = Screen.width;
        deviceHeight = Screen.height;

        //计算宽高比例
        float standardAspect = Screen.width / standardHeight;
        float deviceAspect = deviceWidth / deviceHeight;
    
        //计算矫正比例
        if (deviceAspect < standardAspect)
        {
            adjustor = standardAspect / deviceAspect;
        }

        if (adjustor < 2 && adjustor > 0)
        {
            //Camera.main.orthographicSize = adjustor;
            GetComponent<Camera>().orthographicSize = adjustor;
        }
    }
}
