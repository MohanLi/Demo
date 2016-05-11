using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Image mImage;
    public Button button;
    public Text buttonText;

    void Start()
    {
        button.onClick.AddListener(OnClick);
        button.onClick.AddListener(delegate()
        {
            button.onClick.RemoveListener(OnClick);
            Debug.Log("============delegate==========");
        });
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            TestImage();
        }
    }

    #region 测试Image FillAmount
    bool isFilled = false;
    float speed = 0.5f;
    void TestImage()
    {
       if (mImage.fillAmount == 0)
       {
           isFilled = false;
       }
       else if (mImage.fillAmount == 1)
       {
           isFilled = true;
       }

        if (isFilled)
        {
            mImage.fillAmount -= Time.deltaTime * speed;
        }
        else
        {
            mImage.fillAmount += Time.deltaTime * speed;
        }
    }
    #endregion

    #region 测试Button
    public void OnClick()
    {
        buttonText.text = "OnClick : " + name;
        Debug.Log("buttonText.text : " + buttonText.text);
    }

    #endregion
}
