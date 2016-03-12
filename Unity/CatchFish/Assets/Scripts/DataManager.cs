using UnityEngine;
using System.Collections;


public class DataManager{
    private volatile static DataManager mInstance = null;
    private static readonly object lockHelper = new object();

    //炮塔旋转角度
    private float mBatteryAngle;
    //炮塔transform
    private Transform mTransform;

    private DataManager() {
        mBatteryAngle = 0f;
        mTransform = null;
    }
    
    //单列，获取DataManager的实例
    public static DataManager GetInstance() {
        if (mInstance == null) {
            if (mInstance == null) {
                lock (lockHelper) {
                    if (mInstance == null) {
                        mInstance = new DataManager();
                    }
                }
            }
        }
        return mInstance;
    }

    //炮塔角度赋值
    public void SetBatteryAngle(float angle) {
        mBatteryAngle = angle;
    }

    //获取炮塔角度
    public float GetBatteryAngle() {
        return mBatteryAngle;
    }

    public void SetTransform(Transform tf) {
        mTransform = tf;
    }

    public Transform GetTransform() {
        return mTransform;
    }
}
