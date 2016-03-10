using UnityEngine;
using System.Collections;

public class BatteryController : MonoBehaviour {
    private Animator mAnimator;
    private string mAnimationName = "IsShoot";
    private bool mIsFiring = false;

	// Use this for initialization
	void Start () {
        mAnimator = GetComponent<Animator>();
        SetFire(mAnimationName, false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) && !IsFiring()) {
            mIsFiring = true;
            StartCoroutine(Fire());
        }
        AdjustBatteryDirection();
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
        float angle = Mathf.Atan(offSetX / offSetY) * 180 / Mathf.PI;
        
        angle = angle > 85 ? 85 : angle;
        angle = angle < -85 ? -85 : angle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
    }
}
