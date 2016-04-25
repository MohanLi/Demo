using UnityEngine;
using System.Collections;

public class ResourceMsg : MonoBehaviour
{
    /// <summary> 缓存资源集合</summary>
    private Hashtable cacheGameObject;

    #region 初始化
    private static ResourceMsg mInstance;
    public static ResourceMsg GetInstance()
    {
        if (mInstance == null)
        {
            mInstance = new GameObject("_ResourceMsg").AddComponent<ResourceMsg>();
        }
        return mInstance;
    }

    private ResourceMsg()
    {
        cacheGameObject = new Hashtable();
    }
    #endregion

    /// <summary>
    /// 加载resource
    /// </summary>
    /// <typeparam name="T">资源类型</typeparam>
    /// <param name="path">资源路径</param>
    /// <param name="cache">是否缓存</param>
    /// <returns></returns>
    public T Load<T>(string path, bool cache) where T : UnityEngine.Object
    {
        if (cacheGameObject.ContainsKey(path))
        {
            return cacheGameObject[path] as T;
        }

        T assetObj = Resources.Load<T>(path);
        if (assetObj == null)
        {
            Debug.LogError("can not find resource, path = " + path);
        }

        if (cache)
        {
            cacheGameObject.Add(path, assetObj);
            Debug.Log("对象缓存， path + " + path);
        }

        return assetObj;
    }

    /// <summary>
    /// 创建游戏对象
    /// </summary>
    /// <param name="path">资源路径</param>
    /// <param name="cache">资源是否缓存</param>
    /// <returns>返回创建好的游戏对象</returns>
    public GameObject CreateGameObject(string path, bool cache = false)
    {
        GameObject assertObj = Load<GameObject>(path, cache);
        GameObject go = Instantiate(assertObj) as GameObject;
        if (go == null)
        {
            Debug.LogError("从Resource中创建游戏对象失败， path = " + path);
        }
        return go;
    }
}
