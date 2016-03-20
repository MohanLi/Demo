/**
 * Creater : Mohan
 * Date : 2016-03-20
 * Desc : 行星碰撞
 */

using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController;
    private int score;

    void Start()
    {
        score = 10;
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        if (go != null)
        {
            gameController = go.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("cannot find GameController");   
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(score);

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
