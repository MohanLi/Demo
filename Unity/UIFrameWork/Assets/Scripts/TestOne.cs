using UnityEngine;
using System.Collections;
using UIFrameWork;

public class TestOne : BaseUI {

    public override EnumUIType GetUIType()
    {
        return EnumUIType.TestOne;
    }

	// Use this for initialization
	void TestResourcesManager () 
    {

    /**

        float time = System.Environment.TickCount;

        GameObject go = null;
        for (int i = 0; i < 1000; i++ )
        {
            // 1 15
            //go = Instantiate(Resources.Load("Cube")) as GameObject;
            //go.transform.localPosition = UnityEngine.Random.insideUnitSphere * 20;

            //2 15
            //go = ResourcesManager.Instance.LoadInstance("Cube") as GameObject;
            //go.transform.localPosition = UnityEngine.Random.insideUnitSphere * 20;

            //3 
            //ResourcesManager.Instance.LoadAsyncInstance("Cube", (_obj) =>
            //{
            //    go = _obj as GameObject;
            //    go.transform.localPosition = UnityEngine.Random.insideUnitSphere * 20;
            //});

            // 4 1 加载速度最快
            //ResourcesManager.Instance.LoadCoroutineInstance("Cube", (_obj) =>
            //{
            //    go = _obj as GameObject;
            //    go.transform.localPosition = UnityEngine.Random.insideUnitSphere * 20;
            //});

        }

        Debug.Log(System.Environment.TickCount - time);
        ***/
	}

    protected override void OnStart()
    {
        base.OnStart();
        InitButton();
    }

    void InitButton()
    {
        GameObject go = transform.Find("Button").gameObject;

        EventTriggerListener listsner = EventTriggerListener.Get(go);
        listsner.SetEventHandle(EnumTouchEventType.OnClick, DebugMsg, 1, "Hello");
    }

    void DebugMsg(EventTriggerListener listener, object args, params object[] objParams)
    {
        Debug.Log((int)objParams[0]);
        Debug.Log((string)objParams[1]);

        UIManager.Instance.OpenUICloseOthers(EnumUIType.TestTwo);
    }
}
