/**
 * Creater : Mohan
 * Date : 2016-03-20
 * Desc : 碰撞边界
 */

using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider coll)
    {
        Destroy(coll.gameObject);
    }
}
