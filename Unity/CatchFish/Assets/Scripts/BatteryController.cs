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
	}

    IEnumerator Fire() {
        Debug.Log("1===========");
        SetFire(mAnimationName, true);
        yield return new WaitForSeconds(0.433f);
        SetFire(mAnimationName, false);
        mIsFiring = false;
        Debug.Log("2===========");
    }

    private void SetFire(string name, bool fire) {
        mAnimator.SetBool(name, fire);
    }

    private bool IsFiring() {
        return mIsFiring;// mAnimator.GetBool(mAnimationName);
    }
}
