using UnityEngine;
using System.Collections;

public class MyEnemyMovement : MonoBehaviour {
    private Transform player;
    private NavMeshAgent nav;

    MyEnemyHealth enemyHealth;
    MyPlayerHeath playerHealth;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<MyPlayerHeath>();
        enemyHealth = GetComponent<MyEnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        if (playerHealth.currentHealth > 0 && enemyHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
