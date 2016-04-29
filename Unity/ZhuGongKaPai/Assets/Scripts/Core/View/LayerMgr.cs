using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class LayerMgr : MonoBehaviour
{
    #region 初始化单例（继承MonoBehaviour的写法）
    private static LayerMgr instance;
    public static LayerMgr GetInstance()
    {
        if (instance == null)
        {
            instance = new GameObject("LayerMgr").AddComponent<LayerMgr>();
        }
        return instance;
    }
    #endregion

    #region 初始化相关
    private Transform layerParent;
    private Dictionary<LayerType, GameObject> layerTypeDict;

    private LayerMgr()
    {
        layerTypeDict = new Dictionary<LayerType, GameObject>();
    }

    void OnDestroy()
    {
        layerTypeDict.Clear();
        layerTypeDict = null;
    }
    #endregion

    /// <summary>
    /// 设置Layer
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="lType"></param>
    public void SetLayer(GameObject obj, LayerType lType)
    {
        int nums = Enum.GetNames(typeof(LayerType)).Length;
        if (layerTypeDict.Count < nums)
        {
            InitLayerType();
        }
        obj.transform.SetParent(layerTypeDict[lType].transform);
        UIPanel[] panels = obj.GetComponentsInChildren<UIPanel>(true);
        foreach (UIPanel panel in panels)
        {
            panel.depth += (int)lType;
        }
    }

    private void InitLayerType()
    {
        layerParent = GameObject.Find("UI Root").transform;
        int nums = Enum.GetNames(typeof(LayerType)).Length;
        for (int i = 0; i < nums; i++)
        {
            object obj = Enum.GetValues(typeof(LayerType)).GetValue(i);
            GameObject go = CreateLayerTypeObject(obj.ToString(), (LayerType)obj);
            layerTypeDict.Add((LayerType)obj, go);
        }
    }

    GameObject CreateLayerTypeObject(string name, LayerType lType)
    {
        GameObject layer = new GameObject(name);
        layer.transform.SetParent(layerParent);
        layer.transform.localEulerAngles = Vector3.zero;
        layer.transform.localScale = Vector3.one;
        layer.transform.localPosition = new Vector3(0, 0, (int)lType);

        return layer;
    }
}

public enum LayerType
{
    Scene = 50,

    Panel = 200,

    Tips = 500,

    Notice = 1000,
}
