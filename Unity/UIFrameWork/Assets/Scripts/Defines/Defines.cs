﻿using UnityEngine;

namespace UIFrameWork
{
	#region 全局状态委托
	public delegate void StateChangeEvent(Object sender, EnumObjectState newState, EnumObjectState oldState);

	#endregion

	#region 全局枚举变量

	/// <summary>
	/// Enum object state.
	/// </summary>
	public enum EnumObjectState
	{
		None,
		Initial,
		Loading,
		Ready,
		Disabled,
		Closing
	}

	/// <summary>
	/// Enum user interface type.
	/// </summary>
	public enum EnumUIType : int
	{
		None = -1,
		TestOne = 0,
	}

	#endregion

	public class UIPathDefines
	{
		/// <summary>
		/// UI 预设
		/// </summary>
		public const string UI_PREFAB = "UIPrefab/";

		/// <summary>
		/// UI 小控件预设
		/// </summary>
		public const string UI_CONTROLS_PREFAB = "UIPrefab/Control/";

		/// <summary>
		/// UI 子页面预设
		/// </summary>
		public const string UI_SUBUI_PREFAB = "UIPrefab/SubUI/";

		/// <summary>
		/// icon路径
		/// </summary>
		public const string UI_ICON_PATH = "UI/Icon";

		public static string GetPrefabsPathByType(EnumUIType _uiType)
		{
			string path = string.Empty;
			switch (_uiType) 
			{
			case EnumUIType.TestOne:
				path = "Prefab/" + UI_PREFAB + "TestOne";
				break;
			default:
				Debug.Log ("Can Not Find EnumUIType, _uiType : " + _uiType.ToString());
				break;
			}
			return path;
		}

		public static System.Type GetUIScriptByType(EnumUIType _uiType)
		{
			System.Type scriptType = null;
			switch (_uiType) 
			{
			case EnumUIType.TestOne:
				scriptType = typeof(TestOne);
				break;

			default:
				break;
			}
			return scriptType;
		}
	}

	public class Defines
	{
		public Defines ()
		{
		}
	}
}