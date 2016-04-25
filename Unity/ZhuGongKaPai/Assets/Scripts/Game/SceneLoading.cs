using UnityEngine;
using System.Collections;

public class SceneLoading : BaseUI {
    private UISlider slider;
    private UILabel proLabel;

    void Start()
    {
		//调用父类初始化方法
		base.Init ();

        slider = transform.Find("Slider").GetComponent<UISlider>();
        proLabel = transform.Find("Label").GetComponent<UILabel>();

        slider.value = 0f;
        proLabel.text = (100 * slider.value).ToString() + "%";

        StartCoroutine(TestProgress());
    }

    //模拟进度条
    IEnumerator TestProgress()
    {
        yield return new WaitForSeconds(0.1f);
        if (slider.value < 1.0f)
        {
            slider.value += 0.01f;
            ShowProgress(slider.value);

            StartCoroutine(TestProgress());
        }
    }

    void ShowProgress(float value)
    {
        int v = (int)(100 * value);//确保不会出现小数点
        proLabel.text = v.ToString() + "%";
    }
}
