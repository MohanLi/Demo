using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour
{
    public Transform[] backgounds;
    public Vector2 parallaxScaleXAndY = new Vector2(2.0f, 2.0f);
    public Vector2 smoothXAndY = new Vector2(10.0f, 10.0f);
    public Vector2 parallaxReductionXAndY = new Vector2(1.5f, 1.5f);

    Transform player;
    Vector3 prePlayerPos;

    void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    void Start()
    {
        prePlayerPos = player.position;
    }

    void Update()
    {
        MoveBackground();
        JumpBackground();
        prePlayerPos = player.position;
    }

    void MoveBackground()
    {
        float parallax = (prePlayerPos.x - player.position.x) * parallaxScaleXAndY.x;
        for (int i = 0; i < backgounds.Length; i++)
        {
            float backgroundTargetPosX = backgounds[i].position.x + parallax * (i * parallaxReductionXAndY.x + 1);
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgounds[i].position.y, backgounds[i].position.z);
            backgounds[i].position = Vector3.Lerp(backgounds[i].position, backgroundTargetPos, Time.deltaTime * smoothXAndY.x);
        }
    }

    void JumpBackground()
    {
        float parallaxY = (prePlayerPos.y - player.position.y) * parallaxScaleXAndY.y;
        for (int i = 0; i < backgounds.Length; i++)
        {
            float backgroundTargetY = backgounds[i].position.y + parallaxY * (i * parallaxReductionXAndY.y + 1);
            Vector3 backgroundTargetPos = new Vector3(backgounds[i].position.x, backgroundTargetY, backgounds[i].position.z);
            //使用Lerp函数，需要一定的时间，导致位置出现错乱的情况
            //backgounds[i].position = Vector3.Lerp(backgounds[i].position, backgroundTargetPos, Time.deltaTime * smoothXAndY.y);
            backgounds[i].position = backgroundTargetPos;
        }
    }
}