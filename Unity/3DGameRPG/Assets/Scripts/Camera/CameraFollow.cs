/**
 * Description : 相机跟随
 * Creater : Mohan
 * Date : 2016-04-22
 */
using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public float xMargin = 1f;
    public float yMargin = 1f;
    public float xSmooth = 8f;
    public float ySmooth = 8f;

    public Vector2 maxXAndY;
    public Vector2 minXandY;

    private Transform player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }

    void FixedUpdate()
    {
        TrackPlayer();
    }

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
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
        }

        targetX = Mathf.Clamp(targetX, minXandY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXandY.y, maxXAndY.y);
        //transform.position = new Vector3(targetX, targetY, transform.position.z);

        transform.position = Vector3.Lerp(
            transform.position, new Vector3(targetX, targetY, transform.position.z), xSmooth * Time.deltaTime);
    }
}
