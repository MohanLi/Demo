using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestAI : MonoBehaviour
{
    public Image target;
    public float target_moveSpeed;
    public float MIN_trackingRate;//向量改变率
    public float MIN_trackingDis;
    public float MAX_trackingVel;
    public float moveVx;//x方向速度
    public float moveVy;//y方向速度

    void Update()
    {
        MoveTarget();
        Track_AIAdvanced();
        CheckMoveBoundary();
    }

    void LookAtTarget()
    {
        float zAngles;
        if (moveVy == 0)
        {
            zAngles = moveVx >= 0 ? -90 : 90;
        }
        zAngles = Mathf.Atan(moveVx / moveVy) * (-180 / Mathf.PI);
        if (moveVy < 0)
        {
            zAngles = zAngles - 180;
        }
        Vector3 tempAngles = new Vector3(0, 0, zAngles);
        Quaternion tempQua = this.transform.rotation;
        tempQua.eulerAngles = tempAngles;
        this.transform.rotation = tempQua;
    }

    void MoveTarget()
    {
        float x = Input.GetAxis("Horizontal") ;
        float y = Input.GetAxis("Vertical");
        //如果超出屏幕范围则让它出现在另一面  
        target.transform.Translate(x * Time.deltaTime * target_moveSpeed, y * Time.deltaTime * target_moveSpeed, 0);
        if (target.transform.position.x >= Screen.width)
        {
            //使用了Image的target.rectTransform.lossyScale.x来表示显示的图片宽度  
            target.transform.position = new Vector3(-target.rectTransform.lossyScale.x, target.transform.position.y, 0);
        }
        else if (target.transform.position.x < -target.rectTransform.lossyScale.x)
        {
            target.transform.position = new Vector3(Screen.width, target.transform.position.y, 0);
        }
        if (target.transform.position.y >= Screen.height)
        {
            target.transform.position = new Vector3(target.transform.position.x, -target.rectTransform.lossyScale.y, 0);
        }
        else if (target.transform.position.y < -target.rectTransform.lossyScale.y)
        {
            target.transform.position = new Vector3(target.transform.position.x, Screen.height, 0);
        }
    }

    /// <summary>  
    /// 追踪算法  
    /// </summary>  
    void Track_AIAdvanced()
    {
        //计算与追踪目标的方向向量  
        float vx = target.transform.position.x - this.transform.position.x;
        float vy = target.transform.position.y - this.transform.position.y;

        float length = PointDistance_2D(vx, vy);
        //如果达到距离就追踪  
        if (length < MIN_trackingDis)
        {
            vx = MIN_trackingRate * vx / length;
            vy = MIN_trackingRate * vy / length;
            moveVx += vx;
            moveVy += vy;

            //增加一点扰动  
            if (Random.Range(1, 10) == 1)
            {
                vx = Random.Range(-1, 1);
                vy = Random.Range(-1, 1);
                moveVx += vx;
                moveVy += vy;
            }
            length = PointDistance_2D(moveVx, moveVy);

            //如果导弹飞的速度太快就让它慢下来  
            if (length > MAX_trackingVel)
            {
                //让它慢下来  
                moveVx *= 0.75f;
                moveVy *= 0.75f;
            }

        }
        //如果不在追踪范围内，随机运动  
        else
        {
            if (Random.Range(1, 10) == 1)
            {
                vx = Random.Range(-2, 2);
                vy = Random.Range(-2, 2);
                moveVx += vx;
                moveVy += vy;
            }
            length = PointDistance_2D(moveVx, moveVy);

            //如果导弹飞的速度太快就让它慢下来  
            if (length > MAX_trackingVel)
            {
                //让它慢下来  
                moveVx *= 0.75f;
                moveVy *= 0.75f;
            }
        }


        this.transform.position += new Vector3(moveVx * Time.deltaTime, moveVy * Time.deltaTime, 0);
    } 

    /// <summary>  
    /// 计算从零点到这个点的距离  
    /// </summary>  
    /// <param name="x"></param>  
    /// <param name="y"></param>  
    /// <returns></returns>  
    float PointDistance_2D(float x, float y)
    {
        //使用了泰勒展开式来计算，有3.5%的误差,直接使用开方计算会比较慢，但是测试了我的电脑好像没有什么变化可能是数据量不大体现不出来  
        /*x = Mathf.Abs(x); 
        y = Mathf.Abs(y); 
        float mn = Mathf.Min(x, y);//获取x,y中最小的数 
        float result = x + y - (mn / 2) - (mn / 4) + (mn / 8);*/

        float result = Mathf.Sqrt(x * x + y * y);
        return result;
    } 

    void CheckMoveBoundary()
    {
        //检测是否超出了边界  
        if (this.transform.position.x >= Screen.width)
        {
            this.transform.position = new Vector3(-this.GetComponent<Image>().rectTransform.lossyScale.x, 0, 0);
        }
        else if (this.transform.position.x < -this.GetComponent<Image>().rectTransform.lossyScale.x)
        {
            this.transform.position = new Vector3(Screen.width, this.transform.position.y, 0);
        }
        if (this.transform.position.y >= Screen.height)
        {
            this.transform.position = new Vector3(this.transform.position.x, -this.GetComponent<Image>().rectTransform.lossyScale.y, 0);
        }
        else if (this.transform.position.y < -this.GetComponent<Image>().rectTransform.lossyScale.y)
        {
            this.transform.position = new Vector3(this.transform.position.x, Screen.height, 0);
        }
    } 
}
