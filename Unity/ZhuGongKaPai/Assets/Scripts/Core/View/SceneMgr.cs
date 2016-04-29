using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SceneMgr 
{
	/// <summary>
	/// 当前显示的界面
	/// </summary>
	private GameObject currentShow;
    private Transform parentObj = null;
    private List<SwitchRecorder> switchRecorders;

    //记录主场景
    private string mainScene = "MainScene";

	#region 初始化
	private static SceneMgr mInstance;
	public static SceneMgr Instance
	{
		get
		{
			if (mInstance == null)
			{
				mInstance = new SceneMgr();
			}
			return mInstance;
		}
	}

    private SceneMgr()
    {
        switchRecorders = new List<SwitchRecorder>();
    }

    void OnDestroy()
    {
        switchRecorders.Clear();
        switchRecorders = null;
    }
	#endregion

	/// <summary>
	/// Switchs the scene.
	/// </summary>
	/// <param name="name">要创建的资源路径</param>
    /// <param name="objParams">可变参数</param>
	public void SwitchScene(SceneType sceneType , params object[] objParams)//GameObject
	{
		//GameObject obj = ResourceMsg.GetInstance ().CreateGameObject (name, cache);

		string name = sceneType.ToString ();
        GameObject go = new GameObject(name);
        SceneBase scene = go.AddComponent(Type.GetType(name)) as SceneBase;
        //scene.Init();
        scene.OnInit(objParams);

        if (parentObj == null)
        {
            //此处写法欠妥，还需要改进
            parentObj = GameObject.Find("UI Root").transform;
        }
        go.transform.SetParent(parentObj);
        go.transform.localEulerAngles = Vector3.zero;
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = Vector3.zero;

        //如果是进入到主场景，清空记录
        if (name.Equals(mainScene))
        {
            switchRecorders.Clear();
        }

		switchRecorders.Add(new SwitchRecorder(sceneType, objParams));

		if (currentShow != null) 
		{
			GameObject.Destroy (currentShow);
		}
        currentShow = go;

        LayerMgr.GetInstance().SetLayer(go, LayerType.Scene);
	}

    /// <summary>
    /// 返回上一个场景
    /// </summary>
    public void SwitchToPreScene()
    {
        SwitchRecorder sRecorder = switchRecorders[switchRecorders.Count - 2];
        //将当前场景，以及上一个场景从记录中清理掉
        switchRecorders.RemoveRange(switchRecorders.Count - 2, 2);

		SwitchScene(sRecorder.sceneType, sRecorder.sceneArgs);
    }

    /// <summary>
    /// 记录结构体
    /// </summary>
    internal struct SwitchRecorder
    {
		internal SceneType sceneType;
        internal object[] sceneArgs;

		internal SwitchRecorder(SceneType sceneType, params object[] args)
        {
			this.sceneType = sceneType;
            this.sceneArgs = args;
        }
    }
}
