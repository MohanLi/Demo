/**
 * Description : 角色攻击
 * Creator : MOhan
 * Date : 2016-04-21
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharactarAttack : MonoBehaviour
{
    /// <summary>
    /// 一般攻击按钮
    /// </summary>
    public Button attackButton;

    /// <summary>
    /// 技能攻击按钮
    /// </summary>
    public Button skillButton;

    /// <summary>
    /// 定义攻击事件委托
    /// </summary>
    public delegate void PlayerAttack();

    /// <summary>
    /// 定义技能事件委托
    /// </summary>
    public delegate void PlayerSkill();

    /// <summary>
    /// 注册攻击委托事件
    /// </summary>
    public event PlayerAttack OnPlayerAttack;

    /// <summary>
    /// 注册技能委托事件
    /// </summary>
    public event PlayerAttack OnPlayerSkill;

    void Start()
    {
        if (attackButton != null)
        {
            attackButton.onClick.RemoveAllListeners();
            attackButton.onClick.AddListener(OnCharactarAttack);
        }

        if (skillButton != null)
        {
            skillButton.onClick.RemoveAllListeners();
            skillButton.onClick.AddListener(OnCharactarSkill);
        }
    }

    void OnCharactarAttack()
    {
        if (this.OnPlayerAttack != null)
        {
            this.OnPlayerAttack();
        }
    }

    void OnCharactarSkill()
    {
        if (this.OnPlayerSkill != null)
        {
            this.OnPlayerSkill();
        }
    }
}
