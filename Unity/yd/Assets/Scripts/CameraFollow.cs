using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    //X方向距离
    public float xMargin = 1f;
    //Y方向距离
    public float yMargin = 0f;
    //X方向滑动的速度
    public float xSmooth = 3f;
    //Y方向滑动的方向
    public float ySmooth = 3f;
    // 最小X值和Y值
    public Vector2 minXAndY = new Vector2(0.0f, 0.0f);
    // 最大X值和Y值
    public Vector2 maxXAndY = new Vector2(33.0f, 2.3f);
 
    Transform player;

    private float prePlayerPosY;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        prePlayerPosY = player.position.y;
    }

    /// <summary>
    /// 检测Camare在X方向是否需要滑动
    /// </summary>
    /// <returns></returns>
    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    /// <summary>
    /// 检测Camare在Y方向上是否需要滑动
    /// </summary>
    /// <returns></returns>
    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }

    void FixedUpdate()
    {
        TrackPlayer();
        prePlayerPosY = player.position.y;
    }

    /// <summary>
    /// Camera跟随layer
    /// </summary>
    void TrackPlayer()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (CheckXMargin())
        {
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
        }

        if (CheckYMargin())
        {
            float y = transform.position.y + (prePlayerPosY - player.position.y);
            targetY = Mathf.Lerp(transform.position.y, y, ySmooth * Time.deltaTime);
        }

        // X方向值的限制
        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        //Y方向值的限制
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        //设置Camera的位置
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}