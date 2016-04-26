using UnityEngine;
using System.Collections;
using System;

public class PanelMgr
{
	/// <summary>
	/// 当前显示的界面
	/// </summary>
	private GameObject currentShow;

    private Transform parentObj = null;

	#region 初始化
    private static PanelMgr mInstance;
    public static PanelMgr Instance
	{
		get
		{
			if (mInstance == null)
			{
                mInstance = new PanelMgr();
			}
			return mInstance;
		}
	}
	#endregion

	/// <summary>
	/// Switchs the scene.
	/// </summary>
	/// <returns>返回当前创建的Gameobject</returns>
	/// <param name="name">要创建的资源路径</param>
    /// <param name="objParams">可变参数</param>
    public void ShowPanel(string name, params object[] objParams)//GameObject
    {
        //GameObject obj = ResourceMsg.GetInstance ().CreateGameObject (name, cache);

        GameObject go = new GameObject(name);
        PanelBase scene = go.AddComponent(Type.GetType(name)) as PanelBase;
        scene.Init();

        if (parentObj == null)
        {
            //此处写法欠妥，还需要改进
            parentObj = GameObject.Find("UI Root").transform;
        }
        go.transform.SetParent(parentObj);
        go.transform.localEulerAngles = Vector3.zero;
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = Vector3.zero;

        currentShow = go;
    }
}
