/**
 * Description : 角色攻击
 * Creator : Mohan
 * Date : 2016-04-21
 */

using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    /// <summary>
    /// 攻击动画名称
    /// </summary>
    string[] attackNames = {"Combo", "Attack", "Attack01", "Attack02"};

    /// <summary>
    /// 技能动画名称
    /// </summary>
    string[] skillNames = {"Skill"};

    /// <summary>
    /// 是否正在使用技能攻击
    /// </summary>
    private bool isSkilling = false;

    /// <summary>
    /// 是否正在普通攻击
    /// </summary>
    private bool isAttacking = false;

    Animation playerAnimation;
    AnimationEvent animationEvent;

    void Awake()
    {
        CharactarAttack charactar = GameObject.FindObjectOfType<CharactarAttack>();
        charactar.OnPlayerAttack += OnPlayerAttack;
        charactar.OnPlayerSkill += OnPlayerSkill;
    }

    void Start()
    {
        playerAnimation = GetComponent<Animation>();
        animationEvent = new AnimationEvent();
    }

    void OnPlayerAttack()
    {
        Debug.Log("isAttacking : " + isAttacking + " , isSkilling : " + isSkilling);
        if (!isAttacking && !isSkilling)
        {
            isAttacking = true;
            string name = attackNames[Random.Range(0, attackNames.Length)];
            playerAnimation.CrossFade(name);


            //animation是read only ，无法添加 animation event
            float time = playerAnimation.GetClip(name).length;
            Invoke("OnAttackEndCallback", time);
        }
    }

    void OnPlayerSkill()
    {
        Debug.Log("isAttacking : " + isAttacking + " , isSkilling : " + isSkilling);
        if (!isAttacking && !isSkilling)
        {
            isSkilling = true;
            string name = skillNames[Random.Range(0, skillNames.Length)];
            playerAnimation.CrossFade(name);

            float time = playerAnimation.GetClip(name).length;
            Invoke("OnSkillEndCallback", time);
        }
    }

    void OnSkillEndCallback()
    {
        isSkilling = false;
        Debug.Log("OnSkillEndCallback");
    }

    void OnAttackEndCallback()
    {
        isAttacking = false;
        Debug.Log("OnAttackEndCallback");
    }
}
