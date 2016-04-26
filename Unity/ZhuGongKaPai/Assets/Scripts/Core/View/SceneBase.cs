/**
 *	Creator : Mohan 
 * 	Description : UI基类
 *  Date : 2016-04-26
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneBase : BaseUI
{
    protected object[] uiArgs;
    public object[] UIArgs
    {
        get
        {
            return uiArgs;
        }
    }

    /// <summary>
    /// 初始化场景
    /// </summary>
    /// <param name="sceneArgs"></param>
    public virtual void OnInit(params object[] sceneArgs)
    {
        uiArgs = sceneArgs;
        Init();
    }

    public virtual void OnShowing() 
    {
    
    }

    public virtual void OnResetArgs(params object[] sceneArgs)
    {
        uiArgs = sceneArgs;
    }
}
