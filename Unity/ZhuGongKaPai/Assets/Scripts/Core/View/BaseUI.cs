/***
 * Creator : Mohan
 * Description ： UI 基类
 * Date : 2016-04-26
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BaseUI : MonoBehaviour 
{
    #region 数据定义
    private GameObject _skin;
    public GameObject skin
    {
        get
        {
            return _skin;
        }
    }

    public Transform SkinTransform
    {
        get
        {
            return _skin.transform;
        }
    }

    private string mainSkinPath;
    protected void SetMainSkinPath(string path)
    {
        mainSkinPath = path;
    }

    protected object[] uiArgs;
    public object[] UIArgs
    {
        get
        {
            return uiArgs;
        }
    }

    #endregion

    #region 初始化相关
    void Start()
    {
        OnStart();
    }

    void Update()
    {
        OnUpdate();
    }

    /// <summary> 保存所有的Collider </summary>
    private List<Collider> colliderList = new List<Collider>();

    /// <summary>初始化函数，子类要先调用此函数</summary>
    public void Init()
    {
        OnInit();
        OnInitSkin();
        OnInitSkinDone();
        Collider[] buttons = this.transform.GetComponentsInChildren<Collider>();
        foreach (Collider buttton in buttons)
        {
            UIEventListener eventListener = UIEventListener.Get(buttton.gameObject);
            eventListener.onClick = OnClick;

            colliderList.Add(buttton);
        }
        OnInitDone();
    }

    public void OnDestroy()
    {
        OnDestroyFront();

        colliderList.Clear();
        colliderList = null;

        OnDestroyEnd();
    }
    #endregion

    #region 虚函数

    /// <summary> 初始化时调用 </summary>
    protected virtual void OnInit() { }

    protected virtual void OnInitDone() { }

    /// <summary> 按钮点击回调 </summary>
    protected virtual void OnClick(GameObject target) { }

    /// <summary> 开始销毁前 </summary>
    protected virtual void OnDestroyFront() { }

    /// <summary> 结束销毁 </summary>
    protected virtual void OnDestroyEnd() { }

    protected virtual void OnInitSkin()
    {
        if (!string.IsNullOrEmpty(mainSkinPath))
        {
            _skin = ResourceMsg.GetInstance().CreateGameObject(mainSkinPath);
        }
        _skin.transform.SetParent(this.transform);
        _skin.transform.localEulerAngles = Vector3.zero;
        _skin.transform.localPosition = Vector3.zero;
        _skin.transform.localScale = Vector3.one;
    }

    protected virtual void OnInitSkinDone() { }
    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }

    #endregion
}
