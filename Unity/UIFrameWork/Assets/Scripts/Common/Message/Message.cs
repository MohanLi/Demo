/*************************************
 * Author : Mohan
 * Desc : $Description$
 * Date : 5/13/2016 10:02:30 AM
 * Version : 1.0.0
 *
*************************************/
using System;
using System.Collections;
using System.Collections.Generic;

namespace UIFrameWork
{
    public class Message : IEnumerable<KeyValuePair<string, object>>
    {
        private Dictionary<string, object> dictDatas = null;

        public string Name { get; private set; }
        public object Sender { get; private set; }
        public object Content { get; set; }

        #region message[key] = value or data = message[key]

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                if (null == dictDatas || dictDatas.ContainsKey(key))
                {
                    return null;
                }
                return dictDatas[key];
            }
            set
            {
                if (null == dictDatas)
                {
                    dictDatas = new Dictionary<string, object>();
                }
                if (dictDatas.ContainsKey(key))
                {
                    dictDatas[key] = value;
                }
                else
                {
                    dictDatas.Add(key, value);
                }
            }
        }

        #endregion

        #region IEnumerable implementation

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            if (null == dictDatas)
            {
                yield break;
            }
            foreach (KeyValuePair<string, object> kvp in dictDatas)
            {
                yield return kvp;
            }
        }

        #endregion

        #region IEnumerabl implementation

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dictDatas.GetEnumerator();
        }

        #endregion

        #region Message construction Function 构造函数

        public Message (string name, object sender)
        {
            Name = name;
            Sender = sender;
            Content = null;
        }

        public Message(string name, object sender, object content)
        {
            Name = name;
            Sender = sender;
            Content = content;
        }

        public Message (string name, object sender, object content, params object[] objParams)
        {
            Name = name;
            Sender = sender;
            Content = content;

            if (objParams.GetType() == typeof(Dictionary<string, object>))
            {
                foreach (object objParam in objParams)
                {
                    foreach (KeyValuePair<string, object> kvp in objParam as Dictionary<string, object>)
                    {
                        this[kvp.Key] = kvp.Value;
                    }
                }
            }
        }

        public Message (Message message)
        {
            Name = message.Name;
            Sender = message.Sender;
            Content = message.Content;

            foreach (KeyValuePair<string, object> kvp in message.dictDatas)
            {
                this[kvp.Key] = kvp.Value;
            }
        }

        #endregion

        #region Add && Remove

        public void Add(string key, object value)
        {
            this[key] = value;
        }

        public void Remove(string key)
        {
            if (! string.IsNullOrEmpty(key) && dictDatas.ContainsKey(key))
            {
                dictDatas.Remove(key);
            }
        }

        #endregion

        #region Send()
        public void Send()
        {
            // MessageCenter 
            MessageCenter.Instance.SendMessage(this);
        }

        #endregion
    }
}
