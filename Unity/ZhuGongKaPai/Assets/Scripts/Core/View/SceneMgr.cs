using UnityEngine;
using System.Collections;

public class SceneMgr 
{
	/// <summary>
	/// 当前显示的界面
	/// </summary>
	private GameObject currentShow;

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
	#endregion

	/// <summary>
	/// Switchs the scene.
	/// </summary>
	/// <returns>返回当前创建的Gameobject</returns>
	/// <param name="name">要创建的资源路径</param>
	/// <param name="cache">是否需要缓存</param>
	public GameObject SwitchScene(string name, bool cache = false)
	{
		GameObject obj = ResourceMsg.GetInstance ().CreateGameObject (name, cache);
		if (currentShow != null) 
		{
			GameObject.Destroy (currentShow);
		}
		currentShow = obj;

		return obj;
	}
}
