/*************************************
 * Author : Mohan
 * Desc : $Description$
 * Date : 5/12/2016 6:35:10 PM
 * Version : 1.0.0
 *
*************************************/
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrameWork
{
    public class BaseModule
    {
        public enum EnumRegisterMode
        { 
            NotRegister,
            AutoRegister,
            AlreadyRegister
        }

        private EnumObjectState state = EnumObjectState.Initial;

        public EnumObjectState State
        {
            get
            {
                return state;
            }
            set
            {
                if (State == value) return;
                EnumObjectState oldState = State;
                state = value;

                if (null != StateChanged)
                {
                    //此处调用有问题，等待修复
                    //StateChanged(this, this.State, oldState);
                }
                OnStateChanged(State, oldState);
            }
        }
        public event StateChangeEvent StateChanged;
        

        protected virtual void OnStateChanged(EnumObjectState newState, EnumObjectState oldState)
        {

        }

        private EnumRegisterMode registerMode = EnumRegisterMode.NotRegister;

        public bool IsAutoRegister
        { 
            get
            {
                return registerMode == EnumRegisterMode.NotRegister ? false : true;
            }
            set
            {
                if (registerMode == EnumRegisterMode.NotRegister || registerMode == EnumRegisterMode.AutoRegister)
                {
                    registerMode = value ? EnumRegisterMode.AutoRegister : EnumRegisterMode.NotRegister;
                }
            }
        }

        public bool IsHasRegistered
        {
            get
            {
                return registerMode == EnumRegisterMode.AlreadyRegister;
            }
        }

        public void Load()
        {
            if (State != EnumObjectState.Initial) return;

            State = EnumObjectState.Loading;

            if (registerMode == EnumRegisterMode.AutoRegister)
            {
                //register
                registerMode = EnumRegisterMode.AlreadyRegister;
            }
            OnLoad();

            State = EnumObjectState.Ready;
        }

        protected virtual void OnLoad()
        { 
        
        }

        public void Release()
        {
            if (State != EnumObjectState.Disabled)
            {
                State = EnumObjectState.Disabled;
                if (registerMode == EnumRegisterMode.AlreadyRegister)
                {
                    registerMode = EnumRegisterMode.AutoRegister;
                }

                OnRelease();
            }
        }

        protected virtual void OnRelease()
        { 
        
        }
    }
}
