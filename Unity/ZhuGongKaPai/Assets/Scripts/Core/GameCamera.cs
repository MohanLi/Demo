using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour
{
    float devHeight = 11.36f;
    float devWidth = 6.4f;

    // Use this for initialization
    void Start()
    {

        float screenHeight = Screen.height;

        Debug.Log("screenHeight = " + screenHeight);

        //this.GetComponent<Camera>().orthographicSize = screenHeight / 200.0f;

        float orthographicSize = this.GetComponent<Camera>().orthographicSize;

        float aspectRatio = Screen.width * 1.0f / Screen.height;
        Debug.Log("1==========Screen.width : " + Screen.width + " , Screen.height : " + Screen.height);

        float cameraWidth = orthographicSize * 2 * aspectRatio;

        //Debug.Log("cameraWidth = " + cameraWidth);

        if (cameraWidth < devWidth || true)
        {
            Debug.Log("2=======================Screen.width : " + Screen.width + " , Screen.height : " + Screen.height);
            orthographicSize = devWidth / (2 * aspectRatio);
            //Debug.Log("new orthographicSize = " + orthographicSize);
            this.GetComponent<Camera>().orthographicSize = orthographicSize;
            Debug.Log("3=======================Screen.width : " + Screen.width + " , Screen.height : " + Screen.height);
        }
    }
}