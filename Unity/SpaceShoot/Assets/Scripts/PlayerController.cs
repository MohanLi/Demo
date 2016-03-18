using UnityEngine;
using System.Collections;

[System.Serializable]//只有序列化，在程序中才现实出来
public class Boundary
{   //boundary:界限，范围
    public float xMni, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
    //速度
    public float speed;
    //倾斜角度
    public float tilt;
    //范围
    public Boundary boundary;

    void FixedUpdate()
    {
        //垂直方向移动的值
        float moveVertical = Input.GetAxis("Vertical");
        //水平方向移动的值
        float moveHorizontal = Input.GetAxis("Horizontal");

        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;


        //限制范围
        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, boundary.xMni, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
        );

        //设置倾斜角度
        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    }

}
