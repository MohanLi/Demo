using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
    private float mTotalScore;
	// Use this for initialization
	void Start () {
        mTotalScore = 0.0f;
	}

    public void AddScore(float score) {
        mTotalScore += score;
    }
}
