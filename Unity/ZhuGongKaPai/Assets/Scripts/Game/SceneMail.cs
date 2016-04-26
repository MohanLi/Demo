using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SceneMail : SceneBase {
    private GameObject item;
    private List<GameObject> itemsList;
    private float originY = 130f;
    private float marginY = 113f;

    private string DELETEBUTTON = "DeleteBtn";
    private string SENDETIME = "Time";
    private string SENDER = "Sender"; 

    private string SENDERNAME = "魔帝";

    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/SceneMail");
        base.OnInitSkin();
    }

    protected override void OnInitDone()
    {
        base.OnInitDone();

        itemsList = new List<GameObject>();
        item = (GameObject) SkinTransform.Find("PanelMove/Items/Item").gameObject;
        ShowItems();
    }

    protected override void OnClick(GameObject target)
    {
        base.OnClick(target);
        if (target.name.Equals("BackBtn"))
        {
            SceneMgr.Instance.SwitchToPreScene();
        }
        else if (target.name.Equals("CloseBtn"))
        {

        }
    }

    //显示Item
    void ShowItems()
    {
        if (item == null)
        {
            return;
        }
        
        for (int i = 0; i < 10; i++)
        {
            GameObject it = Instantiate(item);
            it.transform.SetParent(item.transform.parent);
            it.transform.localEulerAngles = Vector3.zero;
            it.transform.localScale = Vector3.one;
            it.SetActive(true);
            
            itemsList.Add(it);
            InitItem(it, i);
        }
    }

    //初始化Item
    private void InitItem(GameObject item, int index)
    {
        if (item == null)
        {
            return;
        }

        string sender = SENDERNAME + index.ToString();
        SetSender(item, sender);

        SetTime(item, DateTime.Now.ToString());
        RegisterDeleteButton(item);

        SetItemPosition(item, index, originY, marginY);
    }
    //注册删除按钮
    private void RegisterDeleteButton(GameObject item)
    {
        
        GameObject deleteButton = item.transform.Find(DELETEBUTTON).gameObject;
        UIEventListener eventListener = UIEventListener.Get(deleteButton);
        eventListener.onClick = OnDeleteBtnClick;
    }

    //设置发件人
    private void SetSender(GameObject item,  string strSender)
    {
        UILabel sender = item.transform.Find(SENDER).GetComponent<UILabel>();
        sender.text = strSender;
    }

    //设置发件时间
    private void SetTime(GameObject item, string time)
    {
        UILabel timeLabel = item.transform.Find(SENDETIME).GetComponent<UILabel>();
        timeLabel.text = time;
    }

    //点击删除按钮监听回调
    private void OnDeleteBtnClick(GameObject go)
    {
        if (go.name.Equals(DELETEBUTTON))
        {
            itemsList.Remove(go.transform.parent.gameObject);
            Destroy(go.transform.parent.gameObject);
            ResetItemsPosition();
        }
    }

    //设置item位置
    private void SetItemPosition(GameObject item, int index, float originPosY, float margin)
    {
        item.transform.localPosition = new Vector3(0, originPosY - index * margin, 0f);
    }

    //重置全部item的位置
    private void ResetItemsPosition()
    {
        for (int i = 0; i < itemsList.Count; i++)
        {
            SetItemPosition(itemsList[i], i, originY, marginY);
        }
    }
}
