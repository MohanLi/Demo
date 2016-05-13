/*************************************
 * Author : Mohan
 * Desc : $Description$
 * Date : 5/13/2016 5:09:05 PM
 * Version : 1.0.0
 *
*************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UIFrameWork
{
    public class TestTwo : BaseUI
    {
        public override EnumUIType GetUIType()
        {
            return EnumUIType.TestTwo;
        }

        protected override void OnStart()
        {
            Debug.Log("=======OnStart========");
            InitButton();
        }

        void InitButton()
        {
            GameObject go = transform.FindChild("Button").gameObject;
            EventTriggerListener listsner = EventTriggerListener.Get(go);
            listsner.SetEventHandle(EnumTouchEventType.OnClick, ButtonEvent, 1, "Hahahah");
        }

        void ButtonEvent(EventTriggerListener listener, object args, params object[] objParams)
        {
            Debug.Log("ButtonEvent");
            UIManager.Instance.OpenUICloseOthers(EnumUIType.TestOne);
        }
    }
}
