using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SwitchCamare : MonoBehaviour 
{
    Button switchButton;
    Camera mainCamera;
    public Camera playerCamera;

    void Start()
    {
        mainCamera = Camera.main;
        playerCamera.enabled = false;

        GameObject obj = GameObject.Find("switchButton");
        switchButton = obj.GetComponent<Button>();
        switchButton.onClick.RemoveAllListeners();
        switchButton.onClick.AddListener(switchCamare);
    }

    void switchCamare()
    {
        playerCamera.enabled = !playerCamera.enabled;
        mainCamera.enabled = !mainCamera.enabled;
    }
}
