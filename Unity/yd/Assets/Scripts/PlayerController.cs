using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;
    public Transform player;
    public float speed = 8.0f;
 

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        Run(h);
    }

    void Run(float h)
    {
        if (h == 0)
        {
            playerAnim.SetBool("run", false);
        }
        else
        {
            playerAnim.SetBool("run", true);

            int abs = h < 0 ? -1 : 1;
            player.localScale = new Vector3(player.localScale.x, player.localScale.y, abs * Mathf.Abs(player.localScale.z));

            Vector3 pos = new Vector3(player.position.x + abs * Time.deltaTime * speed, player.position.y, player.position.z);
            player.position = Vector3.Lerp(player.position, pos, Time.deltaTime);
        }
    }

}
