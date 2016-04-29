using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneShop : SceneBase
{
    private List<GameObject> menuBtnList = new List<GameObject>();

    #region override父类，初始化相关
    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/SceneShop");
        base.OnInitSkin();
    }

    protected override void OnInitDone()
    {
        base.OnInitDone();
        InItMenuBtn();
    }

    protected override void OnClick(GameObject target)
    {
        base.OnClick(target);
        OnBtnClick(target);
    }
    
    /// <summary>
    /// 初始化Menu按钮
    /// </summary>
    private void InItMenuBtn()
    {
        Transform menu = SkinTransform.Find("MenuBtn").transform;
        BoxCollider[] bColliders = menu.GetComponentsInChildren<BoxCollider>(true);
        foreach (BoxCollider button in bColliders)
        {
            menuBtnList.Add(button.gameObject);
        }
    }
    #endregion

    #region 按钮事件
    private void OnBtnClick(GameObject target)
    {
        if (target.name.Equals("EquipBtn"))
        {
            SwitchButton(target);
        }
        else if (target.name.Equals("MaterialBtn"))
        {
            SwitchButton(target);
        }
        else if (target.name.Equals("GiftBtn"))
        {
            SwitchButton(target);
        }
        else if (target.name.Equals("BackBtn"))
        {
            Back2PreScene();
        }
        else if (target.name.Equals("CloseBtn"))
        {

        }
    }

    private void SwitchButton(GameObject target)
    {
        foreach (GameObject obj in menuBtnList)
        {
            UISprite sprite = obj.GetComponent<UISprite>();
            UILabel label = obj.transform.FindChild("Label").GetComponent<UILabel>();

            if (obj.Equals(target))
            {
                sprite.color = new Color(205.0f / 255.0f, 205.0f / 255.0f, 205.0f / 255.0f);
                label.color = new Color(0.0f, 1.0f, 0.0f);
            }
            else
            {
                sprite.color = new Color(1.0f, 1.0f, 1.0f);
                label.color = new Color(1.0f, 1.0f, 1.0f);
            }
        }
    }

    private void Back2PreScene()
    {
        SceneMgr.Instance.SwitchToPreScene();
    }

    private void CloseScene()
    { 
    
    }
    #endregion
}
