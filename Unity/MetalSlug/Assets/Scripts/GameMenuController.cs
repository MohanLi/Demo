using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{
    public GameObject menuPlay;
    public GameObject operationPlay;
    public GameObject difficultPlay;
    public GameObject selectPlay;

    public Color mColor;

    public void OnMenuClick()
    {
        menuPlay.SetActive(false);
        operationPlay.SetActive(true);
    }

    public void OnOperationClick()
    {
        operationPlay.GetComponent<UISprite>().color = mColor;
        difficultPlay.SetActive(true);
    }

    public void OnDifficultClick()
    {
        operationPlay.SetActive(false);
        difficultPlay.SetActive(false);
        selectPlay.SetActive(true);
    }

    public void OnSelectClick()
    {
        SceneManager.LoadScene(1);
    }
}
