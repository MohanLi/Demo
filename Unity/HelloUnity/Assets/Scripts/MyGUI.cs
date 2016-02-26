using UnityEngine;
using System.Collections;

public class MyGUI : MonoBehaviour {

    private string str;
    private string password;
    private bool isShow;
	// Use this for initialization
	void Start () {
        str = "";
        password = "123456";
        isShow = false;
	}
	
    //每帧调用一次（删除，绘制）
    void OnGUI() {
        //开启水平布局
        GUILayout.BeginHorizontal();

        GUILayout.TextField("HelloWorld", GUILayout.Width(100));
        str = GUILayout.TextField(str, GUILayout.Width(100));

        password = GUILayout.PasswordField(password, '*');

        GUILayout.Label("I am Label", GUILayout.Width(100));

        if (GUILayout.Button("ShowLog")) { //挡鼠标抬起的时候返回true
            Debug.Log(1);
        }

        if (GUILayout.RepeatButton("ShowLogRepeat")) {
            Debug.Log(2);
        }
        //结束水平布局
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Move Camera")) {
            Camera.main.transform.Translate(Vector3.forward);
            isShow = !isShow;
        }

        if (isShow) {
            GUILayout.Label("Hello Mohan", GUILayout.Width(100));
        }
    }

}
