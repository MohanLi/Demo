using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnClick : MonoBehaviour {
    public Sprite sound1;
    public Sprite sound2;
    private bool isPlayMusic = true;

    public void OnPlayBtnClick() {
        SceneManager.LoadScene("main");
    }

    public void OnCreditsBtnClick() {
        Application.OpenURL("https://www.baidu.com/");
    }

    public void OnMoreGameBtnClick() {
        Application.OpenURL("https://www.baidu.com/");
    }

    public void OnSoundBtnClick() {
        if (isPlayMusic) {
            isPlayMusic = false;
            Camera.main.GetComponent<AudioSource>().Stop();
            GetComponent<Image>().sprite = sound1;
        } else {
            isPlayMusic = true;
            Camera.main.GetComponent<AudioSource>().Play();
            GetComponent<Image>().sprite = sound2;
        }
    }
}
