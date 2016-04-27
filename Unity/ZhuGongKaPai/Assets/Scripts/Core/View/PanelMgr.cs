using UnityEngine;
using System.Collections;
using System;

public class PanelMgr
{
    #region 初始化相关
    /// <summary>  当前显示的界面 </summary>
	private GameObject currentShow;
    // 父节点 UIRoot
    private Transform parentObj = null;
	
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

    /// <summary> 显示Panel的类型 </summary>
    private PanelShowStyle showStyle = PanelShowStyle.normal;
    public void SetPanelShowStyle(PanelShowStyle style)
    {
        showStyle = style;
    }

    /// <summary>
    /// 动画持续的时间
    /// </summary>
    private float duration = 0.2f;
    public void SetDurationTime(float time)
    {
        duration = time;
    }

	#endregion

    #region 显示Panel
    /// <summary>
	/// Switchs the scene.
	/// </summary>
	/// <returns>返回当前创建的Gameobject</returns>
	/// <param name="name">要创建的资源路径</param>
    /// <param name="objParams">可变参数</param>
    public void ShowPanel(PanelType panelType, params object[] objParams)//GameObject
    {
        //GameObject obj = ResourceMsg.GetInstance ().CreateGameObject (name, cache);
        string name = panelType.ToString();
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

        ShowPanelStyle(go);
    }
    #endregion

    #region 显示Show类型
    private void ShowPanelStyle(GameObject panelObj)
    {
        switch(showStyle)
        {
            case PanelShowStyle.normal :
                ShowStyleNormal(panelObj);
                break;
            case PanelShowStyle.Scale2Large :
                ShowStyleScale2Large(panelObj);
                break;
            case PanelShowStyle.MoveFromLeft :
                ShowStyleMoveFromLeft(panelObj);
                break;
            case PanelShowStyle.MoveFromRight :
                ShowStyleMoveFromRight(panelObj);
                break;
            case PanelShowStyle.MoveFromTop :
                ShowStyleMoveFromTop(panelObj);
                break;
            case PanelShowStyle.MoveFromButtom :
                ShowStyleMoveFromButtom(panelObj);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 默认显示类型类型
    /// </summary>
    private void ShowStyleNormal(GameObject panelObj)
    {

    }

    /// <summary>
    /// 从小变大
    /// </summary>
    private void ShowStyleScale2Large(GameObject panelObj)
    {
        TweenScale tScale = panelObj.transform.GetComponent<TweenScale>();
        if (tScale == null)
        {
            tScale = panelObj.AddComponent<TweenScale>();
        }
        tScale.from = Vector3.zero;
        tScale.to = Vector3.one;
        tScale.duration = this.duration;
        //缩放完毕后回调（不知道叫什么鬼的写法）
        tScale.SetOnFinished(() =>
        {
            //反向播放
            //tScale.PlayReverse();
        });
    }

    /// <summary>
    /// 从左到右
    /// </summary>
    private void ShowStyleMoveFromLeft(GameObject panelObj)
    {
        HorizontalFromLeft(panelObj, true);
    }

    /// <summary>
    /// 从右到左
    /// </summary>
    private void ShowStyleMoveFromRight(GameObject panelObj)
    {
        HorizontalFromLeft(panelObj, false);
    }

    /// <summary>
    /// 从上到下
    /// </summary>
    private void ShowStyleMoveFromTop(GameObject panelObj)
    {
        VertiicalFromTop(panelObj, true);
    }

    /// <summary>
    /// 从下到上
    /// </summary>
    private void ShowStyleMoveFromButtom(GameObject panelObj)
    {
        VertiicalFromTop(panelObj, false);
    }

    /// <summary>
    /// 垂直方向 是否从上到下
    /// </summary>
    /// <param name="isFromTop">true ： 表示从上到下， false ： 表示从下到上</param>
    private void VertiicalFromTop(GameObject panelObj, bool isFromTop)
    {
        TweenPosition tPosition = panelObj.gameObject.GetComponent<TweenPosition>();
        if (tPosition == null)
        {
            tPosition = panelObj.gameObject.AddComponent<TweenPosition>();
        }

        Vector3 originVect3 = panelObj.transform.position;
        float fromY = isFromTop ? Screen.height : -1.0f * Screen.height;
        tPosition.from = new Vector3(originVect3.x, fromY, originVect3.z);
        tPosition.to = originVect3;
        tPosition.duration = this.duration;
    }
    
    /// <summary>
    /// 水平方向 是否为从左到右
    /// </summary>
    /// <param name="isFromLeft">true : 表示从左到有  false : 表示从右到左</param>
    private void HorizontalFromLeft(GameObject panelObj, bool isFromLeft)
    {
        TweenPosition tPosition = panelObj.transform.GetComponent<TweenPosition>();
        if (tPosition == null)
        {
            tPosition = panelObj.AddComponent<TweenPosition>();
        }
        Vector3 originVect = panelObj.transform.position;
        float originX = isFromLeft ? -1.0f * Screen.width : Screen.width;
        tPosition.from = new Vector3(originX, originVect.y, originVect.z);
        tPosition.to = originVect;
        tPosition.duration = this.duration;
    }

    #endregion
}

#region 定义显示类型
public enum PanelShowStyle
{
    /// <summary> 默认显示 </summary>
    normal,
    /// <summary> 从小变大 </summary>
    Scale2Large,
    /// <summary> 从右到左 </summary>
    MoveFromLeft,
    /// <summary> 从左到右 </summary>
    MoveFromRight,
    /// <summary> 从上到下 </summary>
    MoveFromTop,
    /// <summary> 从下到上 </summary>
    MoveFromButtom
}
#endregion