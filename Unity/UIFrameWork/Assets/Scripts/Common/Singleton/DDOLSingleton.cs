using System;
using UnityEngine;

namespace UIFrameWork
{
	// DontDestroyOnLoad => DDOL
	public abstract class DDOLSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		protected static T _instance;
		public static T Instance
		{
			get
			{ 
				if (null == _instance) {
					GameObject go = GameObject.Find ("DDOLSingleton");
					if (null == go) {
						go = new GameObject ("DDOLSingleton");
						//让go对象在切换场景的时候，不要释放销毁
						DontDestroyOnLoad (go);
					}
					_instance = go.AddComponent<T> ();
				}
				return _instance;
			}
		}

		/// <summary>
		/// Raises the application quit event.
		/// </summary>
		private void OnApplicationQuit()
		{
			_instance = null;
		}
	}
}

