/*************************************
 * Author : Mohan
 * Desc : $Description$
 * Date : 5/12/2016 7:44:59 PM
 * Version : 1.0.0
 *
*************************************/
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrameWork
{
    public class ModuleManager : Singleton<ModuleManager>
    {
        private Dictionary<string, BaseModule> dictModules = null;

        protected override void Init()
        {
            dictModules = new Dictionary<string, BaseModule>();
        }


        #region Get Module

        public BaseModule Get(string key)
        {
            if (dictModules.ContainsKey(key))
            {
                return dictModules[key];
            }
            return null;
        }

        public T Get<T>() where T : BaseModule
        {
            Type t = typeof(T);
            if (dictModules.ContainsKey(t.ToString()))
            {
                return dictModules[t.ToString()] as T;
            }
            return null;
        }

        #endregion

        #region Register

        public void Register(BaseModule module)
        {
            Type t = module.GetType();
            Register(t.ToString(), module);
        }

        public void Register(string key, BaseModule module)
        {
            if (dictModules.ContainsKey(key)) return;
            dictModules.Add(key, module);
        }

        #endregion

        #region Un Reginster

        public void UnRegister(BaseModule module)
        {
            Type t = module.GetType();
            UnRegister(t.ToString());
        }

        public void UnRegister(string key)
        {
            if (dictModules.ContainsKey(key))
            {
                BaseModule module = dictModules[key];
                module.Release();

                dictModules.Remove(key);
                module = null;
            }
        }
        public void UnRegisterAll()
        {
            List<string> keys = new List<string>(dictModules.Keys);
            for (int i = 0; i < keys.Count; i++)
            {
                UnRegister(keys[i]);
            }
            dictModules.Clear();
        }

        #endregion
    }
}
