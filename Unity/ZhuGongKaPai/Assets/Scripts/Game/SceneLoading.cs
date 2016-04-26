using UnityEngine;
using System.Collections;

public class SceneLoading : SceneBase {
    private UISlider slider;
    private UILabel proLabel;

    //void Start()
    //{
    //    //调用父类初始化方法
    //    base.Init ();

    //    slider = transform.Find("Slider").GetComponent<UISlider>();
    //    proLabel = transform.Find("Label").GetComponent<UILabel>();

    //    slider.value = 0f;
    //    proLabel.text = (100 * slider.value).ToString() + "%";

    //    StartCoroutine(TestProgress());
    //}

    protected override void OnInitSkin()
    {
        base.SetMainSkinPath("Game/UI/SceneLoading");
        base.OnInitSkin();
    }

    protected override void OnInitDone()
    {
        base.OnInitDone();

        slider = SkinTransform.Find("Slider").GetComponent<UISlider>();
        proLabel = SkinTransform.Find("Label").GetComponent<UILabel>();

        slider.value = 0f;
        proLabel.text = (100 * slider.value).ToString() + "%";

        StartCoroutine(TestProgress());


        //测试打印传过来的参数
        foreach (var item in UIArgs)
        {
            Debug.Log(item);
        }

    }

    //模拟进度条
    IEnumerator TestProgress()
    {
        yield return new WaitForSeconds(0.01f);
        if (slider.value < 1.0f)
        {
            slider.value += 0.01f;
            ShowProgress(slider.value);

            StartCoroutine(TestProgress());
        }
        else
        {
            SceneMgr.Instance.SwitchScene("MainScene");
        }
    }

    void ShowProgress(float value)
    {
        int v = (int)(100 * value);//确保不会出现小数点
        proLabel.text = v.ToString() + "%";
    }
}
