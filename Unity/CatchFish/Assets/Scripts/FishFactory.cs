using UnityEngine;
using System.Collections;

public class FishFactory : MonoBehaviour
{
    //创建鱼的时间
    private float mCreateTime;
    //
    private float mCurrentTime;

    // Use this for initialization
    void Start()
    {
        InitTime();
    }

    //初始化时间
    void InitTime()
    {
        mCreateTime = Random.Range(1, 3);
        mCurrentTime = 0f;
    }

    //创建鱼
    void CreateFish()
    {
        GameObject fish = (GameObject)Instantiate(Resources.Load("fish_00"));
        fish.transform.position = new Vector3(-8, Random.Range(-4, 4), 0);

        //为鱼添加组件
        fish.AddComponent<DestroyObject>();
        fish.AddComponent<FishController>();
    }

    void FixedUpdate()
    {
        if (mCurrentTime >= mCreateTime)
        {
            CreateFish();
            InitTime();
        }
        mCurrentTime += Time.deltaTime;
    }
}

