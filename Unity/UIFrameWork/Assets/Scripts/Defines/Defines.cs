using UnityEngine;

namespace UIFrameWork
{
	#region 全局状态委托
	public delegate void StateChangeEvent(object sender, EnumObjectState newState, EnumObjectState oldState);

    public delegate void MessageEvent(Message message);

    public delegate void OnTouchEventHandle(EventTriggerListener listener, object args, params object[] objParams);

	#endregion

	#region 全局枚举变量

	/// <summary>
	/// UI 状态
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
	/// UI 界面类型
	/// </summary>
	public enum EnumUIType : int
	{
		None = -1,
		TestOne = 0,
        TestTwo,
	}

    /// <summary>
    /// 点击事件类型
    /// </summary>
    public enum EnumTouchEventType
    {
        OnClick,
        OnDoubleClick,
        OnDown,
        OnUp,
        OnEnter,
        OnExit,
        OnSelect,
        OnUpdateSelect,
        OnDeSelect,
        OnDrag,
        OnDragEnd,
        OnDrop,
        OnScroll,
        OnMove,
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
            case EnumUIType.TestTwo:
                path = "Prefab/" + UI_PREFAB + "TestTwo";
                break;
			default:
				Debug.Log ("Can Not Find EnumUIType, _uiType : " + _uiType.ToString());
				break;
			}
			return path;
		}

		public static System.Type GetUIScriptByType(EnumUIType _uiType)
		{
			System.Type sType = null;
			switch (_uiType) 
			{
			case EnumUIType.TestOne:
                    sType = typeof(TestOne);
				break;

            case EnumUIType.TestTwo:
                sType = typeof(TestTwo);
                break;

			default:
				break;
			}
            return sType;
		}
	}

	public class Defines
	{
		public Defines ()
		{
		}
	}
}