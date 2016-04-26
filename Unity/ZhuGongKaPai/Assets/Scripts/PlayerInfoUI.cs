using UnityEngine;
using System.Collections;

public class PlayerInfoUI : PanelBase 
{
    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/PlayerInfoUI");
        base.OnInitSkin();
    }

    protected override void OnClick(GameObject target)
    {
        base.OnClick(target);
        if (target.name.Equals("CloseBtn"))
        {
            Close();
        }
    }
}
