using UnityEngine;
using System.Collections;

public class BatteryController : MonoBehaviour {
    private Animator mAnimator;
    private string mAnimationName = "IsShoot";
    private bool mIsFiring = false;
    private float mBatteryAngle = 0f;

	// Use this for initialization
	void Start () {
        mAnimator = GetComponent<Animator>();
        SetFire(mAnimationName, false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButtonUp(0) && !IsFiring()) {
            mIsFiring = true;
            StartCoroutine(Fire());
        }
        AdjustBatteryDirection();
        //保存数据
        SaveAngle(mBatteryAngle);
        SaveTransform(gameObject.transform);
	}

    IEnumerator Fire() {
        SetFire(mAnimationName, true);
        yield return new WaitForSeconds(0.433f);
        SetFire(mAnimationName, false);
        mIsFiring = false;
    }

    private void SetFire(string name, bool fire) {
        mAnimator.SetBool(name, fire);
    }

    private bool IsFiring() {
        return mIsFiring;// mAnimator.GetBool(mAnimationName);
    }

    //调整炮台方向
    private void AdjustBatteryDirection() {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float offSetX = point.x - transform.position.x;
        float offSetY = point.y - transform.position.y;
        //调整值
        offSetY = offSetY < 0 ? 0 : offSetY;

        // -90 < angle < 90
        mBatteryAngle = Mathf.Atan(offSetX / offSetY) * 180 / Mathf.PI;

        mBatteryAngle = mBatteryAngle > 85 ? 85 : mBatteryAngle;
        mBatteryAngle = mBatteryAngle < -85 ? -85 : mBatteryAngle;
        transform.rotation = Quaternion.AngleAxis(mBatteryAngle, Vector3.back);
    }

    //保存炮塔角度
    private void SaveAngle(float angle) {
        DataManager.GetInstance().SetBatteryAngle(angle);
    }

    private void SaveTransform(Transform tf) {
        DataManager.GetInstance().SetTransform(tf);
    }
}
