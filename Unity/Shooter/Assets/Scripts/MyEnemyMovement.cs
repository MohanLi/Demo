using UnityEngine;
using System.Collections;

public class MyEnemyMovement : MonoBehaviour {
    private Transform player;
    private NavMeshAgent nav;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        nav.SetDestination(player.position);
    }
}
