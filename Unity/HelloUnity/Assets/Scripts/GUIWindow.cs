using UnityEngine;
using System.Collections;

public class GUIWindow : MonoBehaviour {
    private bool isShow;
    private Rect windowRect;
    public Texture2D sprite;

	// Use this for initialization
	void Start () {
        isShow = false;
        windowRect = new Rect(100, 100, 200, 100);
	}

    void OnGUI() {
        if (GUILayout.Button("Show")) {
            isShow = true;
        }

        if (isShow) {
            windowRect = GUILayout.Window(2, windowRect, Func1, "窗口2"); //2、接受拖拽位置并赋值
        }

        //绘制块
        GUI.DrawTexture(new Rect(100, 100, sprite.width, sprite.height), sprite);
    }

    public void Func1(int id) { // id 为窗口调用时传过来的
        if (id == 2) {
            if (GUILayout.Button("点我隐藏窗口2")) {
                isShow = false;
            }
            GUI.DragWindow(); //1、支持拖拽
        }
    }
}
