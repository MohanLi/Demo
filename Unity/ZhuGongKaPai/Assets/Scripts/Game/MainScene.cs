using UnityEngine;
using System.Collections;

public class MainScene :  SceneBase
{
    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/MainScene");
        base.OnInitSkin();
    }

    protected override void OnClick(GameObject target)
    {
        base.OnClick(target);

        if (target.name.Equals("MailBtn"))
        {
			SceneMgr.Instance.SwitchScene(SceneType.SceneMail);
        }
        else
        {
            PanelMgr.Instance.ShowPanel("PlayerInfoUI");
        }
    }
}
