using UnityEngine;
using System.Collections;

public class MainScene :  SceneBase
{
    #region 初始化相关
    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/MainScene");
        base.OnInitSkin();
    }

    protected override void OnInitDone()
    {
        base.OnInitDone();
    }

    protected override void OnClick(GameObject target)
    {
        base.OnClick(target);
        OnButtonClick(target);
    }
    #endregion

    #region 点击事件
    void OnButtonClick(GameObject target)
    {
        switch(target.name)
        {
            case "HeadBtn": //角色ICON
                OnHeadBtnClick();
                break;
            case "MailBtn": //邮件
                OnMailBtnClick();
                break;
            case "ChatBtn": //聊天
                OnChatBtnClick();
                break;
            case "FriendBtn": //好友
                break;
            case "AddStreagthBtn": //添加体力
                break;
            case "AddWingBtn": //添加元宝
                break;
            case "RightBtnArr": //缩放显示按钮按钮
                break;
            case "TaskBtn": //任务
                break;
            case "TransformBtn": //变身
                break;
            case "GeneralBtn": //武将
                break;
            case "EmbattleBtn": //布阵
                break;
            case "EquipmentBtn": //装备
                break;
            case "PackageBtn": //背包
                break;
            case "UnionBtn": //工会
                break;
            case "SettingBtn": //设置
                break;
            default:
                break;
        }
    }
    #endregion

    #region 点击按钮回调
    /// <summary>
    /// 点击角色按钮回调
    /// </summary>
    private void OnHeadBtnClick()
    {
        PanelMgr.Instance.SetDurationTime(0.2f);
        PanelMgr.Instance.SetPanelShowStyle(PanelShowStyle.MoveFromLeft);
        PanelMgr.Instance.ShowPanel(PanelType.PlayerInfoUI);
    }

    /// <summary>
    /// 点击邮件回调
    /// </summary>
    private void OnMailBtnClick()
    {
        SceneMgr.Instance.SwitchScene(SceneType.SceneMail);
    }

    /// <summary>
    /// 点击聊天回调
    /// </summary>
    private void OnChatBtnClick() 
    {
    
    }

    #endregion
}
