using UnityEngine;
using System.Collections;

public class SceneLogin : BaseUI
{

    private UIInput inputAcc;
    private UIInput inputPassword;

    private UILabel testLabel;
    private string showText;

	// Use this for initialization
	void Start () {
		//调用父类初始化方法
		base.Init ();

        inputAcc = transform.Find("InputAcc").GetComponent<UIInput>();
        inputPassword = transform.Find("InputPassword").GetComponent<UIInput>();

		/**
        BoxCollider[] boxColliders = transform.GetComponentsInChildren<BoxCollider>(true);//true表示包括隐藏的
        foreach (BoxCollider bCollider in boxColliders)
        {
            UIEventListener eventListener = UIEventListener.Get(bCollider.gameObject);
            eventListener.onClick = OnButtonClick;
        }
		***/
        //testLabel = transform.Find("TestLabel").GetComponent<UILabel>();
        //Test();
	}

	protected override void OnClick (GameObject target)
	{
		base.OnClick (target);
		OnButtonClick (target);
	}

	protected override void OnDestroyBefore ()
	{
		base.OnDestroyBefore ();
	}

	protected override void OnDestroyEnd ()
	{
		base.OnDestroyEnd ();

		inputAcc = null;
		inputPassword = null;
		Debug.Log ("=======OnDestroyEnd===========");
	}

    void OnButtonClick(GameObject go)
    {
        if (go.name.Equals("RegisterBtn"))
        {
            Debug.Log(string.Format("一键注册，账号：{0}， 密码：{1}", inputAcc.value, inputPassword.value));
        }
        else if (go.name.Equals("LoginBtn"))
        {
            Debug.Log(string.Format("登陆按钮，账号：{0}， 密码：{1}", inputAcc.value, inputPassword.value));
			/***
            GameObject obj = ResourceMsg.GetInstance().CreateGameObject("Game/UI/SceneLoading");
            obj.AddComponent<SceneLoading>();

            Destroy(transform.gameObject);
			***/

			GameObject obj = SceneMgr.Instance.SwitchScene("Game/UI/SceneLoading");
			obj.AddComponent<SceneLoading>();
        }
    }
	
    //void Test()
    //{
    //    testLabel.text = "";
    //    showText = "待到阴阳sd逆乱时，\n待到阴阳逆乱时，以我魔血染青天";
    //    StartCoroutine(Show());
    //}

    //IEnumerator Show()
    //{
    //    ShowText();

    //    yield return new WaitForSeconds(0.1f);
    //    if (!showText.Equals(""))
    //    {
    //        StartCoroutine(Show());
    //    }
    //}

    //void ShowText()
    //{
    //    string text = showText;
    //    char[] c = text.ToCharArray();
    //    if (c.Length > 0)
    //    {
    //        testLabel.text = testLabel.text + c[0].ToString();
    //        showText = showText.Substring(1);//删除showText第一个字符
    //    }
    //}
}
