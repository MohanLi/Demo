using System.Collections.Generic;
using UnityEngine;

namespace UIFrameWork
{
	public class UIManager : Singleton<UIManager>
	{
		public class UIInfoData
		{
			public EnumUIType UIType { get; private set; }
			public System.Type ScriptType { get; private set; }
			public string Path { get; private set; }
			public object[] UIParams { get; private set; }

			public UIInfoData( EnumUIType _uiType, string _path, params object[] _uiParams)
			{
				this.UIType = _uiType;
				this.Path = _path;
				this.UIParams = _uiParams;
				this.ScriptType = UIPathDefines.GetUIScriptByType(this.UIType);
			}
		}

		private Dictionary<EnumUIType, GameObject> dictOpenUIs = null;
		private Stack<UIInfoData> stackOpenUIs = null;

		protected override void Init ()
		{
			base.Init ();
			dictOpenUIs = new Dictionary<EnumUIType, GameObject> ();
			stackOpenUIs = new Stack<UIInfoData> ();
		}

		public T GetUI<T>(EnumUIType _uiType) where T : BaseUI
		{
			GameObject gObject = GetUIObject (_uiType);
			if (null != gObject) 
			{
				return gObject.GetComponent<T> ();
			}
			return null;
		}

		public GameObject GetUIObject(EnumUIType _uiType)
		{
			GameObject gObject = null;
			if (!dictOpenUIs.TryGetValue (_uiType, out gObject))
			{
				throw new SingletonException ("dictOpenUIs TryGetValue Failure! _uiType : " + _uiType);
			}
			return gObject;
		}

		#region 预加载prefab资源

		public void PreloadUI(EnumUIType[] _uiTypes)
		{
			for (int i = 0; i < _uiTypes.Length; i++)
			{
				PreloadUI (_uiTypes[i]);
			}
		}

		public void PreloadUI(EnumUIType _uiType)
		{
			string path = UIPathDefines.GetPrefabsPathByType (_uiType);
			Resources.Load (path);
		}
		#endregion

		#region Open UI

		/// <summary>
		/// 打开多个UI,不传参数
		/// </summary>
		/// <param name="_uiTypes">User interface types.</param>
		public void OpenUI(EnumUIType[] _uiTypes)
		{
			OpenUI (false, _uiTypes, null);
		}

		/// <summary>
		/// 打开一个UI，可传参数
		/// </summary>
		/// <param name="_uiType">User interface type.</param>
		/// <param name="_objParams">Object parameters.</param>
		public void OpenUI (EnumUIType _uiType, params object[] _objParams)
		{
			EnumUIType[] uiTypes = new EnumUIType[1];
			uiTypes [0] = _uiType;
			OpenUI (false, uiTypes, _objParams);
		}

		/// <summary>
		/// 打开多个UI，并且关闭其他UI，不可传参
		/// </summary>
		/// <param name="_uiTypes">User interface types.</param>
		public void OpenUICloseOthers(EnumUIType[] _uiTypes)
		{
			OpenUI (true, _uiTypes, null);
		}

		/// <summary>
		/// 打开一个UI,并且关闭其他的UI，可传参数
		/// </summary>
		/// <param name="_uiType">User interface type.</param>
		/// <param name="objParams">Object parameters.</param>
		public void OpenUICloseOthers(EnumUIType _uiType, params object[] objParams)
		{
			EnumUIType[] uiType = new EnumUIType[1];
			uiType [0] = _uiType;

			OpenUI (true, uiType, objParams);
		}

		/// <summary>
		/// 打开UI
		/// </summary>
		/// <param name="_isCloseOther">If set to <c>true</c> is close other.</param>
		/// <param name="_uiTypes">User interface types.</param>
		/// <param name="_objParams">Object parameters.</param>
		public void OpenUI(bool _isCloseOther, EnumUIType[] _uiTypes, params object[] _objParams)
		{
			if (_isCloseOther) 
			{
				CloseAllUI ();
			}

			//push uiType to stack
			for (int i = 0; i < _uiTypes.Length; i++) 
			{
				EnumUIType uiType = _uiTypes [i];
				if (!dictOpenUIs.ContainsKey(uiType)) 
				{
					string path = UIPathDefines.GetPrefabsPathByType(uiType);
					stackOpenUIs.Push (new UIInfoData (uiType, path, _objParams));
				}
			}

			//Open UI
			if (stackOpenUIs.Count > 0) 
			{
				CoroutineController.Instance.StartCoroutine (AsyncLoadData());
			}
		}

		private IEnumerator<int> AsyncLoadData()
		{
			yield return 0;
			UIInfoData uiInfoData = null;
			UnityEngine.Object prefabObj = null;
			GameObject uiObject = null;

			if (stackOpenUIs != null && stackOpenUIs.Count > 0) 
			{
				do 
				{
					uiInfoData = stackOpenUIs.Pop();
					prefabObj = Resources.Load(uiInfoData.Path) as UnityEngine.Object;
					if (null != prefabObj) 
					{
						uiObject = MonoBehaviour.Instantiate(prefabObj) as GameObject;
						BaseUI baseUI = uiObject.GetComponent<BaseUI>();
						if (null == baseUI)
						{
							baseUI = uiObject.AddComponent(uiInfoData.ScriptType) as BaseUI;
						}
						else 
						{
							baseUI.SetUIWhenOpening(uiInfoData.UIParams);
						}
						dictOpenUIs.Add(uiInfoData.UIType, uiObject);
					}

				} while(stackOpenUIs.Count > 0);
			}
		}

		#endregion

		#region Close UI

		/// <summary>
		/// 关闭指定的多个UI
		/// </summary>
		/// <param name="uiType">User interface type.</param>
		public void CloseUI(EnumUIType[] uiType)
		{
			for (int i = 0; i < uiType.Length; i++) 
			{
				CloseUI (uiType[i]);
			}
		}

		/// <summary>
		/// 关闭圈闭打开的UI
		/// </summary>
		public void CloseAllUI()
		{
			List<EnumUIType> list = new List<EnumUIType> (dictOpenUIs.Keys);
			for (int i = 0; i < list.Count; i++) 
			{
				CloseUI (list[i]);
			}
			//CloseUI (list.ToArray());
			dictOpenUIs.Clear();
		}

		/// <summary>
		/// 关闭指定的UI
		/// </summary>
		/// <param name="_uiType">User interface type.</param>
		public void CloseUI(EnumUIType _uiType)
		{
			GameObject uiObject = GetUIObject (_uiType);
			if (null == uiObject) 
			{
				dictOpenUIs.Remove (_uiType);
			} 
			else 
			{
				BaseUI baseUI = uiObject.GetComponent<BaseUI> ();
				if (null == baseUI) 
				{
					GameObject.Destroy (uiObject);
					dictOpenUIs.Remove (_uiType);
				} 
				else 
				{
					baseUI.StateChange += CloseHandle;
					baseUI.Release ();
				}
			}
		}

		public void CloseHandle(Object sender, EnumObjectState newState, EnumObjectState oldState)
		{
			if (newState == EnumObjectState.Closing) 
			{
				BaseUI baseUI = sender as BaseUI;
				dictOpenUIs.Remove (baseUI.GetUIType());
				baseUI.StateChange -= CloseHandle;
			}
		}

		#endregion
	}
}