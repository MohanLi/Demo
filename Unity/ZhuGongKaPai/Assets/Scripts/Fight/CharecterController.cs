using UnityEngine;
using System.Collections;

public class CharecterController : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Run", true);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            anim.SetBool("Run", false);
        }
    }
}
