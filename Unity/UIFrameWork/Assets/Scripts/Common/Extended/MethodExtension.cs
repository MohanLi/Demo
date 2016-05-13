/*************************************
 * Author : Mohan
 * Desc : $Description$
 * Date : 5/13/2016 3:06:30 PM
 * Version : 1.0.0
 *
*************************************/
using System;
using UnityEngine;

namespace UIFrameWork
{
    public static class MethodExtension
    {
        /// <summary>
        /// 获取某组件，如果没有则添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="go"></param>
        /// <returns></returns>
        public static T GetOrAddCompenent<T>(this GameObject go) where T : Component
        {
            T ret = go.GetComponent<T>();
            if (null == ret)
            {
                ret = go.AddComponent<T>();
            }
            return ret;
        }
    }
}
