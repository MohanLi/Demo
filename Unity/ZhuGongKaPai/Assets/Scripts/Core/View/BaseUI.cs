/**
 *	Creator : Mohan 
 * 	Description : UI基类
 *  Date : 2016-04-26
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseUI : MonoBehaviour 
{
	/// <summary> 保存所有的Collider </summary>
	private List<Collider> colliderList = new List<Collider>();

	/// <summary>初始化函数，子类要先调用此函数</summary>
	protected void Init()
	{
		OnInit ();

		Collider[] buttons = this.transform.GetComponentsInChildren<Collider> ();
		foreach (Collider  buttton in buttons) 
		{
			UIEventListener eventListener = UIEventListener.Get (buttton.gameObject);
			eventListener.onClick = OnClick;

			colliderList.Add (buttton);
		}
	}

	public void OnDestroy()
	{
		Debug.Log ("========OnDestroy=====================");

		OnDestroyBefore ();

		colliderList.Clear ();
		colliderList = null;

		OnDestroyEnd ();
	}

	#region 虚函数

	/// <summary> 初始化时调用 </summary>
	protected virtual void OnInit(){}

	/// <summary> 按钮点击回调 </summary>
	protected virtual void OnClick(GameObject target){}

	/// <summary> 开始销毁前 </summary>
	protected virtual void OnDestroyBefore(){}

	/// <summary> 结束销毁 </summary>
	protected virtual void OnDestroyEnd(){}

	#endregion
}
