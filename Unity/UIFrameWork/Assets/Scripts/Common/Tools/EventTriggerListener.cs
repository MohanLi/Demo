/*************************************
 * Author : Mohan
 * Desc : $Description$
 * Date : 5/13/2016 2:01:50 PM
 * Version : 1.0.0
 *
*************************************/

using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIFrameWork
{
    #region TouchHandle

    public class TouchHandle
    {
        private event OnTouchEventHandle eventHandle = null;
        private object[] handleParams;

        public TouchHandle(OnTouchEventHandle handle, params object[] objParams)
        {
            SetHandle(handle, objParams);
        }

        public TouchHandle()
        {

        }

        /// <summary>
        /// 移除事件
        /// </summary>
        public void RemoveHandle()
        {
            if (null != eventHandle)
            {
                eventHandle -= eventHandle;
                eventHandle = null;
            }
        }

        /// <summary>
        /// 设置事件
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="objParams"></param>
        public void SetHandle(OnTouchEventHandle handle, params object[] objParams)
        {
            RemoveHandle();
            eventHandle += handle;
            handleParams = objParams;
        }

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="args"></param>
        public void TriggerHandle(EventTriggerListener listener, object args)
        {
            if (null != eventHandle)
            {
                eventHandle(listener, args, handleParams);
            }
        }
    }

    #endregion

    public class EventTriggerListener : MonoBehaviour,
        IPointerClickHandler,
        IPointerDownHandler,
        IPointerEnterHandler,
        IPointerExitHandler,
        IPointerUpHandler,
        ISelectHandler,
        IUpdateSelectedHandler,
        IDeselectHandler,
        IDragHandler,
        IEndDragHandler,
        IDropHandler,
        IScrollHandler, 
        IMoveHandler
    {
        public TouchHandle onClick;
        public TouchHandle onDoubleClick;
        public TouchHandle onDown;
        public TouchHandle onEnter;
        public TouchHandle onExit;
        public TouchHandle onUp;
        public TouchHandle onSelect;
        public TouchHandle onUpdateSelected;
        public TouchHandle onDeselect;
        public TouchHandle onDrag;
        public TouchHandle onEndDrag;
        public TouchHandle onDrop;
        public TouchHandle onScroll;
        public TouchHandle onMove;

        public static EventTriggerListener Get(GameObject sender)
        {
            //EventTriggerListener listener = sender.GetComponent<EventTriggerListener>();
            //if (null == listener)
            //{
            //    listener = sender.AddComponent<EventTriggerListener>();
            //}
            //return listener;
            return sender.GetOrAddCompenent<EventTriggerListener>();
        }

        void OnDestroy()
        {
            this.RemoveAllHandle();
        }

        private void RemoveAllHandle()
        {
            RemoveHandle(onClick);
            RemoveHandle(onDoubleClick);
            RemoveHandle(onDown);
            RemoveHandle(onEnter);
            RemoveHandle(onExit);
            RemoveHandle(onUp);
            RemoveHandle(onSelect);
            RemoveHandle(onUpdateSelected);
            RemoveHandle(onDeselect);
            RemoveHandle(onEndDrag);
            RemoveHandle(onDrop);
            RemoveHandle(onScroll);
            RemoveHandle(onMove);
        }

        private void RemoveHandle(TouchHandle handle)
        {
            if (null != handle)
            {
                handle.RemoveHandle();
                handle = null;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (null != onClick)
            {
                onClick.TriggerHandle(this, eventData);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (null != onDown)
            {
                onDown.TriggerHandle(this, eventData);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (null != onEnter)
            {
                onEnter.TriggerHandle(this, eventData);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (null != onExit)
            {
                onExit.TriggerHandle(this, eventData);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (null != onUp)
            {
                onUp.TriggerHandle(this, eventData);
            }
        }

        public void OnSelect(BaseEventData eventData)
        {
            if (null != onSelect)
            {
                onSelect.TriggerHandle(this, eventData);
            }
        }

        public void OnUpdateSelected(BaseEventData eventData)
        {
            if (null != onUpdateSelected)
            {
                onUpdateSelected.TriggerHandle(this, eventData);
            }
        }

        public void OnDeselect(BaseEventData eventData)
        {
            if (null != onDeselect)
            {
                onDeselect.TriggerHandle(this, eventData);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (null != onDrag)
            {
                onDrag.TriggerHandle(this, eventData);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (null != onEndDrag)
            {
                onEndDrag.TriggerHandle(this, eventData);
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (null != onDrop)
            {
                onDrop.TriggerHandle(this, eventData);
            }
        }

        public void OnScroll(PointerEventData eventData)
        {
            if (null != onScroll)
            {
                onScroll.TriggerHandle(this, eventData);
            }
        }

        public void OnMove(AxisEventData eventData)
        {
            if (null != onMove)
            {
                onMove.TriggerHandle(this, eventData);
            }
        }

        public void SetEventHandle(EnumTouchEventType type, OnTouchEventHandle handle, params object[] objParams)
        {
            switch(type)
            {
                case EnumTouchEventType.OnClick:
                    if (null == onClick)
                    {
                        onClick = new TouchHandle();
                    }
                    onClick.SetHandle(handle, objParams);
                    break;
                case EnumTouchEventType.OnDoubleClick:
                    if (null == onDoubleClick)
                    {
                        onDoubleClick = new TouchHandle();
                    }
                    onDoubleClick.SetHandle(handle, objParams);
                    break;
                case EnumTouchEventType.OnDeSelect:
                    if (null == onSelect)
                    {
                        onSelect = new TouchHandle();
                    }
                    onSelect.SetHandle(handle, objParams);
                    break;
                case EnumTouchEventType.OnDown:
                    if (null == onDown)
                    {
                        onDown = new TouchHandle();
                    }
                    onDown.SetHandle(handle, objParams);
                    break;
                case EnumTouchEventType.OnDrag:
                    if (null == onDrag)
                    {
                        onDrag = new TouchHandle();
                    }
                    onDrag.SetHandle(handle, objParams);
                    break;
                case EnumTouchEventType.OnDragEnd:
                    if (null == onEndDrag)
                    {
                        onEndDrag = new TouchHandle();
                    }
                    onEndDrag.SetHandle(handle, objParams);
                    break;
                case EnumTouchEventType.OnDrop:
                    if (null == onDrop)
                    {
                        onDrop = new TouchHandle();
                    }
                    onDrop.SetHandle(handle, objParams);
                    break;
                case EnumTouchEventType.OnEnter:
                    if (null == onEnter)
                    {
                        onEnter = new TouchHandle();
                    }
                    onEnter.SetHandle(handle, objParams);
                    break;
                case EnumTouchEventType.OnExit:
                    if (null == onExit)
                    {
                        onExit = new TouchHandle();
                    }
                    onExit.SetHandle(handle, objParams);
                    break;
                case EnumTouchEventType.OnMove:
                    if (null == onMove)
                    {
                        onMove = new TouchHandle();
                    }
                    onMove.SetHandle(handle, objParams);
                    break;
                case EnumTouchEventType.OnScroll:
                    if (null == onScroll)
                    {
                        onScroll = new TouchHandle();
                    }
                    onScroll.SetHandle(handle, objParams);
                    break;
                case EnumTouchEventType.OnSelect:
                    if (null == onSelect)
                    {
                        onSelect = new TouchHandle();
                    }
                    onSelect.SetHandle(handle, objParams);
                    break;
                case EnumTouchEventType.OnUp:
                    if (null == onUp)
                    {
                        onUp = new TouchHandle();
                    }
                    onUp.SetHandle(handle, objParams);
                    break;
                case EnumTouchEventType.OnUpdateSelect:
                    if (null == onUpdateSelected)
                    {
                        onUpdateSelected = new TouchHandle();
                    }
                    onUpdateSelected.SetHandle(handle, objParams);
                    break;
                default:
                    break;
            }
        }

        private void SetTouchHandle(TouchHandle touchHandle, OnTouchEventHandle handle, params object[] objParams)
        {
            if (null == touchHandle)
            {
                touchHandle = new TouchHandle();
            }
            touchHandle.SetHandle(handle, objParams);
        }
    }
}
