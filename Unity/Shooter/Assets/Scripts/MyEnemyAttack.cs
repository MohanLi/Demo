using UnityEngine;
using System.Collections;

public class MyEnemyAttack : MonoBehaviour {
    public float timeBetweenAttack = 0.5f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    bool playerInRange;
    float timer;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject == player)
        {
            playerInRange = false;

        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (playerInRange && timer >= timeBetweenAttack) 
        {
            Attack();
        }
    }

    void Attack()
    {
        timer = 0f;
    }
}
