/*************************************
 * Author : Mohan
 * Desc : $Description$
 * Date : 5/13/2016 10:02:44 AM
 * Version : 1.0.0
 *
*************************************/
using System;
using System.Collections.Generic;

namespace UIFrameWork
{
    class MessageCenter : Singleton<MessageCenter>
    {
        private Dictionary<string, List<MessageEvent>> dictMessageEvents = null;

        protected override void Init()
        {
            dictMessageEvents = new Dictionary<string, List<MessageEvent>>();
        }

        #region AddListener && RemoveListener

        public void AddListener(MessageType mType, MessageEvent messageEvent)
        {
            AddListener(mType.ToString(), messageEvent);
        }

        public void RemoveListener(MessageType mType, MessageEvent messageEvent)
        {
            RemoveListener(mType.ToString(), messageEvent);
        }

        public void AddListener(string messageName, MessageEvent messageEvent)
        {
            List<MessageEvent> list = null;
            if (dictMessageEvents.ContainsKey(messageName))
            {
                list = dictMessageEvents[messageName];
            }
            else
            {
                list = new List<MessageEvent>();
                list.Add(messageEvent);
            }
            dictMessageEvents.Add(messageName, list);
        }

        public void RemoveListener(string messageName, MessageEvent messageEvent)
        {
            if (dictMessageEvents.ContainsKey(messageName))
            {
                List<MessageEvent> list = dictMessageEvents[messageName];
                if (list.Contains(messageEvent))
                {
                    list.Remove(messageEvent);//此处可能有问题，待验证
                }
                if (list.Count <= 0)
                {
                    dictMessageEvents.Remove(messageName);
                }
            }
        }

        public void RemoveAllListener()
        {
            dictMessageEvents.Clear();
        }

        #endregion

        #region Construction Function 构造函数

        public void SendMessage(Message message)
        {
            DoMessageDispatcher(message);
        }

        public void SendMessage(string name, object sender)
        {
            SendMessage(new Message(name, sender));
        }

        public void SendMessage(string name, object sender, object content)
        {
            SendMessage(new Message(name, sender, content));
        }

        public void SendMessage(string name, object sender, object content, params object[] dictParams)
        {
            SendMessage(new Message(name, sender, content, dictParams));
        }

        private void DoMessageDispatcher(Message message)
        {
            if (dictMessageEvents == null || !dictMessageEvents.ContainsKey(message.Name))
            {
                return;
            }

            List<MessageEvent> list = dictMessageEvents[message.Name];
            for (int i = 0; i < list.Count; i++)
            {
                MessageEvent messageEvent = list[i];
                if (null != messageEvent)
                {
                    messageEvent(message);
                }
            }
        }

        #endregion
    }
}
