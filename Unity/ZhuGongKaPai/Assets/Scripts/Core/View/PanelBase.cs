using UnityEngine;
using System.Collections;

public class PanelBase : BaseUI
{
    #region 关闭Panel
    protected void Close()
    {
        UITweener tweener = gameObject.GetComponent<UITweener>();
        if (tweener != null)
        {
            tweener.PlayReverse();
            tweener.SetOnFinished(() => 
            {
                DestroyGameObject();
            });
        }
        else
        {
            DestroyGameObject();
        }
    }

    private void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
    #endregion
}


/// <summary>
/// Panel 类型
/// </summary>
public enum PanelType
{
    PlayerInfoUI
}
